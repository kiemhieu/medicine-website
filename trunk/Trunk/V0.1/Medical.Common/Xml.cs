using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Medical.Common
{
    public class Xml
    {
        public T Load<T>(String path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                var i = (T)serializer.Deserialize(reader);
                return i;
            }
        }
    }
}
