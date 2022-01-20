using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class DownloadingBehaviour : MonoBehaviour
    {
        #region Class definition

        [System.Serializable]
        public class OnDownloadingFailed : UnityEvent<string> { }

        #endregion

        static bool isUpdated = false;

        [SerializeField] CanvasGroup m_canvas;

        [Header("Download progress")]
        [SerializeField] Image m_progressImage;
        [SerializeField] TextMeshProUGUI m_percentageText;

        [Header("Panel")]
        [SerializeField] Image m_descriptionPanel;
        [SerializeField] TextMeshProUGUI m_descriptionText;

        [Header("Event")]
        [SerializeField] UnityEvent m_onDownloadingEnded = new UnityEvent();
        [SerializeField] OnDownloadingFailed m_onDownloadingFailed = new OnDownloadingFailed();

        private List<IEnumerator> m_requestList = new List<IEnumerator>();

        #region Properties

        public UnityEvent OnEnded { get { return m_onDownloadingEnded; } }
        public OnDownloadingFailed OnFailed { get { return m_onDownloadingFailed; } }

        #endregion

        public void DownloadingStart()
        {
            if (isUpdated)
            {
                m_onDownloadingEnded.Invoke();

                return;
            }

            gameObject.SetActive(true);

            m_canvas.alpha = 0;
            m_canvas.blocksRaycasts = false;

            if (!Directory.Exists(PathList.MetaDataPath))
                Directory.CreateDirectory(PathList.MetaDataPath);

            StartCoroutine(Co_DataUpdate(GameManager.Instance));
        }

        private IEnumerator Co_DataUpdate(GameManager manager)
        {
            Debug.Log("Checking datas...");

            ulong totalLength = 0;

            manager.Loading.Show("데이터를 확인중입니다...");

            yield return manager.RequestService.UpdateDivision((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.DivisionPath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetDivision((response_division) =>
                    {
                        if (response_division.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_division.data.Value, path);
                        File.SetLastWriteTime(path, response_division.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);
            yield return manager.RequestService.UpdateDivision_Volta((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.Division_VoltaPath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetDivision_Volta((response_division_volta) =>
                    {
                        if (response_division_volta.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_division_volta.data.Value, path);
                        File.SetLastWriteTime(path, response_division_volta.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);
            yield return manager.RequestService.UpdateMatchType((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.MatchTypePath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetMatchType((response_matchType) =>
                    {
                        if (response_matchType.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_matchType.data.Value, path);
                        File.SetLastWriteTime(path, response_matchType.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);
            yield return manager.RequestService.UpdateSeasonId((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.SeasonidPath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetSeasonId((response_seasonId) =>
                    {
                        if (response_seasonId.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_seasonId.data.Value, path);
                        File.SetLastWriteTime(path, response_seasonId.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);
            yield return manager.RequestService.UpdateSpPosition((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.SpposionPath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetSpPosition((response_spposition) =>
                    {
                        if (response_spposition.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_spposition.data.Value, path);
                        File.SetLastWriteTime(path, response_spposition.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);
            yield return manager.RequestService.UpdateSpid((response) =>
            {
                if (response.isError)
                {
                    m_onDownloadingFailed.Invoke("데이터 확인에 실패했습니다.\n인터넷을 확인해주세요.");

                    return;
                }

                string path = PathList.SpidPath;

                if (!File.Exists(path) || response.data.dateTime != File.GetLastWriteTime(path))
                {
                    Debug.Log("Need update : " + path);

                    totalLength += response.data.length;
                    m_requestList.Add(manager.RequestService.GetSpid((response_spid) =>
                    {
                        if (response_spid.isError)
                        {
                            m_onDownloadingFailed.Invoke("데이터를 다운로드할 수 없습니다.\n인터넷을 확인해주세요.");

                            return;
                        }

                        JsonHelper.SaveJson(response_spid.data.Value, path);
                        File.SetLastWriteTime(path, response_spid.data.Key.dateTime);

                        Debug.Log("Downloaded data : " + path);
                    }, UpdatePercentage));
                }
            }, null);

            yield return new WaitForSeconds(0.2f);

            manager.Loading.Hide();

            if (totalLength > 0)
            {
                m_canvas.alpha = 1;
                m_canvas.blocksRaycasts = true;

                m_descriptionPanel.gameObject.SetActive(true);
                m_descriptionText.text = string.Format("{0}MB의 추가 데이터가 있습니다.\n\n업데이트를 진행하시겠습니까?", Mathf.Round(totalLength / (float)(1024 * 1024) * 10) * 0.1f);
            }
            else
            {
                isUpdated = true;
                m_onDownloadingEnded.Invoke();
            }
        }

        private IEnumerator Co_DateDownload(GameManager manager)
        {
            Debug.Log("Downloading datas...");

            foreach (var request in m_requestList)
            {
                yield return StartCoroutine(request);
            }

            yield return new WaitForSeconds(0.2f);

            m_canvas.alpha = 0;
            m_canvas.blocksRaycasts = false;

            isUpdated = true;
            m_onDownloadingEnded.Invoke();
        }

        private void UpdatePercentage(float val)
        {
            m_progressImage.fillAmount += val / m_requestList.Count;
            m_percentageText.text = string.Format("{0}%", Mathf.FloorToInt(m_progressImage.fillAmount * 100));
        }

        public void OnClickDownload_OK()
        {
            // Hide description paenl.
            m_descriptionPanel.gameObject.SetActive(false);

            // Show Progress image.
            m_progressImage.rectTransform.parent.gameObject.SetActive(true);
            m_progressImage.fillAmount = 0;
            m_percentageText.text = "";

            StartCoroutine(Co_DateDownload(GameManager.Instance));
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
