using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace FIFA4
{
    public class NotificationBehaviour : MonoBehaviour
    {
        [SerializeField] Image m_backgroundImage;
        [SerializeField] TextMeshProUGUI m_descriptionText;
        [SerializeField] Button m_checkButton;

        public void Show(string description, UnityAction callback = null)
        {
            gameObject.SetActive(true);

            m_descriptionText.text = description;

            m_checkButton.onClick.RemoveAllListeners();
            m_checkButton.onClick.AddListener(() => gameObject.SetActive(false));

            if (callback != null)
                m_checkButton.onClick.AddListener(callback);
        }
    }
}
