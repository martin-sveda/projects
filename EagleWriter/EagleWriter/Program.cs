using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace EagleWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /* check command line attributes */
            if (args[0] == null || args[1] == null || args[2] == null || args[3] == null)
            {
                Console.WriteLine("Missing arguments!!!");
                Console.WriteLine("Usage: EagleWriter infile PARAM VALUE outfile");
                return;
            }
            
            
            XmlDocument xmlDoc = new XmlDocument();
            Console.WriteLine("Reading file {0}", args[0]);
            xmlDoc.Load(args[0]);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("/eagle/drawing/schematic/attributes/attribute");

            foreach (XmlNode itemNode in itemNodes)
            {
                string s = itemNode.Attributes["name"].Value;
                if (s.Equals(args[1], StringComparison.Ordinal))
                {
                    itemNode.Attributes["value"].Value = args[2];
                }
            }

            Console.WriteLine("Writing file {0}", args[3]);
            xmlDoc.Save(args[3]);

            Console.ReadKey();
        }
    }
}
