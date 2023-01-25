using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using static RobotServer.Robots;

namespace RobotClient
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// connection url to server
        /// </summary>
        private static string connectionUrl = "http://20.222.40.75";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TestSeverConnection();
            Text = $"Robot Manager ({connectionUrl})";
        }

        private void BtnUrl_Click(object sender, EventArgs e)
        {
            FrmUrl frm = new(this, connectionUrl, false);
            frm.ShowDialog();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

        }

        private async void TestSeverConnection()
        {
            try
            {
                var empty = new RobotServer.Empty();
                var response = await GetRobotsClient().TestConnectionAsync(empty);

                if (response == null)
                {
                    Text = "Error";
                    FrmUrl frm = new(this, connectionUrl, true);
                    frm.ShowDialog();
                }

            }
            catch (Exception)
            {
                Text = "Error";
                FrmUrl frm = new(this, connectionUrl, true);
                frm.ShowDialog();
            }
        }

        private static RobotsClient GetRobotsClient()
        {
            var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
            var channel = GrpcChannel.ForAddress(connectionUrl,
                new GrpcChannelOptions
                {
                    HttpClient = new HttpClient(handler)
                });
            return new RobotsClient(channel);
        }

        public void CngConnectionString(string newUrl)
        {
            connectionUrl = newUrl;
            Text = $"Robot Manager ({connectionUrl})";
        }

        public async void UpdateRobotGridView()
        {

        }
    }
}