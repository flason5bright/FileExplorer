using System;
using System.Security.Cryptography;

namespace FileExplorer.Model
{
    public class HardDiskInfo
    {
        private bool _isPrimary = false;

        public string Name { get; set; }
        public string Label { get; set; }

        public double FreeSpace { get; set; }

        public double TotalSpace { get; set; }

        private double _usedSpace = 0;

        public double UsedSpace
        {
            get
            {
                _usedSpace = TotalSpace - FreeSpace;
                return _usedSpace;
            }
            set
            {
                _usedSpace = value;
            }
        }

        public bool IsPrimary
        {
            get
            {
                return _isPrimary;
            }
        }

        public HardDiskInfo( string name, string label = "", double total = 0, double free = 0 )
        {
            this.Name = name;
            this.Label = label;
            this.TotalSpace = total;
            this.FreeSpace = free;
            _isPrimary = System.Environment.GetEnvironmentVariable( "windir" ).Remove( 3 ) == this.Name;
        }
    }
}