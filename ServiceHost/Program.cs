namespace ServiceHost
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            System.ServiceProcess.ServiceBase[] ServicesToRun;

            ServicesToRun = new System.ServiceProcess.ServiceBase[]
			{
				new ServiceAgent(args)
			};

            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
    }
}