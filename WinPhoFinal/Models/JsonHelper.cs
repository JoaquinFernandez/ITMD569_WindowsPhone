using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PhoneAppTwitter.Models
{

    public static class JsonHelper
    {
        /// <summary>
        /// Serializes an object to a UTF-8 encoded JSON string.
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <returns>JSON string result</returns>
        public static string Serialize(object obj)
        {
            // Serialize to a memory stream....
            MemoryStream ms = new MemoryStream();

            // Serialize to memory stream with DataContractJsonSerializer
            DataContractJsonSerializer s = new DataContractJsonSerializer(obj.GetType());
            s.WriteObject(ms, obj);
            byte[] json = ms.ToArray();
            ms.Close();

            // return utf8 encoded json string
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        /// <summary>
        /// Deserializes an object from a UTF-8 encoded JSON string.
        /// </summary>
        /// <typeparam name="T">type of object to deserialize as</typeparam>
        /// <param name="json">UTF-8 encoded JSON string</param>
        /// <returns>deserialized object</returns>
        public static T Deserialize<T>(string json)
        {
            T result = default(T);

            // load json into memory stream and deserialize
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            result = (T)s.ReadObject(ms);
            ms.Close();

            return result;
        }

        public static T Deserialize<T>(Stream stream)
        {
            T result = default(T);
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            result = (T)s.ReadObject(stream);
            return result;

        }
    }
}

