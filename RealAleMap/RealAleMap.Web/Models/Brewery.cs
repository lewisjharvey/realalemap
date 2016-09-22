using System.ComponentModel.DataAnnotations;

namespace RealAleMap.Web.Models
{
    /// <summary>
    /// Represents a brewery.
    /// </summary>
    public class Brewery
    {
        /// <summary>
        /// Gets or sets the brewery identifier.
        /// </summary>
        /// <value>
        /// The brewery identifier.
        /// </value>
        [Key]
        public int BreweryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}