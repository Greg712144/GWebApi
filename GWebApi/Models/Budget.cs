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
    public class Budget
    {
        /// <summary>
        /// The Primary Key of the Budget
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Foreign key of the Budget
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// The Name of the Budget
        /// </summary>
        [MaxLength(40), MinLength(5)]
        public string Name { get; set; }


        /// <summary>
        /// The Description of the Budget
        /// </summary>
        [MaxLength(200), MinLength(5)]
        public string Description { get; set; }
    }
}