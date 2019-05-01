using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TelefonskiImenik.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Osoba> Osobe { get; set; }

        public DbSet<BrojTip> BrojTipovi { get; set; }

        public DbSet<BrojeviOsoba> BrojeviOsobe { get; set; }

        public DbSet<Grad> Grad { get; set; }

        public ApplicationDbContext()
                : base("TelefonskiImenik", throwIfV1Schema: false)
        {
        }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
    }
}