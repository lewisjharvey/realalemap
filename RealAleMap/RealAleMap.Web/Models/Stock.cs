using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealAleMap.Web.Models
{
    /// <summary>
    /// Represents someone reporting a beer at a venue.
    /// </summary>
    public class Stock
    {
        [Key]
        public long StockId { get; set; }

        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>
        /// The venue identifier.
        /// </value>
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>
        /// The venue.
        /// </value>
        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        /// <summary>
        /// Gets or sets the beer identifier.
        /// </summary>
        /// <value>
        /// The beer identifier.
        /// </value>
        [Display(Name = "Beer")]
        public int BeerId { get; set; }

        /// <summary>
        /// Gets or sets the beer.
        /// </summary>
        /// <value>
        /// The beer.
        /// </value>
        [ForeignKey("BeerId")]
        public virtual Beer Beer { get; set; }

        /// <summary>
        /// Gets or sets the reported time.
        /// </summary>
        /// <value>
        /// The reported time.
        /// </value>
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ReportedTime { get; set; }

        [Required]
        public string UserId { get; set; }

        // ForeignKey => dbo.IdentityUser
        [Display(Name = "Drinker")]
        [Required(ErrorMessage = "Please select a drinker who reported the stocking.")]
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}