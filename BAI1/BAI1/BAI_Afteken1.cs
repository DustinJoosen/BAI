using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BAI
{
    public class BAI_Afteken1
    {
        private const string BASE27CIJFERS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const UInt64 MAX_THREE_DIGITS = 19683;  // 27^3


        // ***************
        // * OPGAVE 1a/b *
        // ***************
        public static UInt64 Opg1aDecodeBase27(string base27getal)
        {
            /* Zuja: voeg nog wat nuttige commentaar toe, 
            bijv. variabele uitleg, wat de loop doet, etc. */

            // *** IMPLEMENTATION HERE *** //
            UInt64 total = 0;

            // Contains the current exponent value. Each iteration it multiplies itself by 27.
            UInt64 power = 1;

            // You walk from right to left, so reverse the base27getal.
            var reverse = base27getal.Reverse();

            foreach (char c in reverse)
            {
                // If the char is not part of BASE27, throw an exception.
                if (!BASE27CIJFERS.Contains(c))
                    throw new ArgumentException($"Character '{c}' is not able to be decoded.");

                // Get the base-10 representation of the character.
                UInt64 idx = (UInt64)BASE27CIJFERS.IndexOf(c);

                total += idx * power;

                // Essentially throws the exponent up. e.g. from 27^1 to 27^2.
                power *= 27;
            }
            return total;
        }
        public static string Opg1bEncodeBase27(UInt64 base10getal)
        {
            /* Zuja: voeg nog wat nuttige commentaar toe, 
            bijv. variabele uitleg, wat de loop doet, etc. */

            // *** IMPLEMENTATION HERE *** //
            string result = string.Empty;
            UInt64 div = base10getal;

            /* Always needs to run at least once, to prevent errors on a '-'.
             * You grab the character that the number would collerate to (through modulo), 
             * and prepend it to the output string. Then you recalculate the div.
             * This continues until the remaining div is zero. */
            do
            {
                var new_char = BASE27CIJFERS[(int)(div % 27)];
                
                // Zuja: Is de ToString hier nodig?
                result = new_char + result;
                div = div / 27;
            } while (div != 0);

            return result;
        }

        // ***************
        // * OPGAVE 2a/b *
        // ***************
        public static Stack<UInt64> Opdr2aWoordStack(List<string> woorden)
        {
            // *** IMPLEMENTATION HERE *** //
            Stack<UInt64> stack = new();
            foreach (string woord in woorden)
            {
                stack.Push(Opg1aDecodeBase27(woord));
            }
            return stack;
        }
        public static Queue<string> Opdr2bKorteWoordenQueue(Stack<UInt64> woordstack)
        {
            // *** IMPLEMENTATION HERE *** //
            Queue<string> queue = new();
            while (woordstack.Count > 0)
            {
                var woord = woordstack.Pop();
                // Zuja: mooi.
                if (woord < MAX_THREE_DIGITS)
                    queue.Enqueue(Opg1bEncodeBase27(woord));
            }

            return queue;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1a : Decode base-27 ===");
            Console.WriteLine($"BAI    => {Opg1aDecodeBase27("BAI")}");         // 1494
            Console.WriteLine($"HBO-ICT => {Opg1aDecodeBase27("HBO-ICT")}");    // 3136040003
            Console.WriteLine($"BINGO  => {Opg1aDecodeBase27("BINGO")}");       // 1250439
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1b : Encode base-27 ===");
            Console.WriteLine($"0 => {Opg1bEncodeBase27(0)}");          // "-"
            Console.WriteLine($"1494       => {Opg1bEncodeBase27(1494)}");          // "BAI"
            Console.WriteLine($"3136040003 => {Opg1bEncodeBase27(3136040003)}");    // "HBO-ICT"
            Console.WriteLine($"1250439   => {Opg1bEncodeBase27(1250439)}");        // BINGO
            Console.WriteLine();

            Console.WriteLine("=== Opdracht 2 : Stack / Queue - korte woorden ===");
            string[] woordarray = {"CONCEPT", "OK", "BLAUW", "TOEN", "IS",
                "HBOICT", "GEEL", "DIT", "GOED", "NIEUW"};
            List<string> woorden = new List<string>(woordarray);
            Stack<UInt64> stack = Opdr2aWoordStack(woorden);
            Queue<string> queue = Opdr2bKorteWoordenQueue(stack);

            foreach (string kortwoord in queue)
            {
                Console.Write(kortwoord + " ");                             // Zou "DIT IS OK" moeten opleveren
            }
            Console.WriteLine();
        }
    }
}
