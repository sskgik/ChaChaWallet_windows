namespace ChaChaCoin
{
    using System;
    using System.Windows.Forms;
    using Miyabi.Cryptography;
    using Utility;

    public partial class Form7 : Form
    {
        public Form7()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string a = this.textBox1.Text;
            string completejudge = this.Inputprivatekeyjudgement(a);
            if (a == string.Empty)
            {
                Form5 frmform5 = new Form5();
                frmform5.ShowDialog();
                return;
            }
            else if (completejudge == null)
            {
                return;
            }

            Utils utl = new Utils();
            utl.Inputprivatekey = completejudge;
            this.Close();
        }

        private string Inputprivatekeyjudgement(string privatekey)
        {
            try
            {
                var value = PrivateKey.Parse(privatekey);
            }
            catch (Exception)
            {
                Form5 frmform5 = new Form5();
                frmform5.ShowDialog();
                privatekey = null;
            }

            return privatekey;
        }

        private void Form7_Closed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.privatekey = null;
            Properties.Settings.Default.Save();
        }
    }
}
