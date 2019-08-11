////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using ElectrumJSONRPC.Response.Model;
using LibraryLog;
using System;

namespace ElectrumJSONRPC
{
    class Program
    {
        public static LogClass Log = new LogClass();
        static void Main(string[] args)
        {
            Console.WriteLine();
            Log.Write(" *** Electrum \"JSONRPC (for ver. 3.3.8)\" - testing! *** ", LogStatusEnum.Norma);
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Electrum_JSONRPC_Client client = new Electrum_JSONRPC_Client("user", "user", "http://127.0.0.1", 7777);

            SimpleStringResponseClass response = client.GetElectrumVersion();
            BalanceResponseClass balance = client.GetBalanceWallet();
            response = client.CreateNewAddress();
            object walet_addresses = client.GetListWalletAddresses();
            WalletTransactionsHistoryResponseClass  wallet_transactions_history = client.GetTransactionsHistoryWallet(true, true);


            SimpleBoolResponseClass bool_response = client.IsAddressMine(null);
            bool_response = client.ValidateAddress("");
        }
    }
}
