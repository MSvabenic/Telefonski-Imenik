using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class GradViewModel
    {
        [Required(ErrorMessage = "Naziv je obvezan za unos.")]
        public string Naziv { get; set; }

        public string Opis { get; set; }
    }
}
