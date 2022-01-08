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
            yield return UpdateRequest(callback, onUpdate, APIList.GetMatchType());
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
            yield return UpdateRequest(callback, onUpdate, APIList.GetSpid());
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
            yield return UpdateRequest(callback, onUpdate, APIList.GetSeasonId());
        }

        public IEnumerator GetSeasonId(UnityAction<Response<KeyValuePair<DateTime, SeasonId>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSeasonId()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, SeasonId>>(www, new KeyValuePair<DateTime, SeasonId>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<SeasonId>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSpPosition(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetSpposition());
        }

        public IEnumerator GetSpPosition(UnityAction<Response<KeyValuePair<DateTime, SpPosition>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSpposition()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, SpPosition>>(www, new KeyValuePair<DateTime, SpPosition>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<SpPosition>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateDivision(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetDivision());
        }

        public IEnumerator GetDivision(UnityAction<Response<KeyValuePair<DateTime, Division>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetDivision()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, Division>>(www, new KeyValuePair<DateTime, Division>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<Division>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateDivision_Volta(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetDivision_Volta());
        }

        public IEnumerator GetDivision_Volta(UnityAction<Response<KeyValuePair<DateTime, Division>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetDivision_Volta()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<DateTime, Division>>(www, new KeyValuePair<DateTime, Division>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), JsonHelper.FromJson<Division>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdatePlayerActionImageFromSpid(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate, int spid)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetPlayerActionImageFromSpid(spid));
        }

        public IEnumerator GetPlayerActionImageFromSpid(UnityAction<Response<KeyValuePair<DateTime, Sprite>>> callback, UnityAction<float> onUpdate, int spid, string savePath = "")
        {
            using (UnityWebRequest www = GetRequest(APIList.GetPlayerActionImageFromSpid(spid)))
            {
                yield return SendRequest(www, onUpdate);

                if (www.downloadedBytes <= 0)
                {
                    Debug.LogError("Response body is empty!!");
                    callback(null);

                    yield break;
                }

                if (!string.IsNullOrEmpty(savePath))
                    File.WriteAllBytes(savePath, www.downloadHandler.data);

                if (callback != null)
                {
                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(www.downloadHandler.data);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    callback(new Response<KeyValuePair<DateTime, Sprite>>(www, new KeyValuePair<DateTime, Sprite>(DateTime.Parse(www.GetResponseHeader("Last-Modified")), sprite)));
                }
            }
        }

        #endregion

        #region UnityWebRequest utilities

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

        private IEnumerator UpdateRequest(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate, string url)
        {
            using (UnityWebRequest www = HeadRequest(url))
            {
                yield return SendRequest(www, onUpdate);

                callback(new Response<DateTime>(www, DateTime.Parse(www.GetResponseHeader("Last-Modified"))));
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
