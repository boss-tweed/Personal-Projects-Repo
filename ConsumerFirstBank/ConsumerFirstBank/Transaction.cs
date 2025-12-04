using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerFirstBank
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public Transaction()
        {
            // Assign unique transaction id on creation
            TransactionId = UniqueIdGenerator.Instance.NextTransactionId();
        }

        
    }           
}
