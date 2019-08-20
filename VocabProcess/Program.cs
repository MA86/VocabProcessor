using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VocabProcess
{
    class Program
    {
        /// <summary>
        /// 
        /// This console application processes a file of strings in the following format: 'WORD\n\nTRANSLATION\n\n' 
        /// and outputs another file in the following format: 'WORD\tTRANSLATION\n'. Use CLI to run this application.
        /// 
        /// EXAMPLE:
        /// 
        /// Input File: 
        /// communicable
        /// 
        /// ساري
        /// 
        /// Output File:
        /// communicable	ساري
        /// 
        /// </summary>

        static void Main(string[] args)
        {
            string vocabList = "";
            bool englishWordCheck = false;
            string word;

            StreamReader sr = File.OpenText(args[0]);

            // Get a list of vocab in this form: 'enlish\tforeign\n'
            while (!sr.EndOfStream)
            {
                word = sr.ReadLine();

                // Process english word if foreign word has already been processed
                if (word != "" && englishWordCheck == false)
                {
                    vocabList += word + "\t";

                    // English word processed
                    englishWordCheck = true;

                    continue;
                }

                // Process foreign word if English word has already been processed
                if (word != "" && englishWordCheck == true)
                {
                    vocabList += word + "\n";

                    // Foreign word processed
                    englishWordCheck = false;

                    continue;
                }
            }

            sr.Close();

            // Write the vocabList to a file on desktop
            File.WriteAllText(args[1], vocabList);
        }
    }
}
