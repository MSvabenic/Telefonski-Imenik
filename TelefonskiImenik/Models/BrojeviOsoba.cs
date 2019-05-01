using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelefonskiImenik.Models
{
    [Table("BrojeviOsoba")]
    public class BrojeviOsoba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        public Guid OsobaId { get; set; }

        public virtual Osoba Osoba{ get; set; }

        [Required]
        public Guid BrojTipId { get; set; }

        public virtual BrojTip BrojTip { get; set; }

        [Required]
        public string Broj { get; set; }

        public string Opis { get; set; }
    }
}