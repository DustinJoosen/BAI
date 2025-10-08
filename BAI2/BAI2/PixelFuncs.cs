using System;
using System.Windows;

namespace BAI
{
    public class PixelFuncs
    {
        /// <summary>
        /// Voor consistentie maken wij gebruik van binaire kleuren.
        /// </summary>
        public static uint FilterNiks(uint pixel)
        {
            return pixel;
        }

        public static uint FilterRood(uint pixel)
        {
            // *** IMPLEMENTATION HERE *** //
            // De bitwise & operator zet de rode bits (23-16) op 0.
            uint mask = 0b_11111111_00000000_11111111_11111111;
            return pixel & mask;
        }

        public static uint FilterGroen(uint pixel)
        {
            // *** IMPLEMENTATION HERE *** //
            // De bitwise & operator zet de groene bits (15-8) op 0.
            uint mask = 0b_11111111_11111111_00000000_11111111;
            return pixel & mask;
        }

        public static uint FilterBlauw(uint pixel)
        {
            // *** IMPLEMENTATION HERE *** //
            // De bitwise & operator zet de blauwe bits (7-0) op 0.
            uint mask = 0b_11111111_11111111_11111111_00000000;
            return pixel & mask;
        }


        public static byte RoodWaarde(uint pixelvalue)
        {
            // *** IMPLEMENTATION HERE *** //
            // Zet alle niet-rode bits op 0, en schuif naar rechts om de "belangrijke" nullen aan de rechterkant van rood weg te werken.
            // Alles links van rood is 0 dus kan worden genegeerd.
            return (byte)((pixelvalue & 0b00000000_11111111_00000000_00000000) >> 16);
        }

        public static byte GroenWaarde(uint pixelvalue)
        {
            // *** IMPLEMENTATION HERE *** //
            // Zet alle niet-groene bits op 0, en schuif naar rechts om de "belangrijke" nullen aan de rechterkant van groen weg te werken.
            // Alles links van groen is 0 dus kan worden genegeerd.
            return (byte)((pixelvalue & 0b00000000_00000000_11111111_00000000) >> 8);
        }

        public static byte BlauwWaarde(uint pixelvalue)
        {
            // *** IMPLEMENTATION HERE *** //
            // Zet alle niet-blauwe bits op 0, en schuif naar rechts om de "belangrijke" nullen aan de rechterkant van blauw weg te werken.
            // Alles links van blauw is 0 dus kan worden genegeerd.
            return (byte)(pixelvalue & 0b00000000_00000000_00000000_11111111);
        }

        public static uint Steganografie(uint pixelvalue)
        {
            // *** IMPLEMENTATION HERE *** //

            // De 16e bit bepaald of er wel of geen kleur teruggegeven wordt.            
            // Schuif de 16e bit helemaal naar rechts. Deze bit bepaald nu of het getal even of oneven is.
            byte bit = (byte)(pixelvalue >> 16);

            // Als die bit even is, dus 0, geef je zwart terug.
            if (bit % 2 == 0)
            {
                return 0b11111111_00000000_00000000_00000000;
            }
            // Als die bit oneven is, dus 1, geef je rood terug.
            else
            {
                return 0b11111111_11111111_00000000_00000000;
            }
        }


        // ***** Voor de liefhebbers - deze hoef je NIET te maken om een voldoende te krijgen! ***** //
        public static uint Steganografie2(uint pixelvalue)
        {
            // In het originele plaatje zit nog een tweede plaatje verstopt, maar dan op
            // een *nog* ingewikkelder manier.
            // Laat zien dat je echt een expert bent, en decodeer hier het tweede plaatje.
            // (Hint: kijk naar de eerste 4 bytes van de gedecodeerde data.)

            // *** IMPLEMENTATION HERE *** //
            return 0;
        }
    }
}


