/* Modified by Cameron Block From the following web site. 
 * Basically added XML serialization to an already cool expandable class. 
 */
//http://stackoverflow.com/questions/947241/how-do-i-create-dynamic-properties-in-c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace CSDynamicProperties {

    class Program {

        static void Main(string[] args) {

            var obj1 = new ExpandableObject();
            obj1["num"] = 3;
            obj1["name"] = "Cameron Block";
            obj1["phone_num"] = "402-734-0281";
            obj1["email"] = "cnblock@cox.net";

            var obj2 = new ExpandableObject();
            obj2["num"] = 2;
            obj2["name"] = "Glenn Beck";
            obj2["phone_num"] = "402-555-5555";

            var obj3 = new ExpandableObject();
            obj3["num"] = 1;
            obj3["name"] = "Bill Oriley";
            obj3["phone_num"] = "402-555-5555";

            var objects = new List<ExpandableObject>(new ExpandableObject[] { obj1, obj2, obj3 });

            // sorting:
            Console.WriteLine("Sorting:");
            Comparer<int> c = new Comparer<int>("num");
            objects.Sort(c);
            foreach (var obj in objects) {
                Console.WriteLine(obj.ToString() + "\n");
            }//end for

            // filtering:
            Console.WriteLine("Filtering:");
            var filtered = from obj in objects
                           where (int)obj["num"] >= 2
                           select obj;
            foreach (var obj in filtered) {
                Console.WriteLine(obj.ToString() + "\n");
            }

            Console.WriteLine("XML Serializing to file: ");

            string path = @"..\NSA_DB.xml";
            XmlSerializer x = new XmlSerializer(obj1.GetType());
            StreamWriter writer = new StreamWriter(path);
            x.Serialize(writer, obj1);
            writer.Close();

            //make sure the serialization works
            obj1 = null;
            Console.WriteLine();
            
            //the following code not working right, error in serialization file. 
            x = new XmlSerializer(typeof(ExpandableObject));
            StreamReader reader = new StreamReader(path);
            obj1 = (ExpandableObject)x.Deserialize(reader);

            Console.WriteLine("Deserialized output: \n");
            Console.WriteLine(obj1.ToString());

            Console.ReadLine();
        }//end main

        public static void SerializeExpandableObject(ExpandableObject obj){
         	var serializer = new DataContractSerializer(typeof(ExpandableObject));
            string xmlString;
            using (var sw = new StringWriter())
            {
                using (var writer = new System.Xml.XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented; // indent the Xml so it's human readable
                    serializer.WriteObject(writer, obj);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }

            Console.WriteLine(xmlString);
        }//end method

    }//end class

    public class ExpandableObject : IXmlSerializable {
        //hopefully a better, XML serializable ExpandoObject
        Dictionary<string, object> properties = new Dictionary<string, object>();

        public ExpandableObject() { }

        public object this[string name] {
            get {
                if (properties.ContainsKey(name)) {
                    return properties[name];
                }
                return null;
            }
            set {
                properties[name] = value;
            }
        }//end method

        public override string ToString() {
            StringBuilder str = new StringBuilder();

            str.Append(this.GetType().Name + "\n");

            foreach(KeyValuePair<string, object> entry in properties)
                str.Append(entry.Key+ ": " + entry.Value.ToString() + "\n");
            
            return str.ToString();
        }//end method


        public System.Xml.Schema.XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader) {
            properties.Clear();
            reader.MoveToContent();

            reader.ReadStartElement();

            if (!reader.IsEmptyElement) {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                List<Entry> list = (List<Entry>)serializer.Deserialize(reader);

                foreach (Entry entry in list)
                    properties[entry.Key] = entry.Value;

                reader.ReadEndElement();
            }
        }//end method

        public void WriteXml(System.Xml.XmlWriter writer) {
            List<Entry> entries = new List<Entry>(properties.Count);

            foreach (String key in properties.Keys)
                entries.Add(new Entry(key, properties[key]));
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            serializer.Serialize(writer, entries);
        }//end method
    }//end class

    /*Class: Entry
      Purpose: allow conversion of dictionary values to XML. */
    public class Entry {
        public string Key;
        public object Value;

        public Entry() { }

        public Entry(string key, object value) {
            Key = key;
            Value = value;
        }//end constructor
    }//end class

    class Comparer<T> : IComparer<ExpandableObject> where T : IComparable {

        string m_attributeName;

        public Comparer(string attributeName) {
            m_attributeName = attributeName;
        }

        public int Compare(ExpandableObject x, ExpandableObject y) {
            return ( (T)x[m_attributeName] ).CompareTo((T)y[m_attributeName]);
        }

    }//end class

}//end namespace
