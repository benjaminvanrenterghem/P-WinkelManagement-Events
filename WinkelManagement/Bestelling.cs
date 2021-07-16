using System;
using WinkelManagementCL.resources;

namespace WinkelManagementCL
{
    public class Bestelling
    {
        private Validaties Validaties = new Validaties();

        /// <summary>
        /// maakt gebruik van de klasse Validaties om aspirant property content goed te keuren alvorens deze te setten
        /// Bevat 2 ctors, prijs en adres zijn irrelevant indien het gaat om een groothandelaar zijn bestelling
        /// </summary>

        // gebruik door de groothandelaar
        public Bestelling(ProductType product, int aantal)
        {
            Product = product;
            Aantal = aantal;
        }

        // gebruik door de winkel
        public Bestelling(ProductType product, decimal prijs, int aantal, string adres)
        {
            Product = product;
            Prijs = prijs;
            Aantal = aantal;
            Adres = adres;
        }

        private decimal _prijs;
        private int _aantal;
        private string _adres;
        /// <summary>
        /// valideert adhv validaties, maakt van verkorte notatie gebruik waar mogelijk (get;set;)
        /// maakt gebruik van private properties om StackOverflow te voorkomen https://stackoverflow.com/questions/32977482/stackoverflow-exception-from-get-and-set
        /// </summary>
        public ProductType Product { get; set; } //< auto validatie door enum 
        public decimal Prijs { get { return _prijs; } set { _prijs = (value >= Validaties.minimumBedragBestelling) ? value : throw new ArgumentException($"Het minimum bedrag voor een bestelling is {Validaties.minimumBedragBestelling}"); } }
        public int Aantal { get { return _aantal; } set { _aantal = (value >= Validaties.minimumAantalBestelling) ? value : throw new ArgumentException($"Het minimum aantal bij een bestelling is {Validaties.minimumAantalBestelling}"); } }
        public string Adres { get { return _adres; } set { _adres = (value.Length >= Validaties.minimumLengteAdres) ? value : throw new ArgumentException($"De minimum lengte voor een adres is {Validaties.minimumLengteAdres} karakters"); } }

        /// <summary>
        /// laat toe om obj.ToString() te callen en een direct overzicht te hebben over de staat van het object 
        /// maakt onderscheid tussen een call voortkomend door een winkelbestelling / groothandelaar's bestelling dmv null check
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string fstr;

            if(Adres is null)
            {
                fstr = $"Product type: {Product}, Aantal: {Aantal}";
            } else
            {
                fstr = $"Product type: {Product}, Prijs: {Prijs}, Aantal: {Aantal}, Adres: {Adres}";
            }

            Console.WriteLine(fstr);
            return fstr;
        }
    }
}
