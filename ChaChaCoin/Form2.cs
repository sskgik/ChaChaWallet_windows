namespace ChaChaCoin
{
    using System;
    using System.Windows.Forms;
    using WalletService;

    public partial class Form2 : Form
    {
        public Form2()
        {
            this.InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WAction getpubKey = new WAction();
            this.textBox1.Text = Convert.ToString(getpubKey.GetAddress());
            this.textBox1.ReadOnly = true;
        }

        /// <summary>
        /// Be clicked close Form2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirmed_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
