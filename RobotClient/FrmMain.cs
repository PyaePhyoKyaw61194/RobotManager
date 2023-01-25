using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using RobotServer;
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
            UpdateRobotGridView();
            Text = $"Robot Manager ({connectionUrl})";
        }

        private void BtnUrl_Click(object sender, EventArgs e)
        {
            FrmUrl frm = new(this, connectionUrl, false);
            frm.ShowDialog();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            FrmAddRobot frm = new(GetRobotsClient());
            frm.ShowDialog();

            UpdateRobotGridView();
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
            int iCnt = DgvRobot.Rows.Count;
            for (int i = 0; i < iCnt; i++)
            {
                DgvRobot.Rows.RemoveAt(0);
            }
            try
            {
                var empty = new RobotServer.Empty();
                var robots = await GetRobotsClient().GetRobotListAsync(empty);
                if (robots != null)
                {
                    foreach (var _robot in robots.Items)
                    {
                        FillDgvRow(_robot);
                    }
                    FillActionColumns();
                }
            }
            catch (Exception ex)
            {
                LblAlert.Text = ex.Message;
                LblAlert.Visible = true;
            }
        }

        private void FillDgvRow(RobotModel robotModel)
        {
            DgvRobot.Rows.Add(DgvRobot.Rows.Count + 1,
                robotModel.Name,
                robotModel.Description,
                robotModel.Id);
        }

        private void FillActionColumns()
        {
            if (DgvRobot.Columns.Count == 4)
            {
                DataGridViewButtonColumn btnEdit = new()
                {
                    Name = "btnEdit",
                    Text = "Edit",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };
                DgvRobot.Columns.Add(btnEdit);


                DataGridViewButtonColumn btnDelete = new()
                {
                    Name = "btnDelete",
                    Text = "Delete",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };
                DgvRobot.Columns.Add(btnDelete);
            }

        }

    }
}