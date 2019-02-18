////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using MultiTool.LibraryLog;
using System;

namespace ElectrumJSONRPC
{
    class Program
    {
        public static LogClass Log = new LogClass();
        static void Main(string[] args)
        {
            Console.WriteLine();
            Log.Write(" *** Electrum \"JSONRPC (for ver. 3.2.2)\" - testing! *** ", LogStatusEnum.Norma);
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Electrum_JSONRPC_Client client = new Electrum_JSONRPC_Client("user", "user", "http://127.0.0.1", 7777);
            
            client.GetElectrumVersion();
            client.GetBalanceWallet();
            client.CreateNewAddress();
            client.GetListWalletAddresses();
            client.GetTransactionsHistoryWallet(true, true);
            

            client.IsAddressMine(null);
            client.ValidateAddress("");
        }
    }
}
