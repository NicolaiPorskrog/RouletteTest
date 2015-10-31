using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace RouletteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Initializing...");
                Simulate();
                Console.ReadLine();
            }
        }

        private static void Simulate()
        {
            var rnd = new Random();
            
            var redInARow = 0;
            var blackInARow = 0;
            var redsAfterSevenReds = 0;
            var notRedsAfterSevenReds = 0;
            var totalReds = 0;
            var totalZeros = 0;
            var totalBlacks = 0;
            var total = 0;
            var sevenRedsInARow = false;
            var totalSevenRedsCases = 0;
            var bestRedsInARow = 0;
            for (var i = 0; i < 100000000; i++)
            {
                var number = rnd.Next(0, 37);
                total++;
                if (redInARow > bestRedsInARow) bestRedsInARow = redInARow;
                
                if (sevenRedsInARow)
                {
                    totalSevenRedsCases++;
                    if (number != 0 && number%2 == 0)
                    {
                        redsAfterSevenReds++;
                    }
                    else
                    {
                        notRedsAfterSevenReds++;
                    }
                    sevenRedsInARow = false;
                }
                
                if (number == 0)
                {
                    totalZeros++;
                    redInARow = 0;
                    continue;
                }

                if (number%2 == 0)
                {
                    redInARow++;
                    totalReds++;
                    
                    if (redInARow == 7)
                    {
                        sevenRedsInARow = true;
                    }
                }
                else if(number%2 != 0 && number != 0)
                {
                    totalBlacks++;
                    redInARow = 0;
                }
            }
            double redsInPercentage = ((redsAfterSevenReds+0.0)/(totalSevenRedsCases)+0.0)*100;
            double totalRedsInPercentage = (totalReds+0.0)/(total+0.0)*100;
            Console.WriteLine("Reds after 7 reds: "+redsAfterSevenReds);
            Console.WriteLine("Not reds after 7 reds: "+notRedsAfterSevenReds);
            Console.WriteLine("Reds in percentage after 7 reds: "+redsInPercentage);
            Console.WriteLine("Total reds in percentage: "+totalRedsInPercentage);
            Console.WriteLine("Total Zeros: "+totalZeros);
            Console.WriteLine("Total reds: "+ totalReds);
            Console.WriteLine("Total blacks: "+totalBlacks);
            Console.WriteLine("Best reds in a row: "+ bestRedsInARow);
        }
    }
}
