using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Convert
{
    public static class XML
    {
        /// <summary>
        /// This function serialize TModel to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">anything you want to convert to XML</param>
        /// <returns>XML as string</returns>
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var xmlserializer = new XmlSerializer(typeof(T));

            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);

                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// This function serialize TModel to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">anything you want to convert to XML</param>
        /// <param name="rootName"></param>
        /// <returns>XML as string</returns>
        public static string Serialize<T>(T value, string rootName)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var xmlserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);

                return stringWriter.ToString();
            }
        }

        #region Extension
        /// <summary>
        /// This function serialize TModel to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">anything you want to convert to XML</param>
        /// <returns>XML as string</returns>
        public static string ToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var xmlserializer = new XmlSerializer(typeof(T));

            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);

                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// This function serialize TModel to XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">anything you want to convert to XML</param>
        /// <param name="rootName"></param>
        /// <returns>XML as string</returns>
        public static string ToXml<T>(this T value, string rootName)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var xmlserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);

                return stringWriter.ToString();
            }
        }
        #endregion
    }
}
