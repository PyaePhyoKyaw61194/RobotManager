using RobotServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static RobotServer.Robots;

namespace RobotClient
{
    public partial class FrmAddRobot : Form
    {
        /// <summary>
        /// Client object to access server
        /// </summary>
        /// <param name="robotsClient"></param>
        private readonly RobotsClient _robotsClient;

        public FrmAddRobot(RobotsClient robotsClient)
        {
            InitializeComponent();
            _robotsClient = robotsClient;
        }

        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim().Length == 0)
            {
                LblNoti.Text = "Name should not be blank";
                LblNoti.Visible = true;
                TxtName.Focus();
                return;
            }

            try
            {
                var input = new RobotCreateRequest { Name = TxtName.Text.Trim(), Description = TxtDesc.Text.Trim() };
                var newRobot = await _robotsClient.CreateRobotAsync(input);

                if (newRobot.IsOk == false)
                {
                    LblNoti.Text = newRobot.Result;
                    LblNoti.Visible = true;
                    TxtName.Focus();
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                LblNoti.Text = ex.Message;
                LblNoti.Visible = true;
            }
        }
    }
}
