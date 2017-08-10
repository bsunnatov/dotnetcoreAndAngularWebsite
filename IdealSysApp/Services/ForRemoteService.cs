using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IdealSysApp.Services
{
  public static class ForRemoteService
  {

 
    public static void FromXML(string file)
    {

    }
    public static Stream ToStream(this string @this)
    {
      var stream = new MemoryStream();
      var writer = new StreamWriter(stream);
      writer.Write(@this);
      writer.Flush();
      stream.Position = 0;
      return stream;
    }

    public static T ParseXML<T>(this string @this) where T : class
    {
      var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Auto});
      return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
    }
    public static T DeserializeXMLFileToObject<T>(string path)
    {
      T returnObject = default(T);
      XmlSerializer formatter = new XmlSerializer(typeof(T));
      if (string.IsNullOrEmpty(path)) return default(T);

      try
      {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
          returnObject = (T)formatter.Deserialize(fs);
        }
       
      }
      catch (Exception ex)
      {
       
      }
      return returnObject;
    }
  }
}
