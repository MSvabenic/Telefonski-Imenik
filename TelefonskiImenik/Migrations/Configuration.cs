namespace TelefonskiImenik.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelefonskiImenik.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.BrojTipovi.AddOrUpdate(
                new BrojTip { Naziv = "Kućni" },
                new BrojTip { Naziv = "Mobitel" },
                new BrojTip { Naziv = "Posao" }
                );

            context.Grad.AddOrUpdate(
                new Grad { Naziv = "Zagreb", Opis = "Opis grada Zagreba"},
                new Grad { Naziv = "Split", Opis = "Opis grada Splita" },
                new Grad { Naziv = "Frankfurt", Opis = "Opis grada Frankfurta" },
                new Grad { Naziv = "Varaždin", Opis = "Opis grada Varaždina" }
                );
        }
    }
}
