using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReportGeneration
{
    public class SerializeConfig<T> where T : class
    {
        public static void Serialize(string path, T type)
        {
            var serializer = new XmlSerializer(type.GetType());
            using (var writer = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(writer, type);
            }
        }

        public static T DeSerialize(string fileName)
        {
            T type;
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ReportGeneration.TestData." + fileName);

            using (StreamReader read = new StreamReader(stream))
            {
                using (var reader = XmlReader.Create(read))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    type = serializer.Deserialize(reader) as T;
                }

            }
            return type;
        }
    }
}
