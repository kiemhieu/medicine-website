using System.Configuration;

namespace Run.Implementation
{
    public class ConfigHandler : IConfigurationSectionHandler
    {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section"></param>
        /// <returns>The created section handler object.</returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            var configer = new ContainerConfiger
                               {
                                   ClassName = section.SelectSingleNode("ClassName").InnerText ?? string.Empty,
                                   ConfigFile =
                                       section.SelectSingleNode("ConfigFile") == null
                                           ? string.Empty
                                           : section.SelectSingleNode("ConfigFile").InnerText
                               };
            return configer;
        }
    }

    public class ContainerConfiger
    {
        public string ClassName { get; set; }


        public string ConfigFile { get; set; }
    }
}
