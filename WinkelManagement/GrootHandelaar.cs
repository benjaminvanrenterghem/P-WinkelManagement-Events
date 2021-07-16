using System;
using System.Collections.Generic;

namespace WinkelManagementCL
{
    public class GrootHandelaar
    {
        /// <summary>
        /// Is publisher van 1 event, subscriber van 1 event
        /// </summary>

        /// <summary>
        /// houdt de bestellingen bij welke de groothandelaar heeft geplaatst
        /// </summary>
        private List<Bestelling> _bestellingen = new List<Bestelling>();

        // publisher van event bestellinggeplaatst
        public event EventHandler<StockbeheerEventArgs> BestellingGeplaatst;

        public GrootHandelaar(){}

        // subscriber van het event StockOnderMinimum -- stockbeheer
        public void OnStockOnderMinimum(object sender, StockbeheerEventArgs args)
        {
            Bestelling b = new Bestelling(args.ProductType, args.Hoeveelheid);
            _bestellingen.Add(b);
            RaiseBestellingGeplaatst(b);
        }

        // raise de gedefineerde event 
        protected virtual void RaiseBestellingGeplaatst(Bestelling b)
        {
            BestellingGeplaatst?.Invoke(this, new StockbeheerEventArgs(b.Product, b.Aantal));
        }

        /// <summary>
        /// enkele overzichtsmethodes welke gebruik maken van de _bestellingen lijst 
        /// </summary>
        public void ToonAlleBestellingen()
        {
            Console.WriteLine($"Rapport groothandelaar: alle bestellingen\n----------------------------------------");
            foreach(Bestelling b in _bestellingen)
            {
                Console.WriteLine($"{b.Product}, {b.Aantal}");
            }

            Console.WriteLine(" ");
        }

        public void ToonLaatsteBestelling()
        {
            Console.WriteLine($"Rapport groothandelaar: laatste bestelling\n-----------------------------------------");
            if(_bestellingen.Count > 0)
            {
                Bestelling laatsteBestelling = _bestellingen[_bestellingen.Count - 1];
                Console.WriteLine($"{laatsteBestelling.Product}, {laatsteBestelling.Aantal}\n");
            } else
            {
                Console.WriteLine("Geen bestellingen gevonden.\n");
            }
        }
    }
}
