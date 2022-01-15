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

        [Header("Loading UI")]
        [SerializeField] CanvasGroup m_loadingCanvas;
        [SerializeField] RectTransform m_loadingProgressImage;
        [SerializeField] TextMeshProUGUI m_loadingDescText;

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

        #region Loading

        public CanvasGroup LoadingCanvas => m_loadingCanvas;
        public RectTransform LoadingProgressImage => m_loadingProgressImage;
        public TextMeshProUGUI LoadingDescriptionText => m_loadingDescText;

        #endregion

        #region Notification

        public Image NotificationBackgroundImage => m_notificationBackgroundImage;
        public TextMeshProUGUI NotificationText => m_notificationText;
        public Button NotificationButton => m_notificationButton;

        #endregion

        #endregion
    }
}
