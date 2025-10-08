using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BAI
{
    public class SetFuncs
    {
        public static HashSet<uint> AlleKleuren(uint[] pixeldata)
        {
            // *** IMPLEMENTATION HERE *** //
            // Hier mag je loopen over pixeldata

            // Hashsets halen automatisch dubbele entries weg.
            return new HashSet<uint>(pixeldata);
        }

        public static HashSet<uint> BlauwTinten(uint[] pixeldata)
        {
            // *** IMPLEMENTATION HERE *** //
            // Hier mag je loopen over pixeldata

            // Stopt alleen waardes in de hashset waarbij de blauwe waarde de grootste waarde is.
            return new HashSet<uint>(pixeldata.Where(pixel =>
                {
                    // Haal bluepixel maar 1 keer op in een variabele.
                    var bluePixel = PixelFuncs.BlauwWaarde(pixel);
                    return (bluePixel > PixelFuncs.GroenWaarde(pixel)) && (bluePixel > PixelFuncs.RoodWaarde(pixel));
                }
            ));

        }

        public static HashSet<uint> DonkereKleuren(uint[] pixeldata)
        {
            // *** IMPLEMENTATION HERE *** //
            // Hier mag je loopen over pixeldata

            // Neem alleen de pixelwaardes mee wanneer rood + groen + blauw minder is dan 192.
            return new HashSet<uint>(pixeldata.Where(pixel =>
                PixelFuncs.RoodWaarde(pixel) + PixelFuncs.GroenWaarde(pixel) + PixelFuncs.BlauwWaarde(pixel) < 192
            ));
        }

        public static HashSet<uint> NietBlauwTinten(uint[] pixeldata)
        {
            // *** IMPLEMENTATION HERE *** //
            // Gebruik set-operatoren op 1 of meer van de sets 'alle kleuren' /
            // 'blauwtinten' / 'donkere kleuren'
            // Gebruik dus GEEN loop

            var alleKleuren = AlleKleuren(pixeldata);
            var blauwTinten = BlauwTinten(pixeldata);

            // Haal alle blauwtinten uit de kleurenlijst.
            alleKleuren.ExceptWith(blauwTinten);

            return alleKleuren;            
        }

        public static HashSet<uint> DonkerBlauwTinten(uint[] pixeldata)
        {
            // *** IMPLEMENTATION HERE *** //
            // Gebruik set-operatoren op 1 of meer van de sets 'alle kleuren' /
            // 'blauwtinten' / 'donkere kleuren'
            // Gebruik dus GEEN loop

            var blauwTinten = BlauwTinten(pixeldata);
            var donkereKleuren = DonkereKleuren(pixeldata);

            // Geef alleen de kleuren terug die zowel een blauwtint als een donkere kleur zijn.
            blauwTinten.IntersectWith(donkereKleuren);

            return blauwTinten;
        }
    }
}
