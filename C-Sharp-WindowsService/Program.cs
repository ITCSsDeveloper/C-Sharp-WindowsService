namespace C_Sharp_WindowsService
{
    internal static class Program
    {
        /// REF : http://www.thaicreate.com/tutorial/windows-service-application.html
        private static void Main()
        {
#if DEBUG
            var myService = new Service1();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
        {
            new Service1()
        };
        ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}