using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FIFA4
{
    public class Login : MonoBehaviour
    {
        const string rememberMePrefsKey = "Remember me";
        const string nicknamePrefsKey = "Nickname";

        private void Start()
        {
            var ui = GameManager.Instance.UI;

            ui.LoginRememberToggle.isOn = PlayerPrefs.GetInt(rememberMePrefsKey, 0) == 1;   // Toggle.
            ui.LoginNicknameField.text = PlayerPrefs.GetString(nicknamePrefsKey, "");       // Input field.
        }

        public void OnClickLogin()
        {
            var ui = GameManager.Instance.UI;

            PlayerPrefs.SetString(nicknamePrefsKey, ui.LoginRememberToggle.isOn ? ui.LoginNicknameField.text : "");
        }

        public void OnToggleChanged(bool value)
        {
            PlayerPrefs.SetInt(rememberMePrefsKey, value ? 1 : 0);
        }
    }
}
