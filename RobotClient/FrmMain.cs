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
        private static string connectionUrl = "http://localhost:5000";

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

        private void DgvRobot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            // Edit
            if (e.ColumnIndex == 4)
            {
                int RowIndex = e.RowIndex;
                string? id = DgvRobot[3, RowIndex].Value.ToString();
                if (id != null)
                {
                    FrmUpdateRobot frm = new(id, GetRobotsClient()); 
                    frm.ShowDialog();

                    UpdateRobotGridView();
                }

            }
            // Delete
            else if (e.ColumnIndex == 5)
            {
                DialogResult result = MessageBox.Show("Are you sure to Delete?", "Warning",
                                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    int RowIndex = e.RowIndex;
                    string? id = DgvRobot[3, RowIndex].Value.ToString();
                    if (id != null)
                    {
                        DeleteRobotById(id);
                    }

                }
            }
        }

        private void LblAlert_Click(object sender, EventArgs e)
        {
            LblAlert.Visible = false;
        }

        private async void TestSeverConnection()
        {
            try
            {
                var empty = new Empty();
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
            LblAlert.Visible = false;
            int iCnt = DgvRobot.Rows.Count;
            for (int i = 0; i < iCnt; i++)
            {
                DgvRobot.Rows.RemoveAt(0);
            }
            try
            {
                var empty = new Empty();
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

        private async void DeleteRobotById(string id)
        {
            try
            {
                var input = new RobotLookUpRequest { Id = id };

                var response = await GetRobotsClient().DeleteRobotAsync(input);

                if (response.IsOk == true)
                {
                    UpdateRobotGridView();
                }
                else
                {
                    LblAlert.Text = response.Result;
                    LblAlert.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LblAlert.Text = ex.Message;
                LblAlert.Visible = true;
            }

        }


    }
}
