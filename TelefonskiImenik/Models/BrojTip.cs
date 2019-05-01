using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonskiImenik.Models
{
    [Table("BrojTip")] // vezanje klase na tablicu u bazi
    public class BrojTip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Naziv { get; set; }
    }
}