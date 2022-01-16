using System;
using UnityEngine.Networking;

namespace FIFA4
{
    public class Response<T>
    {
        public readonly bool isError;
        public readonly string errorMessage;

        public readonly string url;
        public readonly string content;

        public readonly T data;

        public Response(string url, bool isError, string errorMessage, string content, T data)
        {
            this.isError = isError;
            this.errorMessage = errorMessage;

            this.url = url;
            this.content = content;

            this.data = data;
        }

        public Response(UnityWebRequest www, T data)
        {
            this.isError = www.isHttpError || www.isNetworkError;
            this.errorMessage = www.error;

            this.url = www.url;
            //this.content = www.downloadHandler.text;

            this.data = data;
        }
    }

    public class Properties
    {
        public readonly ulong length;
        public readonly DateTime dateTime;

        public Properties(ulong length, DateTime dateTime)
        {
            this.length = length;
            this.dateTime = dateTime;
        }

        public Properties(UnityWebRequest www)
        {
            this.length = ulong.Parse(www.GetResponseHeader("Content-Length"));
            this.dateTime = DateTime.Parse(www.GetResponseHeader("Last-Modified"));
        }
    }
}
