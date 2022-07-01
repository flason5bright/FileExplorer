using FileExplorer.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using System.Management;

namespace FileExplorer.ViewModel
{
    public class HardDiskViewModel
    {
        public ObservableCollection<HardDiskInfo> HardDiskInfos { get; }

        public HardDiskViewModel()
        {
            HardDiskInfos = new ObservableCollection<HardDiskInfo>();
            UpdateHardDiskInfos2();
        }

        private void UpdateHardDiskInfos()
        {
            HardDiskInfos.Clear();
            WqlObjectQuery wmiquery = new WqlObjectQuery( "select * from Win32_LogiCalDisk" );
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher( wmiquery );
            ManagementObjectCollection queryCollection = wmifind.Get();

            foreach( var disk in queryCollection )
            {
                string name = disk[ "DeviceID" ].ToString();
                double total = Convert.ToDouble( disk[ "Size" ] ) / (1024 * 1024 * 1024);
                double free = Convert.ToDouble( disk[ "FreeSpace" ] ) / (1024 * 1024 * 1024);
                HardDiskInfos.Add( new HardDiskInfo( name, "", total, free ) );
            }
        }

        private void UpdateHardDiskInfos2()
        {
            HardDiskInfos.Clear();
            var drivers = DriveInfo.GetDrives();

            foreach( var driver in drivers )
            {
                string name = driver.Name;
                double total = driver.TotalSize;
                double free = driver.AvailableFreeSpace;
                HardDiskInfos.Add( new HardDiskInfo( name, driver.VolumeLabel, total, free ) );
            }
        }
    }
}