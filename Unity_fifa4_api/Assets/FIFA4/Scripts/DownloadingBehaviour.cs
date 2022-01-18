using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class DownloadingBehaviour : MonoBehaviour
    {
        public bool isUpdated = false;

        private List<IEnumerator> m_requestList = new List<IEnumerator>();

        private void Start()
        {
            var manager = GameManager.Instance;

            manager.UI.DownloadingCanvas.alpha = 0;
            manager.UI.DownloadingCanvas.blocksRaycasts = false;

            manager.UI.DownloadingGaugeImage.transform.parent.gameObject.SetActive(false);
            manager.UI.DownloadingGaugeImage.fillAmount = 0;
            manager.UI.DownloadingPerText.text = "";

            manager.UI.DownloadingPanel.gameObject.SetActive(false);
            manager.UI.DownloadingDescText.text = "";
        }

        public IEnumerator DataUpdate()
        {
            Debug.Log("Checking datas.");

            var manager = GameManager.Instance;

            ulong length = 0;

            if (!Directory.Exists(PathList.MetaDataPath))
                Directory.CreateDirectory(PathList.MetaDataPath);

            manager.Loading.Show("데이터를 확인중입니다...");

            yield return manager.RequestService.UpdateDivision((response) =>
            {
                if (!response.isError)
                {
                    string path = PathList.DivisionPath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetDivision((response_division) =>
                        {
                            JsonHelper.SaveJson(response_division.data.Value, path);
                            File.SetLastWriteTime(path, response_division.data.Key.dateTime);

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                }
            }, null);
            yield return manager.RequestService.UpdateDivision_Volta((response) =>
            {
                if (!response.isError)
                {
                    string path = PathList.Division_VoltaPath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetDivision_Volta((response_division_volta) =>
                        {
                            JsonHelper.SaveJson(response_division_volta.data.Value, path);
                            File.SetLastWriteTime(path, response_division_volta.data.Key.dateTime);

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                }
            }, null);
            yield return manager.RequestService.UpdateMatchType((response) =>
            {
                if (!response.isError)
                {
                    string path = PathList.MatchTypePath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetMatchType((response_matchType) => 
                        {
                            JsonHelper.SaveJson(response_matchType.data.Value, path);
                            File.SetLastWriteTime(path, response_matchType.data.Key.dateTime);

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                }
            }, null);
            yield return manager.RequestService.UpdateSeasonId((response) =>
            {
                if (!response.isError)
                {
                    string path = PathList.SeasonidPath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetSeasonId((response_seasonId) =>
                        {
                            JsonHelper.SaveJson(response_seasonId.data.Value, path);
                            File.SetLastWriteTime(path, response_seasonId.data.Key.dateTime);

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                }
            }, null);
            yield return manager.RequestService.UpdateSpPosition((response) =>
            {
                if (!response.isError)
                {
                    string path = PathList.SpposionPath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetSpPosition((response_spposition) =>
                        {
                            JsonHelper.SaveJson(response_spposition.data.Value, path);
                            File.SetLastWriteTime(path, response_spposition.data.Key.dateTime);

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                }
            }, null);
            yield return manager.RequestService.UpdateSpid((response) =>
            { 
                if (!response.isError)
                {
                    string path = PathList.SpidPath;

                    if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                    {
                        Debug.Log("Need update : " + path);

                        length += response.data.length;
                        m_requestList.Add(manager.RequestService.GetSpid((response_spid) =>
                        {
                            JsonHelper.SaveJson(response_spid.data.Value, path);
                            File.SetLastWriteTime(path, response_spid.data.Key.dateTime);

                            manager.Spid = response_spid.data.Value;

                            Debug.Log("Downloaded data : " + path);
                        }, UpdatePercentage));
                    }
                    else
                    {
                        manager.Spid = JsonHelper.LoadJson<Spid[]>(path);
                    }
                }
            }, null);

            yield return new WaitForSeconds(0.5f);

            if (length > 0)
            {
                manager.Loading.Hide();

                Show();
                manager.UI.DownloadingPanel.gameObject.SetActive(true);
                manager.UI.DownloadingDescText.text = string.Format("{0}MB의 추가 데이터가 있습니다.\n\n업데이트를 진행하시겠습니까?", Mathf.Round(length / (float)(1024 * 1024) * 10) * 0.1f);
            }
            else
            {
                Hide();
                manager.Loading.Hide();

                yield return manager.Login.Hide().WaitForKill();

                manager.Main.Show();
                manager.Main.SetUserInformation(GameManager.Instance.UserInformation);
            }
        }

        public IEnumerator DataDownload()
        {
            Debug.Log("Downloading datas.");

            foreach (var request in m_requestList)
            {
                yield return StartCoroutine(request);
            }

            yield return new WaitForSeconds(0.5f);

            Hide();
            yield return GameManager.Instance.Login.Hide().WaitForKill();

            GameManager.Instance.Main.Show();
            GameManager.Instance.Main.SetUserInformation(GameManager.Instance.UserInformation);
        }

        private void UpdatePercentage(float val)
        {
            var manager = GameManager.Instance;

            manager.UI.DownloadingGaugeImage.fillAmount += val / m_requestList.Count;
            manager.UI.DownloadingPerText.text = string.Format("{0}%", Mathf.FloorToInt(manager.UI.DownloadingGaugeImage.fillAmount * 100));
        }

        public void Show()
        {
            var manager = GameManager.Instance;

            manager.UI.DownloadingCanvas.alpha = 1;
            manager.UI.DownloadingCanvas.blocksRaycasts = true;
        }

        public void Hide()
        {
            var manager = GameManager.Instance;

            manager.UI.DownloadingCanvas.alpha = 0;
            manager.UI.DownloadingCanvas.blocksRaycasts = false;
        }

        public void OnClickDownload_OK()
        {
            var manager = GameManager.Instance;

            StartCoroutine(DataDownload());

            manager.UI.DownloadingGaugeImage.transform.parent.gameObject.SetActive(true);
            manager.UI.DownloadingGaugeImage.fillAmount = 0;
            manager.UI.DownloadingPerText.text = "";
        }

        public void OnClickDownload_NO()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
