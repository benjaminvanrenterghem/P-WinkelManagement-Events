using System;

namespace WinkelManagementCL
{
    public class Winkel
    { 
        // publisher van event productverkocht
        public event EventHandler<WinkelEventArgs> ProductVerkocht;

        // had eventuele controle kunnen plaatsvinden mbt huidige stock van het artikel, zoals het nu staat kan een klant een oneindige hoeveelheid producten
        // aankopen
        public void verkoopProduct(Bestelling b)
        {
            RaiseProductVerkocht(b);
        }

        // raise event productverkocht
        protected virtual void RaiseProductVerkocht(Bestelling b)
        {
            ProductVerkocht?.Invoke(this, new WinkelEventArgs(b));
        }
    }
}
