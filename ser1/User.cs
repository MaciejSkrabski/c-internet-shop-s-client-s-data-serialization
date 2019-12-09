using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ser1
{

    public class User
    {
        
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private string address;

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();
        private int id;
        public int ID { get { return this.id; } }

        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }

        public User()
        {
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                this.id = nextIndex;


            }

        }
        public void Dispose()
        {
            lock (Lock)
            {
                UsedCounter[ID] = false;
            }
        }

        public void WriteXML(string path)
        {

            XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(this.GetType());


            try
            {
                string file = path + ID.ToString() + ".xml";

                //FileStream file = System.IO.File.Create(path);
                StreamWriter sw = File.CreateText(file);
                writer.Serialize(sw, this);
                sw.Close();
            }
            catch (IOException e) { Console.WriteLine("IOException" + e); }
            catch (Exception e) { Console.WriteLine("Exception" + e); }


        }
    }
}
