using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class LoginBehaviour : MonoBehaviour
    {
        #region Class definition

        [System.Serializable]
        public class LoginSuccessed : UnityEvent<UserInformation> { }

        #endregion

        #region Variables

        [SerializeField] CanvasGroup m_canvas;

        [Header("Panel")]
        [SerializeField] Image m_panel;
        [SerializeField] TMP_InputField m_nicknameField;
        [SerializeField] Toggle m_rememberToggle;
        [SerializeField] Button m_loginButton;

        [Header("Events")]
        [SerializeField] LoginSuccessed m_loginSuccessed = new LoginSuccessed();
        [SerializeField] UnityEvent m_loginFailed = new UnityEvent();

        const string rememberMePrefsKey = "Remember me";
        const string nicknamePrefsKey = "Nickname";

        #endregion

        #region Properties

        public LoginSuccessed Successed { get { return m_loginSuccessed; } }
        public UnityEvent Failed { get { return m_loginFailed; } }

        #endregion

        private void Start()
        {
            m_rememberToggle.isOn = PlayerPrefs.GetInt(rememberMePrefsKey, 0) == 1; // Toggle.
            m_nicknameField.text = PlayerPrefs.GetString(nicknamePrefsKey, "");     // Inputfield.

            m_canvas.alpha = 1;
            m_canvas.blocksRaycasts = true;
        }

        public Tween Show()
        {
            return m_panel.rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.InQuad).OnStart(() => { m_canvas.alpha = 1;m_canvas.blocksRaycasts = true; gameObject.SetActive(true); });
        }

        public Tween Hide()
        {
            return m_panel.rectTransform.DOScale(new Vector3(0, 1, 1), 0.5f).SetEase(Ease.InQuad).OnComplete(() => { m_canvas.alpha = 0; m_canvas.blocksRaycasts = false; gameObject.SetActive(false); });
        }

        public void OnClickLogin()
        {
            var manager = GameManager.Instance;

            // Nickname is empty.
            if (string.IsNullOrEmpty(m_nicknameField.text))
            {
                GameManager.Instance.Notification.Show("닉네임을 입력해주세요.");
                
                return;
            }

            // Save nickname.
            PlayerPrefs.SetString(nicknamePrefsKey, m_rememberToggle.isOn ? m_nicknameField.text : "");

            // Get accessid.
            StartCoroutine(Co_GetAccessid(m_nicknameField.text));
        }

        public void OnToggleChanged(bool value)
        {
            PlayerPrefs.SetInt(rememberMePrefsKey, value ? 1 : 0);
        }

        private IEnumerator Co_GetAccessid(string nickname)
        {
            var manager = GameManager.Instance;

            manager.Loading.Show("로그인 중입니다...");

            yield return new WaitForSeconds(0.2f);

            yield return GameManager.Instance.RequestService.GetUserInformation((response) =>
            {
                manager.Loading.Hide();

                // Login successed.
                if (!response.isError)
                {
                    DOVirtual.DelayedCall(0.1f, ()=> m_loginSuccessed.Invoke(response.data));
                }
                // Login failed.
                else
                {
                    DOVirtual.DelayedCall(0.1f, m_loginFailed.Invoke);
                }
            }, null, nickname);
        }
    }
}
