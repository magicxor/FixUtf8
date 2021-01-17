using System.IO;
using System.Text;

string line;

using var srcFile = new StreamReader(args[0]);
using var destFile = new StreamWriter(args[1], false, Encoding.UTF8);
try
{
    while ((line = srcFile.ReadLine()) != null)
    {
        destFile.WriteLine(line);
    }
}
finally
{
    destFile.Close();
    srcFile.Close();
}
