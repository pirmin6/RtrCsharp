using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoomProject.Socket
{
    class SerializationJSON
    {
        public static string WriteObject(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Object));
            ser.WriteObject(memoryStream, obj);
            byte[] json = memoryStream.ToArray();
            memoryStream.Close();

            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public static Object ReadToObject(string json)
        {
            Object deserializedObject = new Object();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedObject.GetType());
            deserializedObject = ser.ReadObject(ms) as Object;
            ms.Close();
            return deserializedObject;
        }
    }
}
