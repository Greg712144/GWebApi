using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The Primary Key of Account
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Foreign Key of Account
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Name of Account
        /// </summary>
        [MaxLength(40), MinLength(5)]
        public string Name { get; set; }

        /// <summary>
        /// The Account's Initial Balance
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal InitialBalance { get; set; }

        /// <summary>
        /// The Account's Current Balance
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// The Account's Reconciled Balance
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal ReconciledBalance { get; set; }

        /// <summary>
        /// The Account's Lowlevel Balance
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal LowBalanceLevel { get; set; }

    }
}