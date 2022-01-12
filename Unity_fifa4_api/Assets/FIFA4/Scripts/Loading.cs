using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_background;
        [SerializeField] Image m_circularImage;
        [SerializeField] TextMeshProUGUI m_descriptionText;

        Sequence m_sequence;

        private void Start()
        {
            
        }

        public void Show(string text)
        {
            
        }

        public void Hide()
        {

        }
    }
}
