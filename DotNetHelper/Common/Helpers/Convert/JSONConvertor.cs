using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Convert
{
    public static class JSON
    {
        /// <summary>
        /// Serialize object to JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="enableCamelCase">Obeys the CamelCase rules</param>
        /// <returns></returns>
        public static string Serialize(object obj, bool enableCamelCase = true)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            if (enableCamelCase)
            {
                return JsonConvert.SerializeObject(obj,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }

            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// De serialize string to any model you want
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedValue"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string serializedValue)
        {
            return string.IsNullOrEmpty(serializedValue)
                ? default(T)
                : JsonConvert.DeserializeObject<T>(serializedValue);
        }

        #region Extension
        /// <summary>
        /// Serialize object to JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="enableCamelCase">Obeys the CamelCase rules</param>
        /// <returns></returns>
        public static string ToJson<T>(this T value, bool enableCamelCase = true)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return Serialize(value, enableCamelCase);
        }

        /// De serialize string to any model you want
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedValue"></param>
        /// <returns></returns>
        public static T ToModel<T>(this string serializedValue)
        {
            return Deserialize<T>(serializedValue)
        }
        #endregion
    }
}
