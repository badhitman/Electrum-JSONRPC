////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
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
            public SummaryWalletHistoryResponseClass summary;

            [DataMember]
            public TransactionWalletHistoryResponseClass[] transactions;
        }

        [DataContract]
        public class SummaryWalletHistoryResponseClass
        {
            [DataMember]
            public string capital_gains;

            [DataMember]
            public string end_balance;

            [DataMember]
            public string end_date;

            [DataMember]
            public string expenditures;

            [DataMember]
            public string fiat_expenditures;

            [DataMember]
            public string fiat_income;

            [DataMember]
            public string income;

            [DataMember]
            public string start_balance;

            [DataMember]
            public string start_date;

            [DataMember]
            public string start_fiat_balance;

            [DataMember]
            public string start_fiat_value;

            [DataMember]
            public string unrealized_gains;

            public string InfoString
            {
                get
                {
                    return "Start: " + start_date + " {= " + start_balance + "}; End: " + end_date + " {= " + end_balance + "}. Income: " + income + "; Expenditures: " + expenditures + "; Capital_gains: " + capital_gains + "; Unrealized_gains: " + unrealized_gains + ";";
                }
            }
        }

        [DataContract]
        public class TransactionWalletHistoryResponseClass
        {
            [DataMember]
            public string acquisition_price;

            [DataMember]
            public string balance;

            [DataMember]
            public string capital_gain;

            [DataMember]
            public long confirmations;

            [DataMember]
            public string date;

            [DataMember]
            public bool? fiat_default;

            [DataMember]
            public string fiat_value;

            [DataMember]
            public long height;

            [DataMember]
            public TransactionWalletHistoryResponseInputsClass[] inputs;

            [DataMember]
            public string label;

            [DataMember]
            public TransactionWalletHistoryResponseOutputsClass[] outputs;

            [DataMember]
            public long timestamp;

            [DataMember]
            public string txid;

            [DataMember]
            public string value;

            public double DoubleValue { get { return AbstractResponseClass.DoubleValue(value); } }

            public string InfoString
            {
                get
                {
                    return
                        "Tx: " + balance +
                        "; Confirmations: " + confirmations +
                        "; Date: " + date +
                        "; Height: " + height +
                        "; Label: " + label +
                        "; Timestamp: " + timestamp +
                        "; Txid: " + txid +
                        "; Value: " + value + " {double=" + DoubleValue + "}";
                }
            }

            public class TransactionWalletHistoryResponseInputsClass
            {
                [DataMember]
                public string prevout_hash;

                [DataMember]
                public int prevout_n;
            }

            public class TransactionWalletHistoryResponseOutputsClass
            {
                [DataMember]
                public string address;

                [DataMember]
                public string value;

                public double DoubleValue { get { return AbstractResponseClass.DoubleValue(value); } }
            }
        }
    }
}
