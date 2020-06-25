using System;
using System.IO;

namespace lab3
{
    class Program
    {
        private static void PrintUsage()
        {
            Console.Write("");
            Console.WriteLine("Usage is:\n" +

            "\tjava Main C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. java Main 72 myfile.txt myfile_wrapped.txt");
           
        }

        static void Main(String[] args)
        {
            int C = 72;                     // Column length to wrap to
            String inputFilename = "";
            String outputFilename = "output.txt";
            //Scanner scanner = null;

            StreamReader readFile = null;



            // Read the command line arguments ...
            if (args.Length != 3)
            {
                PrintUsage();
                //System.exit(1);
                Environment.Exit(1);
            }
            try
            {
                //C = Integer.parseInt(args[0]);
                C = int.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                //scanner = new Scanner(new File(inputFilename));
                readFile = File.OpenText(inputFilename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                //System.exit(1);
                Environment.Exit(1);
            }

            // Read words and their lengths into these vectors
            IQueueInterface<String> words = new LinkedQueue<String>();

            // Read input file, tokenize by whitespace
            while (!readFile.EndOfStream)
            {
                string line = readFile.ReadLine();
                string[] splitWords = line.Split(' ');
                foreach (var word in splitWords)
                {
                    words.Push(word);
                }
            }

            // At this point the input text file has now been placed, word by word, into a FIFO queue
            // Each word does not have whitespaces included, but does have punctuation, numbers, etc.

            /* ------------------ Start here ---------------------- */

            // As an example, do a simple wrap
            int spacesRemaining = WrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
        } // End main()

        /*-----------------------------------------------------------------------
            Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
          -----------------------------------------------------------------------*/

        /**
            As an example only, write out the file directly to the output with _simple_ wrapping,
            i.e. adding spaces between words and moving to the next line if a word would go past the
            indicated column number C.  This will fail if any word length exceeds the column limit C,
            but it still goes ahead and just puts one word on that line.
        */
        private static int WrapSimply(IQueueInterface<String> words, int columnLength, String outputFilename)
        {
            StreamWriter sw = null;
            int col = 1;
            int spacesRemaining = 0;



            try
            {
                sw = new StreamWriter(outputFilename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot create or open " + outputFilename +
                            " for writing.  Using standard output instead.");
                sw = new StreamWriter(Console.OpenStandardOutput());
            }

            // Running count of spaces left at the end of lines
            while (!words.IsEmpty())
            {
                String str = words.Peek();
                int len = str.Length;
                // See if we need to wrap to the next line
                if (col == 1)
                {
                    sw.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    // go to the next line
                    sw.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {   // Typical case of printing the next word on the same line
                    sw.Write(" ");
                    sw.Write(str);
                    col += (len + 1);
                    words.Pop();
                }

            }
            sw.WriteLine();

            sw.Flush();
            sw.Close();
            return spacesRemaining;
            Console.ReadKey();
        } // end wrapSimply

    }
}

