using FileExplorer.ViewModel;

using System;

namespace FileExplorer.Console
{
    class Program
    {
        static void Main( string[] args )
        {
            var vm = new HardDiskViewModel();
            System.Console.WriteLine( "Hello World!" );
            System.Console.Read();
        }
    }
}