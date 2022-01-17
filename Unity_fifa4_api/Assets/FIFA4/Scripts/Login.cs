using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace FIFA4
{
    public class Login : MonoBehaviour
    {
        const string rememberMePrefsKey = "Remember me";
        const string nicknamePrefsKey = "Nickname";

        private void Start()
        {
            var manager = GameManager.Instance;

            manager.UI.LoginRememberToggle.isOn = PlayerPrefs.GetInt(rememberMePrefsKey, 0) == 1;   // Toggle.
            manager.UI.LoginNicknameField.text = PlayerPrefs.GetString(nicknamePrefsKey, "");       // Input field.

            manager.UI.LoginCanvas.alpha = 1;
        }

        public void OnClickLogin()
        {
            var manager = GameManager.Instance;

            // Nickname is empty.
            if (string.IsNullOrEmpty(manager.UI.LoginNicknameField.text))
            {
                manager.NotificationComponent.Show("닉네임을 입력해주세요.");

                return;
            }

            PlayerPrefs.SetString(nicknamePrefsKey, manager.UI.LoginRememberToggle.isOn ? manager.UI.LoginNicknameField.text : "");     // Save nickname.

            // Get accessid.
            StartCoroutine(Co_GetAccessid());
        }

        public void OnToggleChanged(bool value)
        {
            PlayerPrefs.SetInt(rememberMePrefsKey, value ? 1 : 0);
        }

        private IEnumerator Co_GetAccessid()
        {
            var manager = GameManager.Instance;

            manager.LoadingComponent.Show("로그인 중입니다...");

            yield return GameManager.Instance.RequestService.GetUserInformation((response) =>
            {
                if (!response.isError)
                {
                    Debug.Log("Login successed!!");

                    if (!manager.DownloadingComponent.isUpdated)
                    {
                        manager.LoadingComponent.Hide();
                        DOVirtual.DelayedCall(0.2f, ()=> manager.DownloadingComponent.StartCoroutine(manager.DownloadingComponent.DataUpdate()));
                    }
                    else
                    {
                        Debug.Log("Updated data.");
                    }
                }
                else
                {
                    Debug.Log("Login failed..");

                    manager.NotificationComponent.Show("닉네임을 찾을 수 없습니다.", () => manager.UI.LoginNicknameField.text = "");
                }
            }, null, GameManager.Instance.UI.LoginNicknameField.text);

            //manager.LoadingComponent.Hide();
        }
    }
}
