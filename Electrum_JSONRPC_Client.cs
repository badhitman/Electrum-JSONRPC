////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using ElectrumJSONRPC.Request;
using ElectrumJSONRPC.Request.Methods;
using ElectrumJSONRPC.Request.Methods.Address;
using ElectrumJSONRPC.Request.Methods.Payment;
using ElectrumJSONRPC.Request.Methods.Wallet;
using ElectrumJSONRPC.Response.Model;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace ElectrumJSONRPC
{

    public class Electrum_JSONRPC_Client
    {
        #region properties

        /// <summary>
        /// JSONRPC Host
        /// </summary>
        public string host { get; protected set; } = "";

        /// <summary>
        /// JSONRPC Port
        /// </summary>
        public int port { get; protected set; } = 0;

        public string _method_ { get; protected set; }

        public string encoded_authorization { get; protected set; }

        /// <summary>
        /// JSONRPC User Name
        /// </summary>
        public string rpcUsername { get; protected set; } = null;

        /// <summary>
        /// JSONRPC Password
        /// </summary>
        public string rpcPassword { get; protected set; } = null;

        /// <summary>
        /// Last Message-ID
        /// </summary>
        public int request_id { get; protected set; } = 0;

        /// <summary>
        /// raw ответ от jsonrpc
        /// </summary>
        public string jsonrpc_response_raw { get; protected set; }

        #endregion

        public Electrum_JSONRPC_Client(string in_rpcUsername = null, string in_rpcPassword = null, string in_host = "http://127.0.0.1", int in_port = 7777, int in_id = 0)
        {
            host = in_host;
            port = in_port;
            rpcUsername = in_rpcUsername;
            rpcPassword = in_rpcPassword;
            request_id = in_id;
        }

        public string Execute(string method, NameValueCollection param_request)
        {
            json_request req = new json_request();
            //
            req.id = request_id++;
            req.method = method;
            req.Request_params = param_request;

            string request_json = req.ToString();

            _method_ = method;

            jsonrpc_response_raw = null;

            #region http web request
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(new Uri(host + ":" + port.ToString()));

            if (string.IsNullOrEmpty(encoded_authorization))
                encoded_authorization = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(rpcUsername + ":" + rpcPassword));

            http.Headers.Add("Authorization", "Basic " + encoded_authorization);

            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(request_json);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            try
            {
                HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    //Log.WriteLine("Ошибка! Код HTTP: " + response.StatusCode.ToString() + "; Описание: " + response.StatusDescription, LogStatusEnum.Alarm);
                }
                else
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);

                    jsonrpc_response_raw = sr.ReadToEnd().Replace(@"\n", "\n").Replace(@"\t", "\t").Replace(@"\r", "\r").Replace(@"\""", "\"").Replace(@"""{", "{").Replace(@"}""", "}"); //  //.Replace("\\\t", "\t").Replace("\\\n", "\n").Replace("\\\r", "\r");
                }
            }
            catch (Exception e)
            {
                //Log.WriteLine("Ошибка HTTP запроса: " + e.Message, LogStatusEnum.Alarm);
            }
            #endregion

            return jsonrpc_response_raw;
        }

        /// <summary>
        /// Получить историю биткоин адреса
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns></returns>
        public AddressHistoryResponseClass GetAddressHistory(string address)
        {
            GetAddressHistoryMethodClass getAddressHistoryMethodClass = new GetAddressHistoryMethodClass(this)
            {
                address = address
            };

            AddressHistoryResponseClass addressHistoryResponseClass = (AddressHistoryResponseClass)getAddressHistoryMethodClass.execute();

            return addressHistoryResponseClass;
        }

        /// <summary>
        /// Получить список адресов кошелька
        /// </summary>
        public object GetListWalletAddresses(bool? show_balance = null, bool? show_labels = null, bool? filter_receiving = null, bool? filter_change = null, bool? filter_frozen = null, bool? filter_unused = null, bool? filter_funded = null)
        {
            GetListWalletAddressesMethodClass electrum_list_addresses_method = new GetListWalletAddressesMethodClass(this)
            {
                receiving = filter_receiving,
                change = filter_change,
                frozen = filter_frozen,
                unused = filter_unused,
                funded = filter_funded,

                balance = show_balance,
                labels = show_labels
            };

            object list_addresses = electrum_list_addresses_method.execute();

            /*if (list_addresses != null)
            {
                if (list_addresses is SimpleStringArrayArrayResponseClass)
                {
                   
                }

            }*/

            return list_addresses;
        }

        /// <summary>
        /// Создать новый Биткоин адрес
        /// </summary>
        public SimpleStringResponseClass CreateNewAddress()
        {
            CreateNewAddressMethodClass createNewAddressMethodClass = new CreateNewAddressMethodClass(this);
            SimpleStringResponseClass simpleStringResponseClass = (SimpleStringResponseClass)createNewAddressMethodClass.execute();

            return simpleStringResponseClass;
        }

        /// <summary>
        /// Запрос баланса кошелька
        /// </summary>
        public BalanceResponseClass GetBalanceWallet()
        {
            GetBalanceWalletMethodClass getBalanceWalletMethodClass = new GetBalanceWalletMethodClass(this);
            BalanceResponseClass balanceResponseClass = (BalanceResponseClass)getBalanceWalletMethodClass.execute();
            if (balanceResponseClass != null)
                if (balanceResponseClass.result.unconfirmed == null)
                    balanceResponseClass.result.unconfirmed = "0";

            return balanceResponseClass;
        }

        /// <summary>
        /// Запрашиваем версию Electrum
        /// </summary>
        public SimpleStringResponseClass GetElectrumVersion()
        {
            VersionMethodClass versionMethodClass = new VersionMethodClass(this);
            SimpleStringResponseClass simpleStringResponseClass = (SimpleStringResponseClass)versionMethodClass.execute();

            return simpleStringResponseClass;
        }

        /// <summary>
        /// Проверка принадлежности адреса кошельку
        /// </summary>
        /// <param name="check_address">Проверяемы адрес</param>
        public SimpleBoolResponseClass IsAddressMine(string check_address)
        {
            if (check_address == null)
                check_address = "";

            SimpleBoolResponseClass simpleBoolResponseClass = ValidateAddress(check_address);
            if (simpleBoolResponseClass == null)
                return null;

            IsAddressMineMethodClass isAddressMineMethodClass = new IsAddressMineMethodClass(this) { address = check_address };
            simpleBoolResponseClass = (SimpleBoolResponseClass)isAddressMineMethodClass.execute();

            return simpleBoolResponseClass;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreatePaymentRequest()
        {
            CreatePaymentRequestMethodClass create_payment_request_method_class = new CreatePaymentRequestMethodClass(this) { amount = 5, expiration = 60 * 60, force = true, memo = "test" };
            create_payment_request_method_class.execute();
        }

        /// <summary>
        /// Получить историю транзакций кошелька
        /// </summary>
        /// <param name="year">Год отчёта</param>
        /// <param name="show_addresses">Отобразить в результате запроса адреса IN & OUT</param>
        /// <param name="show_fiat">Отобразить суммы</param>
        public WalletTransactionsHistoryResponseClass GetTransactionsHistoryWallet(bool? show_addresses = null, bool? show_fiat = null, bool show_fees = false, int? year = null, long? from_height = null, long? to_height = null)
        {
            GetTransactionsHistoryWalletMethodClass electrum_history_transaction_method = new GetTransactionsHistoryWalletMethodClass(this)
            {
                year = year,
                show_addresses = show_addresses,
                show_fiat = show_fiat,
                show_fees = show_fees,
                from_height = from_height,
                to_height = to_height
            };
            WalletTransactionsHistoryResponseClass walletHistory = (WalletTransactionsHistoryResponseClass)electrum_history_transaction_method.execute();

            return walletHistory;
        }

        /// <summary>
        /// Получить транзакцию
        /// </summary>
        /// <param name="txid">Transaction ID</param>
        public GetTransactionResponseClass GetTransaction(string txid)
        {
            GetTransactionMethodClass getTransactionMethodClass = new GetTransactionMethodClass(this)
            {
                txid = txid
            };

            GetTransactionResponseClass getTransactionResponseClass = (GetTransactionResponseClass)getTransactionMethodClass.execute();

            return getTransactionResponseClass;
        }

        /// <summary>
        /// Получить баланс адреса
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        public BalanceResponseClass GetAddressBalance(string address)
        {
            GetAddressBalanceMethodClass getAddressBalanceMethodClass = new GetAddressBalanceMethodClass(this)
            {
                address = address
            };
            BalanceResponseClass balanceResponseClass = (BalanceResponseClass)getAddressBalanceMethodClass.execute();

            return balanceResponseClass;
        }

        /// <summary>
        /// Проверка правильности адреса
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        public SimpleBoolResponseClass ValidateAddress(string address)
        {
            if (address == null)
                address = "";

            ValidateAddressMethodClass validateAddressMethodClass = new ValidateAddressMethodClass(this) { address = address };
            SimpleBoolResponseClass simpleBoolResponseClass = (SimpleBoolResponseClass)validateAddressMethodClass.execute();

            return simpleBoolResponseClass;
        }
    }
}
