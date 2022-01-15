using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FIFA4
{
    public class Notification : MonoBehaviour
    {
        public void Show(string text, UnityAction callback = null)
        {
            var manager = GameManager.Instance;

            manager.UI.NotificationText.text = text;

            manager.UI.NotificationButton.onClick.RemoveAllListeners();
            manager.UI.NotificationButton.onClick.AddListener(() => manager.UI.NotificationBackgroundImage.gameObject.SetActive(false));

            if (callback != null)
                manager.UI.NotificationButton.onClick.AddListener(callback);

            manager.UI.NotificationBackgroundImage.gameObject.SetActive(true);
        }
    }
}
