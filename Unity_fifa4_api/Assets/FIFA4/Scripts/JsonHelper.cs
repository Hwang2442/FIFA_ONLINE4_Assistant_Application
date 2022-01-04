using System;
using System.IO;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace FIFA4
{
    public static class JsonHelper
    {
        #region Convert

        public static string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public static T FromJson<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        #endregion

        #region Write

        public static void SaveJson(object value, string path)
        {
            File.WriteAllText(path, ToJson(value));
        }

        public static void SaveJson(object value, string path, Encoding encoding)
        {
            File.WriteAllText(path, ToJson(value), encoding);
        }

        #endregion

        #region Read

        public static T LoadJson<T>(string path)
        {
            return FromJson<T>(File.ReadAllText(path));
        }

        public static T LoadJson<T>(string path, Encoding encoding)
        {
            return FromJson<T>(File.ReadAllText(path, encoding));
        }

        public static IEnumerator LoadJson<T>(Action<T> callback, string path)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(new Uri(path).AbsoluteUri))
            {
                yield return www.SendWebRequest();

                callback(FromJson<T>(www.downloadHandler.text));
            }
        }

        public static IEnumerator LoadJson<T>(Action<T> callback, string path, Encoding encoding)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(new Uri(path).AbsoluteUri))
            {
                yield return www.SendWebRequest();

                callback(FromJson<T>(encoding.GetString(www.downloadHandler.data)));
            }
        }

        #endregion
    }
}
