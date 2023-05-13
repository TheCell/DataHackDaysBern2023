using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RegexReader.CSV_Reader
{
    public class HistoryDataTransform
    {
        private CSV_Reader reader;

        public void TransformData()
        {
            Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var iterator = reader.ReadCSV("Bauhistorie.csv");
            var allHistoryData = iterator.ToArray();
            Regex rx = new Regex(@"<tr>(.|\n)*?<\/tr>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            for (int i = 0; i < allHistoryData.Length; i++)
            {
                var matches = rx.Matches(allHistoryData[i].HISTORY_HTML);
            }
        }
    }
}
