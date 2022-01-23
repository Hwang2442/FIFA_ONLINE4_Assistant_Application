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

        public IEnumerator UpdateMatchType(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetMatchType());
        }

        public IEnumerator GetMatchType(UnityAction<Response<KeyValuePair<Properties, MatchType[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetMatchType()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, MatchType[]>>(www, new KeyValuePair<Properties, MatchType[]>(new Properties(www), JsonHelper.FromJson<MatchType[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSpid(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetSpid());
        }

        public IEnumerator GetSpid(UnityAction<Response<KeyValuePair<Properties, Spid[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSpid()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, Spid[]>>(www, new KeyValuePair<Properties, Spid[]>(new Properties(www), JsonHelper.FromJson<Spid[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSeasonId(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetSeasonId());
        }

        public IEnumerator GetSeasonId(UnityAction<Response<KeyValuePair<Properties, SeasonId[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSeasonId()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, SeasonId[]>>(www, new KeyValuePair<Properties, SeasonId[]>(new Properties(www), JsonHelper.FromJson<SeasonId[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateSpPosition(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetSpposition());
        }

        public IEnumerator GetSpPosition(UnityAction<Response<KeyValuePair<Properties, SpPosition[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetSpposition()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, SpPosition[]>>(www, new KeyValuePair<Properties, SpPosition[]>(new Properties(www), JsonHelper.FromJson<SpPosition[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateDivision(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetDivision());
        }

        public IEnumerator GetDivision(UnityAction<Response<KeyValuePair<Properties, Division[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetDivision()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, Division[]>>(www, new KeyValuePair<Properties, Division[]>(new Properties(www), JsonHelper.FromJson<Division[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdateDivision_Volta(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetDivision_Volta());
        }

        public IEnumerator GetDivision_Volta(UnityAction<Response<KeyValuePair<Properties, Division[]>>> callback, UnityAction<float> onUpdate)
        {
            using (UnityWebRequest www = GetRequest(APIList.GetDivision_Volta()))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<KeyValuePair<Properties, Division[]>>(www, new KeyValuePair<Properties, Division[]>(new Properties(www), JsonHelper.FromJson<Division[]>(www.downloadHandler.text))));
            }
        }

        public IEnumerator UpdatePlayerActionImageFromSpid(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate, int spid)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetPlayerActionImageFromSpid(spid));
        }

        public IEnumerator GetPlayerActionImageFromSpid(UnityAction<Response<KeyValuePair<Properties, Sprite>>> callback, UnityAction<float> onUpdate, int spid, string savePath = "")
        {
            using (UnityWebRequest www = ImageRequest(APIList.GetPlayerActionImageFromSpid(spid)))
            {
                yield return SendRequest(www, onUpdate);

                if (www.downloadedBytes <= 0)
                {
                    Debug.LogWarning("Response body is empty..");
                    callback(null);

                    yield break;
                }

                if (!string.IsNullOrEmpty(savePath) && !File.Exists(savePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                    File.WriteAllBytes(savePath, www.downloadHandler.data);
                    File.SetLastWriteTime(savePath, DateTime.Parse(www.GetResponseHeader("Last-Modified")));
                }

                if (callback != null)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    callback(new Response<KeyValuePair<Properties, Sprite>>(www, new KeyValuePair<Properties, Sprite>(new Properties(www), sprite)));
                }
            }
        }

        public IEnumerator UpdatePlayerActionImageFromPid(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate, int spid)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetPlayerActionImageFromPid(spid % 1000000));
        }

        public IEnumerator GetPlayerActionImageFromPid(UnityAction<Response<KeyValuePair<Properties, Sprite>>> callback, UnityAction<float> onUpdate, int spid, string savePath = "")
        {
            using (UnityWebRequest www = ImageRequest(APIList.GetPlayerActionImageFromSpid(spid % 1000000)))
            {
                yield return SendRequest(www, onUpdate);

                if (www.downloadedBytes <= 0)
                {
                    Debug.LogWarning("Response body is empty..");
                    callback(null);

                    yield break;
                }

                if (!string.IsNullOrEmpty(savePath) && !File.Exists(savePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                    File.WriteAllBytes(savePath, www.downloadHandler.data);
                    File.SetLastWriteTime(savePath, DateTime.Parse(www.GetResponseHeader("Last-Modified")));
                }

                if (callback != null)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    callback(new Response<KeyValuePair<Properties, Sprite>>(www, new KeyValuePair<Properties, Sprite>(new Properties(www), sprite)));
                }
            }
        }

        public IEnumerator UpdatePlayerImageFromSpid(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate, int spid)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetPlayerImageFromSpid(spid));
        }

        public IEnumerator GetPlayerImageFromSpid(UnityAction<Response<KeyValuePair<Properties, Sprite>>> callback, UnityAction<float> onUpdate, int spid, string savePath = "")
        {
            using (UnityWebRequest www = ImageRequest(APIList.GetPlayerImageFromSpid(spid)))
            {
                yield return SendRequest(www, onUpdate);

                if (www.downloadedBytes <= 0)
                {
                    Debug.LogWarning("Response body is empty..");
                    callback(null);

                    yield break;
                }

                if (!string.IsNullOrEmpty(savePath) && !File.Exists(savePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                    File.WriteAllBytes(savePath, www.downloadHandler.data);
                    File.SetLastWriteTime(savePath, DateTime.Parse(www.GetResponseHeader("Last-Modified")));
                }

                if (callback != null)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    callback(new Response<KeyValuePair<Properties, Sprite>>(www, new KeyValuePair<Properties, Sprite>(new Properties(www), sprite)));
                }
            }
        }

        public IEnumerator UpdatePlayerImageFromPid(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate, int spid)
        {
            yield return UpdateRequest(callback, onUpdate, APIList.GetPlayerImageFromPid(spid % 1000000));
        }

        public IEnumerator GetPlayerImageFromPid(UnityAction<Response<KeyValuePair<Properties, Sprite>>> callback, UnityAction<float> onUpdate, int spid, string savePath = "")
        {
            using (UnityWebRequest www = ImageRequest(APIList.GetPlayerImageFromPid(spid % 1000000)))
            {
                yield return SendRequest(www, onUpdate);

                if (www.downloadedBytes <= 0)
                {
                    Debug.LogWarning("Response body is empty..");
                    callback(null);

                    yield break;
                }

                if (!string.IsNullOrEmpty(savePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                    File.WriteAllBytes(savePath, www.downloadHandler.data);
                    File.SetLastWriteTime(savePath, DateTime.Parse(www.GetResponseHeader("Last-Modified")));
                }

                if (callback != null)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                    callback(new Response<KeyValuePair<Properties, Sprite>>(www, new KeyValuePair<Properties, Sprite>(new Properties(www), sprite)));
                }
            }
        }

        public IEnumerator GetPlayerImage(MonoBehaviour sender, UnityAction<Response<KeyValuePair<Properties, Sprite>>> remoteCallback, UnityAction<Response<Sprite>> localCallback, int spid)
        {
            if (!Directory.Exists(PathList.ActionImagePath))
                Directory.CreateDirectory(PathList.ActionImagePath);
            if (!Directory.Exists(PathList.ImagePath))
                Directory.CreateDirectory(PathList.ImagePath);

            IEnumerator coroutine = null;

            yield return UpdatePlayerActionImageFromSpid((response) =>
            {
                if (response.isError)
                    return;

                string path = PathList.GetPlayersActionImagePath(spid);
                coroutine = (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path) ? GetPlayerActionImageFromSpid(remoteCallback, null, spid, path) : GetImage(localCallback, null, path));
            }, null, spid);

            if (coroutine != null)
            {
                yield return coroutine;
                yield break;
            }

            yield return UpdatePlayerImageFromSpid((response) =>
            {
                if (response.isError)
                    return;

                string path = PathList.GetPlayerImagePath(spid);
                coroutine = (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path) ? GetPlayerImageFromSpid(remoteCallback, null, spid, path) : GetImage(localCallback, null, path));
            }, null, spid);

            if (coroutine != null)
            {
                yield return coroutine;
                yield break;
            }

            yield return UpdatePlayerActionImageFromPid((response) =>
            {
                if (response.isError)
                    return;

                string path = PathList.GetPlayersActionImagePath(spid % 1000000);
                coroutine = (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path) ? GetPlayerActionImageFromPid(remoteCallback, null, spid, path) : GetImage(localCallback, null, path));
            }, null, spid);

            if (coroutine != null)
            {
                yield return coroutine;
                yield break;
            }

            yield return UpdatePlayerImageFromSpid((response) =>
            {
                if (response.isError)
                    return;

                string path = PathList.GetPlayerImagePath(spid % 1000000);
                coroutine = (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path) ? GetPlayerImageFromPid(remoteCallback, null, spid, path) : GetImage(localCallback, null, path));
            }, null, spid);

            yield return coroutine;
        }

        public IEnumerator GetSeasonImageFromSpid(UnityAction<Response<Sprite>> callback, int spid)
        {
            yield return GetSeasonImage(callback, spid / 1000000);
        }

        public IEnumerator GetSeasonImage(UnityAction<Response<Sprite>> callback, int seasonid)
        {
            bool isRemote = false;
            SeasonId[] seasonidArray = JsonHelper.LoadJson<SeasonId[]>(PathList.SeasonidPath);

            for (int i = 0; i < seasonidArray.Length; i++)
            {
                if (seasonidArray[i].seasonId != seasonid)
                    continue;

                DateTime dateTime;
                string path;

                using (UnityWebRequest www = HeadRequest(seasonidArray[i].seasonImgUrl))
                {
                    yield return www.SendWebRequest();

                    dateTime = DateTime.Parse(www.GetResponseHeader("Last-Modified"));
                    path = Path.Combine(Application.persistentDataPath, "season", Path.GetFileName(www.url));

                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                    isRemote = !File.Exists(path) || dateTime != File.GetLastWriteTime(path);

                    yield return GetImage(callback, null, isRemote ? seasonidArray[i].seasonImgUrl : path, isRemote ? path : "");
                }

                break;
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

        private UnityWebRequest ImageRequest(string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(new Uri(url).AbsoluteUri);
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

                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator UpdateRequest(UnityAction<Response<DateTime>> callback, UnityAction<float> onUpdate, string url)
        {
            using (UnityWebRequest www = HeadRequest(url))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<DateTime>(www, DateTime.Parse(www.GetResponseHeader("Last-Modified"))));
            }
        }

        private IEnumerator UpdateRequest(UnityAction<Response<Properties>> callback, UnityAction<float> onUpdate, string url)
        {
            using (UnityWebRequest www = HeadRequest(url))
            {
                yield return SendRequest(www, onUpdate);

                if (callback != null)
                    callback(new Response<Properties>(www, new Properties(www)));
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
