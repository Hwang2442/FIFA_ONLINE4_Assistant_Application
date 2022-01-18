using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FIFA4
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [Header("Login UI")]
        [SerializeField] CanvasGroup m_loginCanvas;
        [SerializeField] TMP_InputField m_loginNicknameField;
        [SerializeField] Toggle m_loginRememberToggle;
        [SerializeField] Button m_loginButton;

        [Header("Main UI")]
        [SerializeField] CanvasGroup m_mainCanvas;
        [SerializeField] Image m_userInformationPanel;
        [SerializeField] Image m_portraitImage;
        [SerializeField] TextMeshProUGUI m_nicknameText;
        [SerializeField] TextMeshProUGUI m_levelText;
        [SerializeField] ScrollRect m_highestGradeEverScroll;

        [Header("Loading UI")]
        [SerializeField] CanvasGroup m_loadingCanvas;
        [SerializeField] RectTransform m_loadingProgressImage;
        [SerializeField] TextMeshProUGUI m_loadingDescText;

        [Header("Downloading UI")]
        [SerializeField] CanvasGroup m_downloadingCanvas;
        [SerializeField] Image m_downloadingGaugeImage;
        [SerializeField] TextMeshProUGUI m_downloadingPerText;
        [SerializeField] Image m_downloadingPanel;
        [SerializeField] TextMeshProUGUI m_downloadingDescText;

        [Header("Notification UI")]
        [SerializeField] Image m_notificationBackgroundImage;
        [SerializeField] TextMeshProUGUI m_notificationText;
        [SerializeField] Button m_notificationButton;

        #endregion

        #region Properties

        #region Login

        public CanvasGroup LoginCanvas => m_loginCanvas;
        public TMP_InputField LoginNicknameField => m_loginNicknameField;
        public Toggle LoginRememberToggle => m_loginRememberToggle;
        public Button LoginButton => m_loginButton;

        #endregion

        #region Main

        public CanvasGroup MainCanvas => m_mainCanvas;
        public Image UserInformationPanel => m_userInformationPanel;
        public Image PortraitImage => m_portraitImage;
        public TextMeshProUGUI NicknameText => m_nicknameText;
        public TextMeshProUGUI LevelText => m_levelText;
        public ScrollRect HighestGradeEverScroll => m_highestGradeEverScroll;

        #endregion

        #region Loading

        public CanvasGroup LoadingCanvas => m_loadingCanvas;
        public RectTransform LoadingProgressImage => m_loadingProgressImage;
        public TextMeshProUGUI LoadingDescriptionText => m_loadingDescText;

        #endregion

        #region Downloading

        public CanvasGroup DownloadingCanvas => m_downloadingCanvas;
        public Image DownloadingGaugeImage => m_downloadingGaugeImage;
        public TextMeshProUGUI DownloadingPerText => m_downloadingPerText;
        public Image DownloadingPanel => m_downloadingPanel;
        public TextMeshProUGUI DownloadingDescText => m_downloadingDescText;

        #endregion

        #region Notification

        public Image NotificationBackgroundImage => m_notificationBackgroundImage;
        public TextMeshProUGUI NotificationText => m_notificationText;
        public Button NotificationButton => m_notificationButton;

        #endregion

        #endregion
    }
}
