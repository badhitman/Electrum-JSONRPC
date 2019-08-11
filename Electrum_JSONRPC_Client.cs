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
        private String encoded_authorization;
        private string _method_;

        /// <summary>
        /// JSONRPC Host
        /// </summary>
        protected string host = "";

        /// <summary>
        /// JSONRPC Port
        /// </summary>
        protected int port = 0;

        /// <summary>
        /// JSONRPC User Name
        /// </summary>
        protected string rpcUsername = null;

        /// <summary>
        /// JSONRPC Password
        /// </summary>
        protected string rpcPassword = null;

        /// <summary>
        /// Last Message-ID
        /// </summary>
        protected int request_id = 0;

        public Electrum_JSONRPC_Client(string in_rpcUsername = null, string in_rpcPassword = null, string in_host = "http://127.0.0.1", int in_port = 7777, int in_id = 0)
        {
            //Log.WriteLine("Инициализация клиента.", LogStatusEnum.Norma);
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
            // Create request payload
            string request_json = req.ToString();

            _method_ = method;
            // Retrieve electrum api response
            string response = ExecuteRequest(request_json);

            return response;
        }


        private string ExecuteRequest(string post_json_param_request)
        {
            //Log.WriteLine("-> " + post_json_param_request, LogStatusEnum.Trace);
            //
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(new Uri(host + ":" + port.ToString()));
            //http.Credentials = GetCredential();
            if (string.IsNullOrEmpty(encoded_authorization))
                encoded_authorization = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(rpcUsername + ":" + rpcPassword));

            http.Headers.Add("Authorization", "Basic " + encoded_authorization);

            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(post_json_param_request);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            string content = null;
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

                    content = sr.ReadToEnd().Replace(@"\n", "\n").Replace(@"\t", "\t").Replace(@"\r", "\r").Replace(@"\""", "\"").Replace(@"""{", "{").Replace(@"}""", "}"); //  //.Replace("\\\t", "\t").Replace("\\\n", "\n").Replace("\\\r", "\r");
                    //Log.WriteLine("<-" + content, LogStatusEnum.Trace);
                }
            }
            catch (Exception e)
            {
                //Log.WriteLine("Ошибка HTTP запроса: " + e.Message, LogStatusEnum.Alarm);
            }
            return content;
        }

        /// <summary>
        /// Получить историю биткоин адреса
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        /// <returns></returns>
        public AddressHistoryResponseClass GetAddressHistory(string address)
        {
            //Log.WriteLine("Запрос истории адреса биткоин ...", LogStatusEnum.Norma);
            GetAddressHistoryMethodClass getAddressHistoryMethodClass = new GetAddressHistoryMethodClass(this)
            {
                address = address
            };

            AddressHistoryResponseClass addressHistoryResponseClass = (AddressHistoryResponseClass)getAddressHistoryMethodClass.execute();
            if (addressHistoryResponseClass == null)
            {
                // Log.WriteLine("Результат запроса истории адреса биткоин NULL", LogStatusEnum.Alarm);
            }

            return addressHistoryResponseClass;
        }

        /// <summary>
        /// Получить список адресов кошелька
        /// </summary>
        public object GetListWalletAddresses(bool? show_balance = null, bool? show_labels = null, bool? filter_receiving = null, bool? filter_change = null, bool? filter_frozen = null, bool? filter_unused = null, bool? filter_funded = null)
        {
            //Log.WriteLine("Получаем список адресов кошелька ...", LogStatusEnum.Norma);
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

            if (list_addresses != null)
            {
                //Log.WriteLine("Список адресов кошелька: ", LogStatusEnum.Norma);
                if (list_addresses is SimpleStringArrayArrayResponseClass)
                {
                    //Log.WriteLine("Формат string[][]", LogStatusEnum.Norma);
                    int i = 0;
                    foreach (string[] s_arr in ((SimpleStringArrayArrayResponseClass)list_addresses).result)
                    {
                        i++;
                        //Log.WriteLine("     " + i.ToString() + "] " + s_arr.ToString(), LogStatusEnum.Norma);
                    }
                }
                else
                {
                    //Log.WriteLine("Формат string[]", LogStatusEnum.Norma);
                    int i = 0;
                    foreach (string s in ((SimpleStringArrayResponseClass)list_addresses).result)
                    {
                        i++;
                        //Log.WriteLine("     " + i.ToString() + "] " + s.ToString(), LogStatusEnum.Norma);
                    }
                }

            }
            else
            {
                //Log.WriteLine("Результат запроса списка адресов кошелька = NULL", LogStatusEnum.Alarm);
            }
            //LogSeparate();
            return list_addresses;
        }

        /// <summary>
        /// Создать новый Биткоин адрес
        /// </summary>
        public SimpleStringResponseClass CreateNewAddress()
        {
            //Log.Write("Создаётся новый BTC адрес ...", LogStatusEnum.Norma);
            CreateNewAddressMethodClass createNewAddressMethodClass = new CreateNewAddressMethodClass(this);
            SimpleStringResponseClass simpleStringResponseClass = (SimpleStringResponseClass)createNewAddressMethodClass.execute();
            if (simpleStringResponseClass != null)
            {
                //Log.Write("Новый BTC адрес: " + simpleStringResponseClass.result, LogStatusEnum.Norma);
            }
            else
            {
                //Log.Write("Результат запроса нового BTC адреса = NULL", LogStatusEnum.Alarm);
            }

            return simpleStringResponseClass;
        }

        /// <summary>
        /// Запрос баланса кошелька
        /// </summary>
        public BalanceResponseClass GetBalanceWallet()
        {
            //Log.Write("Запрашиваем баланс кошелька ...", LogStatusEnum.Norma);
            GetBalanceWalletMethodClass getBalanceWalletMethodClass = new GetBalanceWalletMethodClass(this);
            BalanceResponseClass balanceResponseClass = (BalanceResponseClass)getBalanceWalletMethodClass.execute();
            if (balanceResponseClass != null)
            {
                if (balanceResponseClass.result.unconfirmed == null)
                    balanceResponseClass.result.unconfirmed = "0";

                //Log.Write("Баланс кошелька: confirmed: " + balanceResponseClass.result.confirmed + "; unconfirmed: " + balanceResponseClass.result.unconfirmed + ";", LogStatusEnum.Norma);
            }
            else
            {
                //Log.Write("Результат запроса баланса кошелька = NULL", LogStatusEnum.Alarm);
            }

            return balanceResponseClass;
        }

        /// <summary>
        /// Запрашиваем версию Electrum
        /// </summary>
        public SimpleStringResponseClass GetElectrumVersion()
        {
            //Log.Write("Запрашиваем версию Electrum ...", LogStatusEnum.Norma);
            VersionMethodClass versionMethodClass = new VersionMethodClass(this);
            SimpleStringResponseClass simpleStringResponseClass = (SimpleStringResponseClass)versionMethodClass.execute();
            if (simpleStringResponseClass != null)
            {
                //Log.Write("Electrum version: " + simpleStringResponseClass.result, LogStatusEnum.Norma);
                if (simpleStringResponseClass.result != "3.1.3")
                {
                    // Log.Write("Версия отличается от той для которой писалась программа (3.1.3)!", LogStatusEnum.Alarm);
                }
            }
            else
            {
                //Log.Write("Результат запроса версии сервера = NULL", LogStatusEnum.Alarm);
            }

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


            //Log.Write("Проверяем принадлежность адреса кошельку [" + check_address + "] ...", LogStatusEnum.Norma);

            SimpleBoolResponseClass simpleBoolResponseClass = ValidateAddress(check_address);
            if (simpleBoolResponseClass == null || !simpleBoolResponseClass.result)
            {
                //Log.Write("Адрес не корректный!", LogStatusEnum.Alarm);

                return simpleBoolResponseClass;
            }

            IsAddressMineMethodClass isAddressMineMethodClass = new IsAddressMineMethodClass(this) { address = check_address };
            simpleBoolResponseClass = (SimpleBoolResponseClass)isAddressMineMethodClass.execute();
            if (simpleBoolResponseClass != null)
            {
                //Log.Write("BTC адрес [" + check_address + "] " + (simpleBoolResponseClass.result ? "принадлежит кошельку" : "НЕ принадлежит кошельку"), LogStatusEnum.Norma);

            }
            else
            {
                //Log.Write("Результат проверки принадлежности адреса [" + check_address + "] = NULL", LogStatusEnum.Alarm);
            }
            return simpleBoolResponseClass;
        }

        public void CreatePaymentRequest()
        {
            CreatePaymentRequestMethodClass create_payment_request_method_class = new CreatePaymentRequestMethodClass(this) { amount = 5, expiration = 60*60, force = true, memo = "test" };
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
            //Log.Write("Получаем историю транзакций кошелька ...", LogStatusEnum.Norma);
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

            if (walletHistory != null)
            {
                //Log.Write("Отчёт по транзакциям [" + walletHistory.result.summary.InfoString + "]: ", LogStatusEnum.Norma);
                //


                for (int i = 0; i < walletHistory.result.transactions.Length; i++)
                {
                    //Log.Write("      " + i.ToString() + "] " + walletHistory.result.transactions[i].InfoString, LogStatusEnum.Norma);
                }
            }
            else
            {
                //Log.Write("Результат запроса истории транзакций кошелька = NULL", LogStatusEnum.Alarm);
            }
            return walletHistory;
        }

        /// <summary>
        /// Получить транзакцию
        /// </summary>
        /// <param name="txid">Transaction ID</param>
        public GetTransactionResponseClass GetTransaction(string txid)
        {
            //Log.Write("Получаем транзакцию [" + txid + "] ...", LogStatusEnum.Norma);
            GetTransactionMethodClass getTransactionMethodClass = new GetTransactionMethodClass(this)
            {
                txid = txid
            };
            GetTransactionResponseClass getTransactionResponseClass = (GetTransactionResponseClass)getTransactionMethodClass.execute();
            if (getTransactionResponseClass != null)
            {
                //Log.Write("final:" + getTransactionResponseClass.result.final.ToString() + "; hex:" + getTransactionResponseClass.result.hex + "; complete:" + getTransactionResponseClass.result.complete, LogStatusEnum.Norma);
            }
            else
            {
                //Log.Write("Результат запроса транзакции = NULL", LogStatusEnum.Alarm);
            }
            return getTransactionResponseClass;
        }

        /// <summary>
        /// Получить баланс адреса
        /// </summary>
        /// <param name="address">Bitcoin address</param>
        public BalanceResponseClass GetAddressBalance(string address)
        {

            //Log.Write("Запрос баланса адреса биткоин ...", LogStatusEnum.Norma);
            GetAddressBalanceMethodClass getAddressBalanceMethodClass = new GetAddressBalanceMethodClass(this)
            {
                address = address
            };
            BalanceResponseClass balanceResponseClass = (BalanceResponseClass)getAddressBalanceMethodClass.execute();
            if (balanceResponseClass != null)
            {

            }
            else
            {
                //Log.Write("Результат запроса баланса адреса биткоин = NULL", LogStatusEnum.Alarm);
            }
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

            //Log.Write("Проверяем корректность адреса биткоин [" + address + "] ...", LogStatusEnum.Norma);
            ValidateAddressMethodClass validateAddressMethodClass = new ValidateAddressMethodClass(this) { address = address };
            SimpleBoolResponseClass simpleBoolResponseClass = (SimpleBoolResponseClass)validateAddressMethodClass.execute();
            if (simpleBoolResponseClass != null)
            {
                //Log.Write("BTC адрес [" + address + "] кооректный", LogStatusEnum.Norma);
            }
            else
            {
                //Log.Write("Результат проверки корректности адреса биткоин = NULL", LogStatusEnum.Alarm);
            }
            return simpleBoolResponseClass;
        }
    }
}
