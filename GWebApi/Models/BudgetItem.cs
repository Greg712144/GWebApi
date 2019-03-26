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
    public class BudgetItem
    {
        /// <summary>
        /// The Primary key of the BudgetItem
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Foreign Key of the BudgetItem
        /// </summary>
        public int? BudgetId { get; set; }

        /// <summary>
        /// The Name of the BudgetItem
        /// </summary>
        [MaxLength(40), MinLength(5)]
        public string Name { get; set; }

        /// <summary>
        /// The Description of the BudgetItem
        /// </summary>
        [MaxLength(200), MinLength(5)]
        public string Description { get; set; }

        /// <summary>
        /// The Target Amount for Specified BudgetItem
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal TargetAmount { get; set; }

        /// <summary>
        /// The Current Amount for Specified BudgetItem
        /// </summary>
        [Range(0.00, 100000.00)]
        public decimal CurrentAmount { get; set; }

    }
}