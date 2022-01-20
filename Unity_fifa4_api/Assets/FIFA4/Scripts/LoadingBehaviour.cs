using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class LoadingBehaviour : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_canvas;

        [Header("Interaction")]
        [SerializeField] Image m_rotateImage;
        [SerializeField] TextMeshProUGUI m_descriptionText;

        [Header("Background color")]
        [SerializeField] Color m_defaultColor;

        public void Show(string text)
        {
            Show(text, m_defaultColor);
        }

        public void Show(string text, Color backgroundColor)
        {
            gameObject.SetActive(true);

            m_canvas.blocksRaycasts = true;
            m_canvas.DOKill();
            m_canvas.DOFade(1, 0.2f).From(0);
            m_canvas.GetComponent<Image>().color = backgroundColor;

            m_rotateImage.rectTransform.DOLocalRotate(new Vector3(0, 0, 180), 90, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetSpeedBased(true).From(Vector3.zero);

            m_descriptionText.text = text;
        }

        public void Hide()
        {
            m_descriptionText.text = "";

            m_rotateImage.DOKill();

            m_canvas.DOKill();
            m_canvas.DOFade(0, 0.2f).OnComplete(() =>
            {
                m_canvas.blocksRaycasts = false;
                gameObject.SetActive(false);
            });
        }
    }
}
