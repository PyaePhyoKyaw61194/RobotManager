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
            this.Text = $"Robot Manager ({connectionUrl})";
        }

        private void BtnUrl_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

        }

     
    }
}