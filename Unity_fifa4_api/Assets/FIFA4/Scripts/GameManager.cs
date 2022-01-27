using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] CanvasGroup m_canvas;

        [Header("Behaviours")]
        [SerializeField] InformationPanel m_informationPanel;
        [SerializeField] TransactionRecordsPanel m_transactionPanel;
        [SerializeField] LoginBehaviour m_login;
        [SerializeField] LoadingBehaviour m_loading;
        [SerializeField] DownloadingBehaviour m_downloading;
        [SerializeField] NotificationBehaviour m_notification;

        [Header("Informations")]
        [SerializeField] UserInformation m_user;
        [SerializeField] Spid[] m_spid;

        Request m_request;

        #endregion

        #region Properties

        public static GameManager Instance { get; private set; }

        #region Behaviours

        public LoginBehaviour Login { get { return m_login; } }

        public LoadingBehaviour Loading { get { return m_loading; } }
        public DownloadingBehaviour Downloading { get { return m_downloading; } }

        public NotificationBehaviour Notification { get { return m_notification; } }

        #endregion

        public Request RequestService => m_request;

        public UserInformation UserInformation { get { return m_user; }
        }

        public Spid[] Spid { get { return m_spid; } }

        #endregion

        private void Awake()
        {
            Instance = this;

            m_request = new Request();
        }

        private void Start()
        {
            m_canvas.alpha = 0;
            m_canvas.blocksRaycasts = false;

            m_login.gameObject.SetActive(true);
            m_loading.gameObject.SetActive(false);
            m_notification.gameObject.SetActive(false);
            m_downloading.gameObject.SetActive(false);

            SetLoginEvents();
            SetDownloadingEvents();
        }

        private void SetLoginEvents()
        {
            m_login.Failed.AddListener(() => m_notification.Show("닉네임을 찾을 수 없습니다."));
            m_login.Successed.AddListener((user) => 
            {
                m_user = user;
                m_downloading.DownloadingStart();
            });
        }

        private void SetDownloadingEvents()
        {
            m_downloading.OnFailed.AddListener((description) => 
            {
                m_notification.Show(description, () =>
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                });
            });
            m_downloading.OnEnded.AddListener(() =>
            {
                Debug.Log("Main start!!");

                StartCoroutine(Co_DateUpdate());
            });
        }

        #region Button methods

        public void OnClickTransactionButton()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(m_informationPanel.AlphaTweening(m_informationPanel.isHiding ? 1f : 0.1f, 0.5f));
            sequence.Join(m_transactionPanel.ShowAndHide());
        }

        #endregion

        private IEnumerator Co_DateUpdate()
        {
            m_loading.Show("정보를 불러오고 있습니다...");

            m_spid = JsonHelper.LoadJson<Spid[]>(PathList.SpidPath);

            yield return m_transactionPanel.Co_RecordsUpdate(this, null, null);

            m_loading.Hide();

            yield return new WaitForSeconds(0.2f);

            Sequence sequence = DOTween.Sequence().OnStart(() => { m_informationPanel.SetInformation(m_user); m_canvas.alpha = 1; m_canvas.blocksRaycasts = true; });

            sequence.AppendCallback(() => m_canvas.alpha = 0);
            sequence.Append(m_login.Hide());
            sequence.Append(m_informationPanel.Show());
            sequence.Join(m_canvas.DOFade(1, 0.5f).From(0));
        }
    }
}
