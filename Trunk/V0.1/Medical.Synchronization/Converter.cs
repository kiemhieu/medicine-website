using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Medical.Synchronization
{
    /// <summary>
    ///  Convert 2 object with the same structure
    /// </summary>
    /// <typeparam name="TInput">Class input</typeparam>
    /// <typeparam name="TOutput">Class output</typeparam>
    public class Converter<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        /// <summary>
        /// Convert an ICollection  to another ICollection
        /// </summary>
        /// <param name="structure"></param>
        /// <returns></returns>
        public static List<TOutput> Convert(List<TInput> structure)
        {
            List<TOutput> result = null;
            using (Stream data = new MemoryStream())
            {
                new XmlSerializer(typeof(List<TInput>)).Serialize(data, structure);
                data.Seek(0, SeekOrigin.Begin);
                result = (List<TOutput>)new XmlSerializer(typeof(List<TOutput>)).Deserialize(data);
            }
            return result;
        }

        public static TOutput Convert(TInput structure)
        {
            TOutput result = null;
            using (Stream data = new MemoryStream())
            {
                new XmlSerializer(typeof(TInput)).Serialize(data, structure);
                data.Seek(0, SeekOrigin.Begin);
                result = (TOutput)new XmlSerializer(typeof(TOutput)).Deserialize(data);
            }
            return result;
        }

        public static TOutput[] Convert(TInput[] structure)
        {
            TOutput[] result = null;
            using (Stream data = new MemoryStream())
            {
                new XmlSerializer(typeof(TInput[])).Serialize(data, structure);
                data.Seek(0, SeekOrigin.Begin);
                result = (TOutput[])new XmlSerializer(typeof(TOutput[])).Deserialize(data);
            }
            return result;
        }
    }
}
