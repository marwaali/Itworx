using System;
using System.IO;
using System.Xml.Serialization;

namespace ITWorx.Utlities
{
    public class XmlUtlities
    {
        /// <summary>
        /// De-serialize xml to object
        /// </summary>
        public static T DeserializeXMLFileToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message, DateTime.Now);
            }
            return returnObject;
        }

        /// <summary>
        /// De-serialize XML
        /// </summary>
        public DataList Deserialize(string path)
        {
            return DeserializeXMLFileToObject<DataList>(path);
        }
    }
}
