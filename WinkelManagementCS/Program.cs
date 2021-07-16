using System;
using WinkelManagementCL;
using WinkelManagementCL.resources;

namespace WinkelManagementCS
{
    class Program
    {
        static void Main(string[] args)
        {

            #region objecten aanmaken
            Winkel winkel = new Winkel();
            Stockbeheer stockbeheer = new Stockbeheer();
            GrootHandelaar groothandelaar = new GrootHandelaar();
            Verkoopafdeling verkoopafd = new Verkoopafdeling();
            #endregion

            #region private methode
            static void runAlleOverzichten(Verkoopafdeling v, GrootHandelaar g, Stockbeheer s)
            {
                v.ToonRapport();
                g.ToonAlleBestellingen();
                g.ToonLaatsteBestelling();
                s.ToonStock();
            }
            #endregion

            #region abboneren op events
            // links leggen tussen event raisers en handlers
            stockbeheer.StockOnderMinimum += groothandelaar.OnStockOnderMinimum;
            groothandelaar.BestellingGeplaatst += stockbeheer.OnBestellingGeplaatst;
            winkel.ProductVerkocht += verkoopafd.OnProductVerkocht;
            winkel.ProductVerkocht += stockbeheer.OnProductVerkocht;
            #endregion

            #region aanroepen objectmethodes en lokale methodes
            // overzichten alvorens operaties met gevolgen
            runAlleOverzichten(verkoopafd, groothandelaar, stockbeheer);

            // enkele producten verkopen
            winkel.verkoopProduct(new Bestelling(ProductType.Leffe, 5.0M, 25, "Moerbeekstraat 25 - Geraardsbergen"));

            // intermediaire overzichten
            runAlleOverzichten(verkoopafd, groothandelaar, stockbeheer);

            // nog enkele producten verkopen
            winkel.verkoopProduct(new Bestelling(ProductType.Nespresso, 5.0M, 40, "Moerbeekstraat 25 - Geraardsbergen"));
            winkel.verkoopProduct(new Bestelling(ProductType.ToiletPapier, 5.0M, 50, "Stationsstraat 10 - Zottegem"));

            // ▼ deze laat de stock kortstondig na op -20 sinds er geen controle plaatsvind
            winkel.verkoopProduct(new Bestelling(ProductType.Nespresso, 5.0M, 80, "Moerbeekstraat 25 - Geraardsbergen"));

            // finale overzichten
            runAlleOverzichten(verkoopafd, groothandelaar, stockbeheer);
            #endregion
        }
    }
}
