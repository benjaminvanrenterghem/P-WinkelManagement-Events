namespace WinkelManagementCL.resources
{
    public class Configurations
    {
        /// <summary>
        /// Dient voor het initialiseren van het project, in tegenstelling tot de klasse Validaties dienen deze waarden niet om properties te valideren
        /// Bevat standaardwaardes in de ctor waar indien nodig van kan afgeweken worden.
        /// </summary>
        /// <param name="startStockPerProduct"></param>
        /// <param name="minimumStockThreshold"></param>
        /// <param name="stockAanvullenTotHoeveelheid"></param>
        public Configurations(int startStockPerProduct=100, int minimumStockThreshold=25, int stockAanvullenTotHoeveelheid=100)
        {
            StartStockPerProduct = startStockPerProduct;
            MinimumStockThreshold = minimumStockThreshold;
            StockAanvullenTotHoeveelheid = stockAanvullenTotHoeveelheid;
        }

        public int StartStockPerProduct { get; set; } // stockbeheer
        public int StockAanvullenTotHoeveelheid { get; set; } // groothandelaar
        public int MinimumStockThreshold { get; set; }

    }
}
