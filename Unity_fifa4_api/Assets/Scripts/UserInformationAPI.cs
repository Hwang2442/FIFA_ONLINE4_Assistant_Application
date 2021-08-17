using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserInformationAPI : MonoBehaviour
{
    FIFAManager manager
    {
        get { return FIFAManager.Instance; }
    }

    

    private void Start()
    {
        StartCoroutine(Co_InquireNameToInformation("한솥치킨마요"));
    }

    IEnumerator Co_InquireNameToInformation(string nickname)
    {
        string requestText = "https://api.nexon.co.kr/fifaonline4/v1.0/users?nickname=" + nickname;

        if (!manager)
        {
            yield return StartCoroutine(manager.Co_GetRequest(requestText));

            if (manager.ResponseText != string.Empty)
            {

            }
        }
    }

    IEnumerator Co_InquireAccessIdToRating(string accessId)
    {
        string requestText = string.Format("https://api.nexon.co.kr/fifaonline4/v1.0/users/{0}/maxdivision", accessId);

        if (!manager)
        {
            yield return StartCoroutine(manager.Co_GetRequest(requestText));

            if (manager.ResponseText != string.Empty)
            {

            }
        }
    }
}
