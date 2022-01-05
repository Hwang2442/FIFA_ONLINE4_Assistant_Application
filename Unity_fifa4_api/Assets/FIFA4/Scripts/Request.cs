using System;
using System.IO;
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
        #region User information

        public IEnumerator GetUserInformation(UnityAction<Response<UserInformation>> callback, UnityAction<float> onUpdate, string nickname)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetUserInformationFromNickname(nickname)))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<UserInformation>(www, JsonHelper.FromJson<UserInformation>(www.downloadHandler.text)));
            }
        }

        public IEnumerator GetHighestGradeEver(UnityAction<Response<HighestGradeEver>> callback, UnityAction<float> onUpdate, string accessid)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetHighestGradeEverFromAccessid(accessid)))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<HighestGradeEver>(www, JsonHelper.FromJson<HighestGradeEver>(www.downloadHandler.text)));
            }
        }

        public IEnumerator GetPurchaseRecords(UnityAction<Response<TransactionRecords[]>> callback, UnityAction<float> onUpdate, string accessid, int offset = 0, int limit = 100)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetPurchaseRecordsFromAccessid(accessid, offset, limit)))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<TransactionRecords[]>(www, JsonHelper.FromJson<TransactionRecords[]>(www.downloadHandler.text)));
            }
        }

        public IEnumerator GetSalesRecord(UnityAction<Response<TransactionRecords[]>> callback, UnityAction<float> onUpdate, string accessid, int offset = 0, int limit = 100)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSalesRecordFromAccessid(accessid, offset, limit)))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<TransactionRecords[]>(www, JsonHelper.FromJson<TransactionRecords[]>(www.downloadHandler.text)));
            }
        }

        #endregion

        #region Meta information

        public IEnumerator UpdateMatchType(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetMatchType()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<DateTime>(www, DateTime.Parse(www.GetResponseHeader("Last-Modified"))));
            }
        }

        public IEnumerator GetMatchType(UnityAction<Response<KeyValuePair<DateTime, MatchType[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetMatchType()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, MatchType[]>>(www, new KeyValuePair<DateTime, MatchType[]>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<MatchType[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSpid(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = HeadRequest(APIList.GetSpid()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<DateTime>(www, DateTime.Parse(www.GetResponseHeader("Last-Modified"))));
            }
        }

        public IEnumerator GetSpid(UnityAction<Response<KeyValuePair<DateTime, Spid[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSpid()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, Spid[]>>(www, new KeyValuePair<DateTime, Spid[]>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<Spid[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSeasonId(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = HeadRequest(APIList.GetSeasonId()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<DateTime>(www, DateTime.Parse(www.GetResponseHeader("Last-Modified"))));
            }
        }

        public IEnumerator GetSeasonId(UnityAction<Response<KeyValuePair<DateTime, SeasonId>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSeasonId()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, SeasonId>>(www, new KeyValuePair<DateTime, SeasonId>(DateTime.Parse("Last-Modified"), JsonHelper.FromJson<SeasonId>(www.downloadHandler.text))));
            }
        }

        #endregion

        #region UnityWebRequest utility

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

        private IEnumerator SendRequest(UnityWebRequest www, UnityAction<float> onUpdate)
        {
            www.SendWebRequest();

            while (!www.isDone)
            {
                if (onUpdate != null)
                    onUpdate(www.downloadProgress);

                yield return null;
            }
        }

        #endregion

        public IEnumerator GetImage(UnityAction<Response<Sprite>> callback, UnityAction<float> onUpdate, string resourcesPath, string savePath = "")
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(new Uri(resourcesPath).AbsoluteUri))
            {
                yield return SendRequest(www, onUpdate);

                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                callback(new Response<Sprite>(www, Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f))));

                if (!string.IsNullOrEmpty(savePath))
                    File.WriteAllBytes(savePath, www.downloadHandler.data);
            }
        }
    }
}
