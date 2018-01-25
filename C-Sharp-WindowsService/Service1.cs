using System;
using System.ServiceProcess;

namespace C_Sharp_WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            this.OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            var strPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            System.IO.File.AppendAllLines(strPath, new[] { "Starting time : " + DateTime.Now.ToString() });
            this.timer1.Start();
        }

        protected override void OnStop()
        {
            var strPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            System.IO.File.AppendAllLines(strPath, new[] { "Stop time : " + DateTime.Now.ToString() });
            this.timer1.Stop();
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            System.IO.File.AppendAllLines(strPath, new[] { "..calling time : " + DateTime.Now.ToString() });
        }
    }
}