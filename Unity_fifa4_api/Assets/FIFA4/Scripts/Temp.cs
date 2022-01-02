using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using FIFA4;

public class Temp : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return null;

        using (UnityWebRequest www = UnityWebRequest.Get(new System.Uri(APIList.GetUserInformationFromNickname("한솥치킨마요")).AbsoluteUri))
        {
            www.SetRequestHeader("Authorization", KeyToken.Key);

            yield return www.SendWebRequest();

            //Debug.Log(www.downloadHandler.text);
            Debug.Log(www.downloadedBytes);
            Debug.Log(www.GetResponseHeader("Date"));
        }
    }
}
