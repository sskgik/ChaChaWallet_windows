namespace WalletService
{
    using System;
    using System.Threading.Tasks;
    using Miyabi.Asset.Client;
    using Miyabi.Asset.Models;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Utility;

    /// <summary>
    /// Wallt action class.
    /// </summary>
    public class WAction
    {
        private const string TableName = "ChaChaCoin";

        /// <summary>
        /// Send Asset Method
        /// </summary>
        /// <param name="client"></param>
        /// <returns>tx.Id</returns>
        public async Task<Tuple<string, string>> Send(Address myaddress, Address opponetaddress, decimal amount)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var from = myaddress;
            var to = opponetaddress;

            // enter the send amount
            var moveCoin = new AssetMove(TableName, amount, from, to);
            var tx = TransactionCreator.SimpleSignedTransaction(
                new ITransactionEntry[] { moveCoin },
                new[] { Utils.GetUser0KeyPair().PrivateKey });
            await this.SendTransaction(tx);
            var result = await Utils.WaitTx(generalApi, tx.Id);
            return new Tuple<string, string>(tx.Id.ToString(), result);
        }

        /// <summary>
        /// show Asset of designated publickeyAddress
        /// </summary>
        /// <param name="client"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<decimal> ShowAsset()
        {
            var client = this.SetClient();
            var assetClient = new AssetClient(client);
            AssetTypesRegisterer.RegisterTypes();

            var myaddress = new PublicKeyAddress(Utils.GetUser0KeyPair());
            var result = await assetClient.GetAssetAsync(TableName, myaddress);
            return result.Value;
        }

        /// <summary>
        /// Send Transaction to miyabi blockchain
        /// </summary>
        /// <param name="tx"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendTransaction(Transaction tx)
         {
            var client = this.SetClient();
            var generalClient = new GeneralApi(client);

            try
            {
                var send = await generalClient.SendTransactionAsync(tx);
                var result_code = send.Value;

                if (result_code != TransactionResultCode.Success
                   && result_code != TransactionResultCode.Pending)
                {
                    // Console.WriteLine("取引が拒否されました!:\t{0}", result_code);
                }
            }
            catch (Exception)
            {
             // Console.Write("例外を検知しました！{e}");
            }
         }

        public Address GetAddress()
        {
            return new PublicKeyAddress(Utils.GetUser0KeyPair());
        }

         /// <summary>
         /// client set method.
         /// </summary>
         /// <returns>client</returns>
        public Client SetClient()
        {
            Client client;
            var config = new SdkConfig(Utils.ApiUrl);
            client = new Client(config);
            return client;
        }
    }
}