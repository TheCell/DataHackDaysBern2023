using Microsoft.VisualBasic.FileIO;
using RegexReader.CSV_Reader.DataClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexReader.CSV_Reader
{
    public class CSV_Reader
    {

        public IEnumerable<HistoryData> ReadCSV(string path)
        {
            // TextFieldParser is in the Microsoft.VisualBasic.FileIO namespace.
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.CommentTokens = new string[] { "#" };
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;

                // Skip over header line.
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    yield return new HistoryData()
                    {
                        Id = fields[0],
                        OBJECTID = fields[1],
                        ADRESSE = fields[2],
                        HISTORY_HTML = fields[3],
                        STArea = fields[4],
                        STLength = fields[5]
                    };
                }
            }
        }
    }
}
