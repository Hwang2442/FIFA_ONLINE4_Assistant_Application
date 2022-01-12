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

        #endregion

        #region Properties

        #region Login

        public CanvasGroup LoginCanvas => m_loginCanvas;
        public TMP_InputField LoginNicknameField => m_loginNicknameField;
        public Toggle LoginRememberToggle => m_loginRememberToggle;
        public Button LoginButton => m_loginButton;

        #endregion

        #endregion
    }
}
