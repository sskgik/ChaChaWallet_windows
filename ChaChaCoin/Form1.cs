namespace ChaChaCoin
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WalletService;

    public partial class Form1 : Form
    {

        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, ShowCommands nShowCmd);

        public Form1()
        {
            this.InitializeComponent();
        }

        private int openlog;

        /// <summary>
        /// get data when wallet is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.openlog = Properties.Settings.Default.Openlog;
            string survey = Properties.Settings.Default.privatekey;
            this.openlog++;
            if (this.openlog == 1)
            {
                Form7 frmForm7 = new Form7();
                frmForm7.ShowDialog();
            }
            else if ((survey == string.Empty) && this.openlog >= 2)
            {
                Form7 frmForm7 = new Form7();
                frmForm7.ShowDialog();
            }
            else
            {
                Utility.Utils.MyPrivateKey[0] = Properties.Settings.Default.privatekey;
            }

            this.label2.Text = Properties.Settings.Default.amount;
            this.label3.Text = Properties.Settings.Default.label3;
            this.label4.Text = Properties.Settings.Default.label4;
            this.label5.Text = Properties.Settings.Default.label5;
            this.label6.Text = Properties.Settings.Default.label6;
            this.label7.Text = Properties.Settings.Default.label7;
            this.label8.Text = Properties.Settings.Default.label8;
        }

        /// <summary>
        /// storage label's Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_close(object sender, FormClosedEventArgs e)
        {

            Properties.Settings.Default.amount = this.label2.Text;
            Properties.Settings.Default.label3 = this.label3.Text;
            Properties.Settings.Default.label4 = this.label4.Text;
            Properties.Settings.Default.label5 = this.label5.Text;
            Properties.Settings.Default.label6 = this.label6.Text;
            Properties.Settings.Default.label7 = this.label7.Text;
            Properties.Settings.Default.label8 = this.label8.Text;
            Properties.Settings.Default.Openlog = this.openlog;
            Properties.Settings.Default.privatekey = Utility.Utils.MyPrivateKey[0];
            Properties.Settings.Default.Save();
        }

        // bottun_getpublicKey
        private void GetPublickey_Click(object sender, EventArgs e)
        {
            Form2 frmForm2 = new Form2();
            frmForm2.ShowDialog();
        }

        // Calling the input form about sender,Opponet,Amount
        private void AssetMove_Click(object sender, EventArgs e)
        {
            Form3 frmForm3 = new Form3(this);
            frmForm3.ShowDialog();
        }

        // Get RealTime Balance 
        private async void Get_Balance_Click(object sender, EventArgs e)
        {
            WAction show = new WAction();
            decimal value = await show.ShowAsset();
            this.label2.Text = Convert.ToString(value);
        }

        // menu
        // about_chachaWallet
        private void aboutChaChaWalletToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 frmForm4 = new Form4();
            frmForm4.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open miyabi manual on web
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellExecute(this.Handle, "open", "https://blockchain.bitflyer.com/miyabi/manual/", null, null, ShowCommands.SW_SHOW);
        }

        // Open miyabi Playground on web
        private void playvgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellExecute(this.Handle, "open", "https://blockchain.bitflyer.com/miyabi/index.html", null, null, ShowCommands.SW_SHOW);
        }

        // Open yanchal_crypto account
        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellExecute(this.Handle, "open", "https://twitter.com/yanchal_crypto", null, null, ShowCommands.SW_SHOW);
        }

        // Open Developer's Github account
        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellExecute(this.Handle, "open", "https://github.com/sskgik", null, null, ShowCommands.SW_SHOW);
        }
    }
}
