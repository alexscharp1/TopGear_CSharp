using System;

/* Creates 10 Instruments of different types and checks their 
 * polymorphic behavior.
 */

namespace ClassesAndStructs5
{
    class Program
    {
        private const int NUM_INSTRUMENTS = 10;

        static void Main(string[] args)
        {
            // Create 10 instruments of different types
            Instrument[] instruments = new Instrument[NUM_INSTRUMENTS];
            for (int i = 0; i < NUM_INSTRUMENTS; i++)
            {
                if (i % 3 == 0)
                {
                    instruments[i] = new Piano();
                }
                else if (i % 3 == 1)
                {
                    instruments[i] = new Flute();
                }
                else
                {
                    instruments[i] = new Guitar();
                }
            }

            // Call Play()
            Console.WriteLine("Let the instruments play!");
            for (int i = 0; i < NUM_INSTRUMENTS; i++)
            {
                instruments[i].Play();
            }

            // Print each instrument's type and index
            Console.WriteLine("\nInstrument types");
            for (int i = 0; i < NUM_INSTRUMENTS; i++)
            {
                string type = "";
                Instrument instrument = instruments[i];
                if (instrument is Piano) type = "Piano";
                else if (instrument is Flute) type = "Flute";
                else if (instrument is Guitar) type = "Guitar";
                Console.WriteLine("{0}: {1}", i, type);
            }
        }
    }
}
