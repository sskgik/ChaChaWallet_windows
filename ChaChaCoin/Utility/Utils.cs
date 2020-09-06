namespace Utility
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using ChaChaCoin;
    using Miyabi;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Miyabi.Cryptography;

    public class Utils
    {
        Form7 frmform7 = new Form7();
        public static string[] MyPrivateKey = new string[1];

        public string Inputprivatekey
        {
            get
            {
                return MyPrivateKey[0];
            }

            set
            {
                 MyPrivateKey[0] = value;
            }
        }

        // Change API url according to miyabi config.json
        public static string ApiUrl = "https://playground.blockchain.bitflyer.com/";

        // Change table admin private key according to miyabi blockchain config
        /* public static KeyPair GetTableAdminKeyPair() =>
           GetKeyPair("");

        // Change contract admin private key according to miyabi blockchain config
           public static KeyPair GetContractAdminKeyPair() =>
           GetKeyPair(""); */

        // Represetns table owner or contract owner
        // public static KeyPair GetOwnerKeyPair() =>
        //    GetKeyPair("");

        // My_Privatekey
        public static KeyPair GetUser0KeyPair() =>
            GetKeyPair(MyPrivateKey[0]);

        // public static KeyPair GetUser1KeyPair() =>
        // GetKeyPair("");


        public static KeyPair GetKeyPair(string privateKey)
        {
            var adminPrivateKey =
                PrivateKey.Parse(privateKey);
            return new KeyPair(adminPrivateKey);
        }

        public static async Task<string> WaitTx(GeneralApi api, ByteString id)
        {
            while (true)
            {
                var result = await api.GetTransactionResultAsync(id);
                if (result.Value.ResultCode != TransactionResultCode.Pending)
                {
                    return result.Value.ResultCode.ToString();
                }

            }
        }

       /* public static HttpClientHandler GetBypassRemoteCertificateValidationHandler()
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => true,
            };

            return handler;
        }*/
    }
}
