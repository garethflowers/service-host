namespace ServiceHost
{
    public partial class ServiceAgent : System.ServiceProcess.ServiceBase
    {
        private readonly string _arguments;
        private readonly string _command;

        private System.Diagnostics.Process _process;

        public ServiceAgent()
        {
            this.InitializeComponent();
        }

        public ServiceAgent(string[] args)
        {
            this._command = args[0];

            for (int i = 1; i < args.Length; i++)
            {
                this._arguments += ' ' + args[i];
            }
        }

        protected override void OnStart(string[] args)
        {
            _process = new System.Diagnostics.Process();
            _process.StartInfo.FileName = this._command;
            _process.StartInfo.Arguments = this._arguments;
            _process.Start();
        }

        protected override void OnStop()
        {
            if (this._process == null || this._process.HasExited)
            {
                return;
            }

            try
            {
                this._process.Kill();
            }
            finally
            {
                this._process = null;
            }
        }
    }
}