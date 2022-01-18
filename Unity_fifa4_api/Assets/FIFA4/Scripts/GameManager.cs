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

        [Header("UI")]
        [SerializeField] UIManager m_ui;

        [Header("Behaviours")]
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

        public UIManager UI => m_ui;

        #region Behaviours

        public LoginBehaviour Login => m_login;

        public LoadingBehaviour Loading => m_loading;
        public DownloadingBehaviour Downloading => m_downloading;

        public NotificationBehaviour Notification => m_notification;

        #endregion

        public Request RequestService => m_request;

        public UserInformation UserInformation 
        {
            get => m_user;
            set => m_user = value;
        }

        public Spid[] Spid
        {
            get => m_spid;
            set => m_spid = value;
        }

        #endregion

        private void Awake()
        {
            Instance = this;

            m_request = new Request();
        }
    }
}
