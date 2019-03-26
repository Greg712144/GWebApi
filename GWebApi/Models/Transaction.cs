using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The Primary Key of the Transaction
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Foreign Key of a Transaction
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Another Foreign Key of a Transaction
        /// </summary>
        public int BudgetItemId { get; set; }

        /// <summary>
        /// The User who Entered the Transaction
        /// </summary>
        public string EnteredById { get; set; }

        /// <summary>
        /// The Description of the Transaction
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Date of the Transaction
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Amount of the Transaction
        /// </summary>
        public Decimal Amount { get; set; }

        /// <summary>
        /// The Type of Transaction being done
        /// </summary>
        //When pulling Enum of data from the db I want to see the actual type and nit the int that represents it ..
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Whether the transaction has been Reconciled
        /// </summary>
        public bool Reconciled { get; set; }

        /// <summary>
        /// The Reconciled Amount of the Transaction
        /// </summary>
        public decimal? ReconciledAmount { get; set; }

      
    }
}