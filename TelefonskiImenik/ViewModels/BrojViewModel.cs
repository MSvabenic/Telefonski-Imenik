using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TelefonskiImenik.Models;

namespace Models.ViewModels
{
    public class BrojViewModel
    {
        [DisplayName("Osoba")]
        [Required(ErrorMessage = "Obvezno je odabrati osobu.")]
        public Guid OsobaId { get; set; }

        [DisplayName("Tip broja telefona")]
        [Required(ErrorMessage ="Tip broja je obvezan za unos.")]
        public Guid BrojTip { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Dozvoljeni su samo brojevi!")]
        [Required(ErrorMessage = "Broj je obvezan za unos.")]
        public string Broj { get; set; }

        [DisplayName("Opis broja")]
        public string OpisBroja { get; set; }
    }
}
