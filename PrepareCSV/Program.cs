using System;
using System.IO;
using System.Text;

const char delimiter1 = ':';
const char delimiter2 = ';';
const char delimiter3 = '|';

const char newDelimiter = '\t';
const int maxLength = 255;
string line = string.Empty;

using var srcFile = new StreamReader(args[0]);
using var destFile = new StreamWriter(args[1], false, new UTF8Encoding(false));
try
{
    while ((line = srcFile.ReadLine()) != null)
    {
        var indexOfDelimiter1 = -1;
        var indexOfDelimiter2 = -1;
        var indexOfDelimiter3 = -1;

        {
            var sb = new StringBuilder(line.Length);
            var i = 0;
            foreach (var c in line)
            {
                if (indexOfDelimiter1 < 0 && c == delimiter1)
                {
                    indexOfDelimiter1 = i;
                }
                if (indexOfDelimiter2 < 0 && c == delimiter2)
                {
                    indexOfDelimiter2 = i;
                }
                if (indexOfDelimiter3 < 0 && c == delimiter3)
                {
                    indexOfDelimiter3 = i;
                }

                if (c != '\x0000' &&
                    c != '\x0001' &&
                    c != '\x0002' &&
                    c != '\x0003' &&
                    c != '\x0004' &&
                    c != '\x0005' &&
                    c != '\x0006' &&
                    c != '\x0007' &&
                    c != '\x0008' &&
                    c != '\x0009' &&
                    c != '\x000A' &&
                    c != '\x000B' &&
                    c != '\x000C' &&
                    c != '\x000D' &&
                    c != '\x000E' &&
                    c != '\x000F' &&
                    c != '\x0010' &&
                    c != '\x0011' &&
                    c != '\x0012' &&
                    c != '\x0013' &&
                    c != '\x0014' &&
                    c != '\x0015' &&
                    c != '\x0016' &&
                    c != '\x0017' &&
                    c != '\x0018' &&
                    c != '\x0019' &&
                    c != '\x001A' &&
                    c != '\x001B' &&
                    c != '\x001C' &&
                    c != '\x001D' &&
                    c != '\x001E' &&
                    c != '\x001F' &&
                    c != '\x007F' &&
                    c != '\x0080' &&
                    c != '\x0081' &&
                    c != '\x0082' &&
                    c != '\x0083' &&
                    c != '\x0084' &&
                    c != '\x0085' &&
                    c != '\x0086' &&
                    c != '\x0087' &&
                    c != '\x0088' &&
                    c != '\x0089' &&
                    c != '\x008A' &&
                    c != '\x008B' &&
                    c != '\x008C' &&
                    c != '\x008D' &&
                    c != '\x008E' &&
                    c != '\x008F' &&
                    c != '\x0090' &&
                    c != '\x0091' &&
                    c != '\x0092' &&
                    c != '\x0093' &&
                    c != '\x0094' &&
                    c != '\x0095' &&
                    c != '\x0096' &&
                    c != '\x0097' &&
                    c != '\x0098' &&
                    c != '\x0099' &&
                    c != '\x009A' &&
                    c != '\x009B' &&
                    c != '\x009C' &&
                    c != '\x009D' &&
                    c != '\x009E' &&
                    c != '\x009F' &&
                    c != '\x00A0' &&
                    c != '\x2028' &&
                    c != '\x2029' &&
                    c != '\x2424' &&
                    c != '\x23CE' &&
                    c != '\x240D' &&
                    c != '\x240A')
                {
                    sb.Append(c);
                }
                i++;
            }

            line = sb.ToString();
        }

        if (((indexOfDelimiter1 > 0 && ((line.Length - 1) - indexOfDelimiter1 > 0)) || (indexOfDelimiter2 > 0 && ((line.Length - 1) - indexOfDelimiter2 > 0)) || (indexOfDelimiter3 > 0 && ((line.Length - 1) - indexOfDelimiter3 > 0)))
            && line != null
            && line.Length > 0)
        {
            string firstPart = null;
            string secondPart = null;

            if ((indexOfDelimiter1 > 0) && ((line.Length - 1) - indexOfDelimiter1 > 0)) 
            {
                firstPart = line.Substring(0, indexOfDelimiter1);
                secondPart = line.Substring(indexOfDelimiter1 + 1);
            }
            else if ((indexOfDelimiter2 > 0) && ((line.Length - 1) - indexOfDelimiter2 > 0))
            {
                firstPart = line.Substring(0, indexOfDelimiter2);
                secondPart = line.Substring(indexOfDelimiter2 + 1);
            }
            else if ((indexOfDelimiter3 > 0) && ((line.Length - 1) - indexOfDelimiter3 > 0))
            {
                firstPart = line.Substring(0, indexOfDelimiter3);
                secondPart = line.Substring(indexOfDelimiter3 + 1);
            }

            if (!string.IsNullOrEmpty(firstPart) && !string.IsNullOrEmpty(secondPart))
            {
                destFile.WriteLine(firstPart?.Substring(0, Math.Min(firstPart.Length, maxLength)) + newDelimiter + secondPart?.Substring(0, Math.Min(secondPart.Length, maxLength)));
            }
        }
    }
}
catch (Exception)
{
    Console.WriteLine($"line: {line}");
    throw;
}
finally
{
    destFile.Close();
    srcFile.Close();
}
