////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Electrum-3.3.8
////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;

namespace ElectrumJSONRPC.Response.Model
{
    [DataContract]
    public class WalletTransactionsHistoryResponseClass : AbstractResponseClass
    {
        [DataMember]
        public ResultWalletHistoryResponseClass result;

        [DataContract]
        public class ResultWalletHistoryResponseClass
        {
            [DataMember]
            public TransactionWalletHistoryResponseClass[] transactions;

            [DataMember]
            public SummaryWalletHistoryResponseClass summary;
        }

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

            [DataMember]
            public TransactionWalletHistoryResponseInputsClass[] inputs;

            /// <summary>
            /// list of ["address", amount]
            /// </summary>
            [DataMember]
            public TransactionWalletHistoryResponseOutputsClass[] outputs;

            public class TransactionWalletHistoryResponseInputsClass
            {
                [DataMember]
                public string prevout_hash;

                [DataMember]
                public int prevout_n;
            }

            public class TransactionWalletHistoryResponseOutputsClass
            {
                /// <summary>
                /// Bitcoin address
                /// </summary>
                [DataMember]
                public string address;

                [DataMember]
                public string value;
            }
        }

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
            /// Поступление
            /// </summary>
            [DataMember]
            public string incoming;

            /// <summary>
            /// Расход
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
    }
}
