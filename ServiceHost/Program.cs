// <copyright file="Program.cs" company="Gareth Flowers">
//     Copyright Gareth Flowers. All rights reserved.
// </copyright>

namespace ServiceHost
{
    /// <summary>
    /// Application main class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            System.ServiceProcess.ServiceBase[] servicesToRun;

            servicesToRun = new System.ServiceProcess.ServiceBase[]
            {
                new ServiceAgent(args)
            };

            System.ServiceProcess.ServiceBase.Run(servicesToRun);
        }
    }
}
