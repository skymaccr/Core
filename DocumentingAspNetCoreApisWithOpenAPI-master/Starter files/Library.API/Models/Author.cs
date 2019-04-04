using System;
using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    /// <summary>
    /// Class to manage the Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}
