using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FIFAManager : MonoBehaviour
{
    public static FIFAManager Instance { get; private set; }

    [Header("API property")]
    [SerializeField] UserInformationAPI m_userInformationAPI;

    [Header("User database")]
    [SerializeField] 

    public readonly string applicationKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiMzg2MTE4MjQzIiwiYXV0aF9pZCI6IjIiLCJ0b2tlbl90eXBlIjoiQWNjZXNzVG9rZW4iLCJzZXJ2aWNlX2lkIjoiNDMwMDExNDgxIiwiWC1BcHAtUmF0ZS1MaW1pdCI6IjUwMDoxMCIsIm5iZiI6MTYyODY5MjM1NCwiZXhwIjoxNjQ0MjQ0MzU0LCJpYXQiOjE2Mjg2OTIzNTR9.cbfC5zQkiR-AZDqOTpWA8PG_bZfMgwSwHZohxvKxiuo";

    public string ResponseText { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    public IEnumerator Co_GetRequest(string requestText)
    {
        ResponseText = string.Empty;

        using (UnityWebRequest www = UnityWebRequest.Get(requestText))
        {
            www.SetRequestHeader("Authorization", applicationKey);

            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                ResponseText = www.downloadHandler.text;
            }
        }
    }

    #region Database class

    [Serializable]
    public class UserInformation
    {
        public string accessId;
        public string nickname;
        public int level;
    }

    public class HighestRatingEver
    {
        public int matchType;
    }

    #endregion
}
