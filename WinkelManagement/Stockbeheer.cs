using System;
using System.Collections.Generic;
using WinkelManagementCL.resources;

namespace WinkelManagementCL
{
    public class Stockbeheer
    {
        /// <summary>
        /// Is subscriber van 2 events, publisher van 1 event
        /// </summary>

        #region initialisatie gerelateerde properties
        private Configurations Preset = new Configurations();
        #endregion

        #region properties
        private Dictionary<ProductType, int> _stockOverzicht = new Dictionary<ProductType, int>();
        #endregion

        #region event definiering
        public event EventHandler<StockbeheerEventArgs> StockOnderMinimum;
        #endregion

        #region ctor
        public Stockbeheer()
        {
            // https://stackoverflow.com/a/972323 -- mbt enumeratie enum, moet met typeof
            foreach (ProductType t in Enum.GetValues(typeof(ProductType)))
            {
                _stockOverzicht[t] = Preset.StartStockPerProduct;
            }
        }
        #endregion

        #region event handler 1/2
        public void OnProductVerkocht(object sender, WinkelEventArgs args)
        {
            _stockOverzicht[args.Bestelling.Product] -= args.Bestelling.Aantal;
            if(_stockOverzicht[args.Bestelling.Product] < Preset.MinimumStockThreshold)
            {
                int hoeveelheidBestellen = Preset.StockAanvullenTotHoeveelheid - _stockOverzicht[args.Bestelling.Product];
                RaiseStockOnderMinimum(args.Bestelling.Product, hoeveelheidBestellen);
            }
        }
        #endregion

        #region event raiser 1/1
        protected virtual void RaiseStockOnderMinimum(ProductType type, int aantal)
        {
            StockOnderMinimum?.Invoke(this, new StockbeheerEventArgs(type, aantal));
        }
        #endregion

        #region event handler 2/2
        public void OnBestellingGeplaatst(object sender, StockbeheerEventArgs args)
        {
            VulStockAan(args.ProductType, args.Hoeveelheid);
        }
        #endregion

        #region lokale methode voor gebruik door event handler 2
        private void VulStockAan(ProductType p, int amt)
        {
            _stockOverzicht[p] = (_stockOverzicht.ContainsKey(p)) ? _stockOverzicht[p] + amt : amt;
        }
        #endregion

        #region overzichtsmethodes
        public void ToonStock()
        {
            Console.WriteLine("Rapport stockbeheer\n-----------------------");
            foreach (ProductType p in _stockOverzicht.Keys)
            {
                int stockHoeveelheid = _stockOverzicht[p];
                Console.WriteLine($"{p}, {stockHoeveelheid}");
            }

            Console.WriteLine(" ");
        }
        #endregion
    }
}
