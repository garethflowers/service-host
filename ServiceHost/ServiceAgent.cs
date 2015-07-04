// <copyright file="ServiceAgent.cs" company="Gareth Flowers">
//     Copyright Gareth Flowers. All rights reserved.
// </copyright>

namespace ServiceHost
{
    /// <summary>
    /// Primary Service Handler
    /// </summary>
    internal partial class ServiceAgent : System.ServiceProcess.ServiceBase
    {
        /// <summary>
        /// Additional command line arguments.
        /// </summary>
        private readonly string arguments;

        /// <summary>
        /// Command to run.
        /// </summary>
        private readonly string command;

        /// <summary>
        /// Command process.
        /// </summary>
        private System.Diagnostics.Process process;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgent"/> class.
        /// </summary>
        public ServiceAgent()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAgent"/> class.
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        public ServiceAgent(string[] args)
        {
            this.InitializeComponent();

            this.command = args[0];

            for (int i = 1; i < args.Length; i++)
            {
                this.arguments += ' ' + args[i];
            }
        }

        /// <summary>
        /// Executes when a Start command is sent to the service.
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        protected override void OnStart(string[] args)
        {
            this.process = new System.Diagnostics.Process();
            this.process.StartInfo.FileName = this.command;
            this.process.StartInfo.Arguments = this.arguments;
            this.process.Start();
        }

        /// <summary>
        /// Executes when a Stop command is sent to the service.
        /// </summary>
        protected override void OnStop()
        {
            if (this.process == null || this.process.HasExited)
            {
                return;
            }

            try
            {
                this.process.Kill();
            }
            finally
            {
                this.process = null;
            }
        }
    }
}
