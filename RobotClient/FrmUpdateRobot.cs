using RobotServer;
using static RobotServer.Robots;

namespace RobotClient
{
    public partial class FrmUpdateRobot : Form
    {
        /// <summary>
        /// id of robot to be updated
        /// </summary>
        private readonly string _robotId;

        /// <summary>
        /// Client object to access server
        /// </summary>
        private readonly RobotsClient _robotsClient;
        public FrmUpdateRobot(string Id, RobotsClient robotsClient)
        {
            InitializeComponent();
            _robotsClient = robotsClient;
            _robotId = Id;
        }

        private async void FrmUpdateRobot_Shown(object sender, EventArgs e)
        {
            try
            {
                var input = new RobotLookUpRequest { Id = _robotId };
                var existingRobot = await _robotsClient.GetRobotByIdAsync(input);

                if (existingRobot.Error != null &&
                    existingRobot.Error.IsOk == false)
                {
                    DialogResult result = MessageBox.Show(existingRobot.Error.Result, "Alert",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
                else
                {
                    TxtName.Text = existingRobot.Name;
                    TxtDesc.Text = existingRobot.Description;
                    TxtName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                Close();
            }

        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim().Length == 0)
            {
                ShowError("Name must be filled");
                return;
            }

            try
            {
                var input = new RobotUpdateRequest { Id = _robotId, Name = TxtName.Text.Trim(), Description = TxtDesc.Text.Trim() };
                var updatedRobot = await _robotsClient.UpdateRobotAsync(input);

                if (updatedRobot.IsOk == false)
                {
                    ShowError(updatedRobot.Result);
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return;

            }
        }

        private void ShowError(string message)
        {
            LblNoti.Text = message;
            LblNoti.Visible = true;
            TxtName.Focus();

        }
    }
}
