using System;
using System.Collections.Generic;
using WinkelManagementCL.resources;

namespace WinkelManagementCL
{
    public class Verkoopafdeling
    {
        /// <summary>
        /// subscriber van 1 event
        /// </summary>

        // "Bestellingen worden bijgehouden per klant: de klant wordt geidentificeerd adhv zijn/haar adres"
        // { adres : List<Bestelling> }
        // om lokaal overzicht te bewaren op verkopen die plaatsvinden
        private Dictionary<string, List<Bestelling>> _rapport = new Dictionary<string, List<Bestelling>>();

        #region event handler 1/1
        public void OnProductVerkocht(object sender, WinkelEventArgs args)
        {
            // nieuwe bestelling toevoegen aan klant
            if (_rapport.ContainsKey(args.Bestelling.Adres))
            {
                _rapport[args.Bestelling.Adres].Add(args.Bestelling);
            } else
            {
                // nieuwe list init voor nieuwe klant
                _rapport[args.Bestelling.Adres] = new List<Bestelling> { args.Bestelling };
            }
        }
        #endregion

        #region overzichtsmethodes
        public void ToonRapport()
        {
            Console.WriteLine("Rapport Verkoopsafdeling\n--------------------------");
            foreach(string klant in _rapport.Keys)
            {
                Console.WriteLine($"{klant}:");

                Dictionary<ProductType, int> aggregaatProduct = new Dictionary<ProductType, int>();

                foreach(Bestelling b in _rapport[klant])
                {
                    aggregaatProduct[b.Product] = (aggregaatProduct.ContainsKey(b.Product)) ? aggregaatProduct[b.Product] + b.Aantal : b.Aantal;
                }

                foreach(ProductType p in aggregaatProduct.Keys)
                {
                    Console.WriteLine($"\t{p}, {aggregaatProduct[p]}");
                }
            }

            Console.WriteLine(" ");
        }
        #endregion
    }
}
