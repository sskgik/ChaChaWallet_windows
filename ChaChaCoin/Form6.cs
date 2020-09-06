namespace ChaChaCoin
{
    using System;
    using System.Windows.Forms;

    public partial class Form6 : Form
    {
        private string transaction = string.Empty;
        private string txresult = string.Empty;

        public Form6()
        {
            this.InitializeComponent();
        }

        // display transactionID
        public string TxId
        {
            get
            {
                return this.transaction;
            }

            set
            {
                this.transaction = value;
            }
        }

        // display transactionID
        public string Tx_result
        {
            get
            {
                return this.txresult;
            }

            set
            {
                this.txresult = value;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.transaction;
            this.label1.Text = "Transaction_Resault:\t" + this.Tx_result;
            this.textBox1.ReadOnly = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}