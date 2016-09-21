using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealAleMap.Web.Models
{
    /// <summary>
    /// Represents a beer.
    /// </summary>
    public class Beer
    {
        /// <summary>
        /// Gets or sets the beer identifier.
        /// </summary>
        /// <value>
        /// The beer identifier.
        /// </value>
        [Key]
        public int BeerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the brewery identifier.
        /// </summary>
        /// <value>
        /// The brewery identifier.
        /// </value>
        [Display(Name = "Brewery")]
        public int BreweryId { get; set; }

        /// <summary>
        /// Gets or sets the brewery.
        /// </summary>
        /// <value>
        /// The brewery.
        /// </value>
        [ForeignKey("BreweryId")]
        public virtual Brewery Brewery { get; set; }
    }
}