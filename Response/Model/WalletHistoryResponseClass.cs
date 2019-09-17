////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    /// <summary>
    /// Объект истории кошелька
    /// </summary>
    [DataContract]
    public class WalletTransactionsHistoryResponseClass : AbstractResponseClass
    {
        /// <summary>
        /// Результат выполнения JSONRPC запроса истории кошелька
        /// </summary>
        [DataMember]
        public ResultWalletHistoryResponseClass result;
    }

    /// <summary>
    /// Результат выполнения JSONRPC запроса истории кошелька
    /// </summary>
    [DataContract]
    public class ResultWalletHistoryResponseClass
    {
        /// <summary>
        /// Список транзакций истории кошелька
        /// </summary>
        [DataMember]
        public TransactionWalletHistoryResponseClass[] transactions;

        /// <summary>
        /// Сводка по истории кошелька
        /// </summary>
        [DataMember]
        public SummaryWalletHistoryResponseClass summary;
    }

    /// <summary>
    /// Объект конкретной транзакции из истории кошелька.
    /// Сводка по танзакции, а также входы и выходы
    /// </summary>
    [DataContract]
    public class TransactionWalletHistoryResponseClass
    {
        [DataMember]
        public string balance;

        [DataMember]
        public long? confirmations;

        [DataMember]
        public string date;

        [DataMember]
        public string fee;

        [DataMember]
        public long? timestamp;

        [DataMember]
        public string label;

        [DataMember]
        public bool? incoming;

        [DataMember]
        public string txid;

        /// <summary>
        /// Block height
        /// </summary>
        [DataMember]
        public long? height;

        [DataMember]
        public string value;

        /// <summary>
        /// Transaction ID
        /// </summary>
        [DataMember]
        public string txpos_in_block;

        /// <summary>
        /// Вход(ы) транзакции
        /// </summary>
        [DataMember]
        public TransactionWalletHistoryResponseInputsClass[] inputs;

        /// <summary>
        /// Выход(ы) транзакции
        /// list of ["address", amount]
        /// </summary>
        [DataMember]
        public TransactionWalletHistoryResponseOutputsClass[] outputs;

        public override string ToString() =>
                "balance [" + balance + "]" + System.Environment.NewLine +
                "confirmations [" + confirmations + "]" + System.Environment.NewLine +
                "date [" + date + "]" + System.Environment.NewLine +
                "fee [" + fee + "]" + System.Environment.NewLine +
                "timestamp [" + timestamp + "]" + System.Environment.NewLine +
                "label [" + label + "]" + System.Environment.NewLine +
                "incoming [" + incoming + "]" + System.Environment.NewLine +
                "txid [" + txid + "]" + System.Environment.NewLine +
                "height [" + height + "]" + System.Environment.NewLine +
                "value [" + value + "]" + System.Environment.NewLine +
                "txpos_in_block [" + txpos_in_block + "]";
    }

    /// <summary>
    /// Сводная информация истории/отчёта кошелька
    /// </summary>
    [DataContract]
    public class SummaryWalletHistoryResponseClass
    {
        [DataMember]
        public string start_date;

        [DataMember]
        public string end_date;

        [DataMember]
        public long? from_height;

        [DataMember]
        public long? to_height;

        [DataMember]
        public string start_balance;

        [DataMember]
        public string end_balance;

        /// <summary>
        /// Сумма поступлений
        /// </summary>
        [DataMember]
        public string incoming;

        /// <summary>
        /// Сумма расхода
        /// </summary>
        [DataMember]
        public string outgoing;

        #region fiat
        [DataMember]
        public string fiat_currency;

        [DataMember]
        public string fiat_capital_gains;

        [DataMember]
        public string fiat_incoming;

        [DataMember]
        public string fiat_outgoing;

        [DataMember]
        public string fiat_unrealized_gains;

        [DataMember]
        public string fiat_start_balance;

        [DataMember]
        public string fiat_end_balance;

        [DataMember]
        public string fiat_start_value;

        [DataMember]
        public string fiat_end_value;
        #endregion
    }

    /// <summary>
    /// Вход транзакции
    /// </summary>
    public class TransactionWalletHistoryResponseInputsClass
    {
        [DataMember]
        public string prevout_hash;

        [DataMember]
        public int prevout_n;
    }

    /// <summary>
    /// Выход транзакции
    /// </summary>
    public class TransactionWalletHistoryResponseOutputsClass
    {
        /// <summary>
        /// Bitcoin address
        /// </summary>
        [DataMember]
        public string address;

        [DataMember]
        public string value;

        public override string ToString()
        {
            return "[address:" + address + "][value:" + value + "]";
        }
    }

}
