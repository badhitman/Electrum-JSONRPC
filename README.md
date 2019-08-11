# Electrum JSONRPC Client .NET Core C#

Разработка неоконченная. Полноценную реализацию имеют только некоторые jsonrpc методы, которые описаны в Electrum_JSONRPC_Client.
Впрочем сигнатуры запросов имеют законченый вид. Доделывания требуют только сигнатуры JSON-RPC ответов.

```C#
Electrum_JSONRPC_Client client = new Electrum_JSONRPC_Client("user", "user", "http://127.0.0.1", 7777);

SimpleStringResponseClass response = client.GetElectrumVersion();
BalanceResponseClass balance = client.GetBalanceWallet();
response = client.CreateNewAddress();
object walet_addresses = client.GetListWalletAddresses();
WalletTransactionsHistoryResponseClass  wallet_transactions_history = client.GetTransactionsHistoryWallet(true, true);

SimpleBoolResponseClass bool_response = client.IsAddressMine(null);
bool_response = client.ValidateAddress("");
```