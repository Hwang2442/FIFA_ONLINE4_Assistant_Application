using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace FIFA4
{
    public enum Method
    {
        GET,
        HEAD
    }

    public class Request
    {
        

        private UnityWebRequest GetRequest(string url)
        {
            UnityWebRequest www = UnityWebRequest.Get(new Uri(url).AbsoluteUri);
            www.SetRequestHeader("Authorization", KeyToken.Key);

            return www;
        }

        private UnityWebRequest HeadRequest(string url)
        {
            UnityWebRequest www = UnityWebRequest.Head(new Uri(url).AbsoluteUri);
            www.SetRequestHeader("Authorization", KeyToken.Key);

            return www;
        }
    }
}
