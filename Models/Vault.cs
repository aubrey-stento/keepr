using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class VaultKeep
    {
        public int Id { get; set; }
        [Required]
        public int VaultId { get; set; }
        [Required]
        public int KeepId { get; set; }
        public string UserId { get; set; }
    }
}