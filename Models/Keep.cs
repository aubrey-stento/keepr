using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public bool IsPrivate { get; set; }


    }
}