
namespace ChaChaCoin
{
    using System;
    using System.Windows.Forms;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Miyabi.Cryptography;
    using Utility;
    using WalletService;

     /// <summary>
     /// input infomation for coin send
     /// </summary>
    public partial class Form3 : Form
    {
        private readonly Form1 frmform1;
        private int count;
        private string[] amount_hystory = new string[256];
        private string[] Senttime = new string[256];

        public Form3(Form1 fm)
        {
            this.InitializeComponent();
            this.frmform1 = fm;
        }

        /// <summary>
        /// Send Transaction with all info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button1_Click(object sender, EventArgs e)
        {
            this.count++;
            var config = new SdkConfig(Utils.ApiUrl);
            var client = new Client(config);
            var _generalClient = new GeneralApi(client);

            // Get textBox1 string
            string text1 = this.textBox1.Text;
            Address mypublickey = this.Inputjudgement(text1);
            if (mypublickey == null)
            {
                this.count--;
                return;
            }

            // get textBox2 string
            string text2 = this.textBox2.Text;
            Address opponetpublickey = this.Inputjudgement(text2);
            if (opponetpublickey == null)
            {
                this.count--;
                return;
            }

            // get textBox3 string
            string text3 = this.textBox3.Text;
            decimal amount = this.Inputnumjudgement(text3);
            if (amount == 0m)
            {
                this.count--;
                return;
            }

            // throw amount to form1
            this.Showtransaction(amount);

            // send coin BroadCast Miyabi
            WAction send = new WAction();
            (string transaction, string result) = await send.Send(mypublickey, opponetpublickey, amount);

            // Open Form6
            Form6 frmForm6 = new Form6();
            frmForm6.TxId = transaction;
            frmForm6.Tx_result = result;
            frmForm6.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Check if the entered information can be converted about publickey.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Inputaddress</returns>
        private Address Inputjudgement(string text)
        {
            Address inputaddress;
            try
                {
                  var value = PublicKey.Parse(text);
                  inputaddress = new PublicKeyAddress(value);
                }
                catch (Exception e)
                {
                    Form5 frmform5 = new Form5();
                    frmform5.ShowDialog();
                    inputaddress = null;
                }

            return inputaddress;
        }

        /// <summary>
        /// Check if the entered information can be converted about amount.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>inputamount</returns>
        private decimal Inputnumjudgement(string text)
        {
            decimal inputamount = 0m;

            try
                {
                    inputamount = Convert.ToDecimal(text);
                }
            catch (Exception)
            {
                    Form5 frmform5 = new Form5();
                    frmform5.ShowDialog();
                    inputamount = 0m;
                }

            return inputamount;
        }

        /// <summary>
        /// show recent Transaction on Form1.
        /// </summary>
        /// <param name="amount"></param>
        private void Showtransaction(decimal amount)
        {
            string nullamount = string.Empty;
            int i = this.count - 1;
            string amount1 = Convert.ToString(amount);
            this.amount_hystory[i] = amount1;
            this.Senttime[i] = DateTime.Now.ToString("yyyy:MM:dd hh:mm:ss");
            if (i >= 5)
            {
                this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                this.frmform1.label4.Text = this.amount_hystory[i - 1] + "\t枚送金\t" + this.Senttime[i - 1];
                this.frmform1.label5.Text = this.amount_hystory[i - 2] + "\t枚送金\t" + this.Senttime[i - 2];
                this.frmform1.label6.Text = this.amount_hystory[i - 3] + "\t枚送金\t" + this.Senttime[i - 3];
                this.frmform1.label7.Text = this.amount_hystory[i - 4] + "\t枚送金\t" + this.Senttime[i - 4];
                this.frmform1.label8.Text = this.amount_hystory[i - 5] + "\t枚送金\t" + this.Senttime[i - 5];
            }
            else
            {
                switch (i)
                {
                    case 0:
                        this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                        this.frmform1.label4.Text = nullamount;
                        this.frmform1.label5.Text = nullamount;
                        this.frmform1.label6.Text = nullamount;
                        this.frmform1.label7.Text = nullamount;
                        this.frmform1.label8.Text = nullamount;
                        break;
                    case 1:
                        this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                        this.frmform1.label4.Text = this.amount_hystory[i - 1] + "\t枚送金\t" + this.Senttime[i - 1];
                        this.frmform1.label5.Text = nullamount;
                        this.frmform1.label6.Text = nullamount;
                        this.frmform1.label7.Text = nullamount;
                        this.frmform1.label8.Text = nullamount;
                        break;
                    case 2:
                        this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                        this.frmform1.label4.Text = this.amount_hystory[i - 1] + "\t枚送金\t" + this.Senttime[i - 1];
                        this.frmform1.label5.Text = this.amount_hystory[i - 2] + "\t枚送金\t" + this.Senttime[i - 2];
                        this.frmform1.label6.Text = nullamount;
                        this.frmform1.label7.Text = nullamount;
                        this.frmform1.label8.Text = nullamount;
                        break;
                    case 3:
                        this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                        this.frmform1.label4.Text = this.amount_hystory[i - 1] + "\t枚送金\t" + this.Senttime[i - 1];
                        this.frmform1.label5.Text = this.amount_hystory[i - 2] + "\t枚送金\t" + this.Senttime[i - 2];
                        this.frmform1.label6.Text = this.amount_hystory[i - 3] + "\t枚送金\t" + this.Senttime[i - 3];
                        this.frmform1.label6.Text = nullamount;
                        this.frmform1.label7.Text = nullamount;
                        this.frmform1.label8.Text = nullamount;
                        break;
                    case 4:
                        this.frmform1.label3.Text = this.amount_hystory[i] + "\t枚送金\t" + this.Senttime[i];
                        this.frmform1.label4.Text = this.amount_hystory[i - 1] + "\t枚送金\t" + this.Senttime[i - 1];
                        this.frmform1.label5.Text = this.amount_hystory[i - 2] + "\t枚送金\t" + this.Senttime[i - 2];
                        this.frmform1.label6.Text = this.amount_hystory[i - 3] + "\t枚送金\t" + this.Senttime[i - 3];
                        this.frmform1.label7.Text = this.amount_hystory[i - 4] + "\t枚送金\t" + this.Senttime[i - 4];
                        this.frmform1.label8.Text = nullamount;
                        break;
                }
            }
        }

        /// <summary>
        /// read user.config file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_Load(object sender, EventArgs e)
        {
            int j;
            this.count = Properties.Settings.Default.count;
            for (j = 1; j <= 5; j++)
            {
                if (this.count - j < 0)
                {
                    break;
                }
                else
                {
                    if (j == 1)
                    {
                        this.amount_hystory[this.count - j] = Properties.Settings.Default.Array1;
                        this.Senttime[this.count - j] = Properties.Settings.Default.senttime1;
                    }
                    else if (j == 2)
                    {
                        this.amount_hystory[this.count - j] = Properties.Settings.Default.Array2;
                        this.Senttime[this.count - j] = Properties.Settings.Default.senttime2;
                    }
                    else if (j == 3)
                    {
                        this.amount_hystory[this.count - j] = Properties.Settings.Default.Array3;
                        this.Senttime[this.count - j] = Properties.Settings.Default.senttime3;
                    }
                    else if (j == 4)
                    {
                        this.amount_hystory[this.count - j] = Properties.Settings.Default.Array4;
                        this.Senttime[this.count - j] = Properties.Settings.Default.senttime4;
                    }
                    else
                    {
                        this.amount_hystory[this.count - j] = Properties.Settings.Default.Array5;
                        this.Senttime[this.count - j] = Properties.Settings.Default.senttime5;
                    }
                }
            }
        }

        /// <summary>
        /// storage user.config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            int i;
            Properties.Settings.Default.count = this.count;
            for (i = 1; i <= 5; i++)
            {
                if (this.count - i < 0)
                {
                    break;
                }
                else
                {
                    if (i == 1)
                    {
                        Properties.Settings.Default.Array1 = this.amount_hystory[this.count - i];
                        Properties.Settings.Default.senttime1 = this.Senttime[this.count - i];
                    }
                    else if (i == 2)
                    {
                        Properties.Settings.Default.Array2 = this.amount_hystory[this.count - i];
                        Properties.Settings.Default.senttime2 = this.Senttime[this.count - i];
                    }
                    else if (i == 3)
                    {
                        Properties.Settings.Default.Array3 = this.amount_hystory[this.count - i];
                        Properties.Settings.Default.senttime3 = this.Senttime[this.count - i];
                    }
                    else if (i == 4)
                    {
                        Properties.Settings.Default.Array4 = this.amount_hystory[this.count - i];
                        Properties.Settings.Default.senttime4 = this.Senttime[this.count - i];
                    }
                    else
                    {
                        Properties.Settings.Default.Array5 = this.amount_hystory[this.count - i];
                        Properties.Settings.Default.senttime5 = this.Senttime[this.count - i];
                    }
                }
            }

            Properties.Settings.Default.Save();
        }
    }
}
