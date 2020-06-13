using System.IO;

namespace UCM_dialog
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileData;
            string secName = "";

            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                fileData = sr.ReadToEnd();
            }

            string[] lines = fileData.Split('\n');
            
            //get name
            string[] tmp = lines[0].Split(' ');
            for (int i = 1; i < tmp.Length; i++)
            {
                if (tmp[i].Equals("signed"))
                    break;
                secName += tmp[i];
                secName += " ";
            }

            secName = secName.Trim();            

            using (StreamWriter sw = new StreamWriter("OUTPUT.TXT", false, System.Text.Encoding.Default))
            {
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    lines[i] = lines[i].Remove(0, 10);
                    lines[i] = lines[i].Trim();
                    if (!(lines[i].EndsWith(",") || lines[i].EndsWith("!") || lines[i].EndsWith("?")))
                    {
                        lines[i] = lines[i].Replace(".", ",");
                    }

                    if (!(lines[i].EndsWith(",") || lines[i].EndsWith("!") || lines[i].EndsWith("?")) ||
                        lines[i].EndsWith("."))
                    {
                        lines[i] += ",";
                    }

                    if (i % 2 == 1)
                    {
                        sw.Write("\"");
                        sw.Write(lines[i]);
                        sw.Write("\"");
                        sw.Write(" --- skazal Fedya.");
                    }
                    else
                    {
                        sw.Write("\"");
                        sw.Write(lines[i]);
                        sw.Write("\"");
                        sw.Write(" --- skazal ");
                        sw.Write(secName);
                        sw.Write(".");
                    }
                    
                    sw.WriteLine();
                }
            }
            
        }
    }
}