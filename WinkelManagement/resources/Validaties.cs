namespace WinkelManagementCL.resources
{
    public class Validaties
    {
        /// <summary>
        /// Variabelen welke gebruikt worden om bij het setten van diverse properties in andere klasses een validatie uit te kunnen voeren
        /// Dit centraliseert, creeert overzicht en voorkomt het bestaan van magic values in de klasses zelf
        /// </summary>
        public Validaties()
        {
            minimumBedragBestelling = 0M;
            minimumAantalBestelling = 1;
            minimumLengteAdres = 10;
            minimumAantalInStock = 25;
            maximumAantalInStock = 100;
        }

        public decimal minimumBedragBestelling { get; set; }
        public int minimumAantalBestelling { get; set; }
        public int minimumLengteAdres { get; set; }

        public int minimumAantalInStock { get; set; }
        public int maximumAantalInStock { get; set; }
    }
}
