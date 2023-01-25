using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using static RobotServer.Robots;

namespace RobotClient
{

    public partial class FrmUrl : Form
    {
        /// <summary>
        /// server connection string
        /// </summary>
        private readonly string _connectionUrl;

        /// <summary>
        /// main form reference
        /// </summary>
        private readonly FrmMain _frmMain;

        /// <summary>
        /// showing alert when the connection is failed
        /// </summary>
        private readonly bool _isShowError;

        public FrmUrl(FrmMain frmMain, string connectionUrl, bool isShowError)
        {
            InitializeComponent();
            _connectionUrl = connectionUrl;
            _frmMain = frmMain;
            _isShowError = isShowError;
        }

        private void FrmUrl_Load(object sender, EventArgs e)
        {
            TxtUrl.Text = _connectionUrl;
            TxtUrl.Focus();
            if (_isShowError == true)
            {
                ShowError();
            }
        }

        private async void BtnUpdate_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());

                var channel = GrpcChannel.ForAddress(TxtUrl.Text,
              new GrpcChannelOptions
              {
                  HttpClient = new HttpClient(handler)
              });
                var robotsClient = new RobotsClient(channel);

                var empty = new RobotServer.Empty();
                var response = await robotsClient.TestConnectionAsync(empty);

                if (response.IsOk == true)
                {
                    _frmMain.CngConnectionString(TxtUrl.Text);
                    _frmMain.UpdateRobotGridView();
                    this.Close();
                }
                else
                {
                    ShowError();
                }
            }
            catch (Exception)
            {
                ShowError();
            }
        }

        private void ShowError()
        {
            lblAlert.Visible = true;
            TxtUrl.Focus();
        }
    }
}
