using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();


            ShowWindow(handle, SW_HIDE);
            //Console.Read();

            NewLibraryData obj = new NewLibraryData();

            Console.WriteLine("Начало подключения");

                Uri address = new Uri("net.tcp://localhost:4000/IContract");
                NetTcpBinding binding = new NetTcpBinding();
                Type contract = typeof(IContract);
                ServiceHost host = new ServiceHost(typeof(NewLibraryData));
                host.AddServiceEndpoint(contract, binding, address);
                host.Open();

                Console.WriteLine("Подключился");

                Console.ReadKey();
        }
    }
}
