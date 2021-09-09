using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.Threading;
using System.Globalization;

namespace UndirectedFlowsApp
{
    class XmlParser
    {
        public string path;
        public XmlParser(string path)
        {
            this.path = path;
        }

        public void MakeModel(ref Graph graph)
        {
            if (path != null)
            {
                // Создаем экземпляр Xml документа.
                XmlDocument xDoc = new XmlDocument();

                //string paths = "..\\..\\..\\germany50.xml";
                // Загружаем данные из файла.
                xDoc.Load(path);

                XmlNamespaceManager ns = new XmlNamespaceManager(xDoc.NameTable);
                ns.AddNamespace("snd", "http://sndlib.zib.de/network");

                XmlNode doc = xDoc;
                XmlNode selectNodeGeneral = doc.SelectSingleNode("/snd:network/snd:demands", ns);

                XmlNode selectNodes = doc.SelectSingleNode("/snd:network/snd:networkStructure/snd:nodes", ns);
                foreach (XmlNode n in selectNodes.ChildNodes)
                {
                    XmlNode attr = n.Attributes.GetNamedItem("id");
                    //Console.WriteLine(attr.Value);
                    XmlNode coordX = n.SelectSingleNode("snd:coordinates/snd:x", ns);
                    //Console.WriteLine(coordX.InnerText);
                    XmlNode coordY = n.SelectSingleNode("snd:coordinates/snd:y", ns);
                    //Console.WriteLine(coordY.InnerText);
                    //user.Age = Int32.Parse(childnode.InnerText);

                    //double x = double.Parse(coordX.InnerText);

                    //нужны пространства имен using System.Threading и System.Globalization
                    //string s = "130.2";
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    double dx = (double.Parse(coordX.InnerText));
                    double dy = (double.Parse(coordY.InnerText));

                    //double dx = ((double.Parse(coordX.InnerText))+130)*7;
                    //double dy = (85-(double.Parse(coordY.InnerText))-20) * 10;
                    
                    Thread.CurrentThread.CurrentCulture = temp_culture;

                    //int x = Int32.Parse(coordX.InnerText)+100;
                    graph.AddVertex(attr.Value, (int)dx, (int)dy);
                    //break;
                }

                XmlNodeList links = doc.SelectNodes("/snd:network/snd:networkStructure/snd:links/snd:link", ns);
                foreach (XmlNode n in links)
                {
                    //XmlNode attr = n.Attributes.GetNamedItem("id");
                    //Console.WriteLine(attr.Value);
                    XmlNode vertex1 = n.SelectSingleNode("snd:source", ns);
                    //Console.WriteLine(vertex1.InnerText);

                    XmlNode vertex2 = n.SelectSingleNode("snd:target", ns);
                    //Console.WriteLine(vertex2.InnerText);

                    //XmlNode cap = n.SelectSingleNode("snd:additionalModules/snd:addModule/snd:capacity", ns);
                    XmlNode cap;
                    cap = n.SelectSingleNode("snd:preInstalledModule/snd:capacity", ns);
                    //Console.WriteLine(cap.InnerText);

                    //Проверка наличия
                    if (cap == null)
                    {
                        cap = n.SelectSingleNode("snd:additionalModules/snd:addModule/snd:capacity", ns);
                    }


                    int v1 = graph.FindVertex(vertex1.InnerText);
                    int v2 = graph.FindVertex(vertex2.InnerText);

                    string capp = cap.InnerText;
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                    double capacity = (double.Parse(cap.InnerText))/1000;
                    //double capacity = (double.Parse(cap.InnerText))/1024;

                    Thread.CurrentThread.CurrentCulture = temp_culture;

                    double cappp = Math.Round(capacity, MidpointRounding.AwayFromZero);
                    graph.AddEdge(v1, v2, (int)cappp);
                    //graph.AddEdge(v1, v2, (int)capacity);
                    //Console.WriteLine(n.InnerText);
                }

                graph.Coord();

            }
        }


    }
}
