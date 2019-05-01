using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonskiImenik.Models
{
    [Table("Osoba")]
    public class Osoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public Guid GradId { get; set; }

        public virtual Grad Grad { get; set; }

        [MaxLength(255)]
        public string Opis { get; set; }

        public byte[] Slika { get; set; }

        public string UserId { get; set; }
    }
}