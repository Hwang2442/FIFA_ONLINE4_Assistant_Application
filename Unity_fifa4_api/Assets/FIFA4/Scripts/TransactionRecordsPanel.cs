using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FIFA4
{
    public class TransactionRecordsPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] CanvasGroup m_canvas;
        [SerializeField] ScrollRect m_scrollView;

        [Header("Filter")]
        [SerializeField] Button m_filterAllButton;
        [SerializeField] Button m_filterPurchaseButton;
        [SerializeField] Button m_filterSalesButton;

        [Space]
        [SerializeField] Button m_showHideButton;

        private void Start()
        {
            
        }

        public void Show()
        {
            m_showHideButton.image.rectTransform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        public void Hide()
        {
            m_showHideButton.image.rectTransform.localRotation = Quaternion.Euler(0, 0, -90);
        }

        #region Button methods

        public void OnClickAllButton()
        {

        }

        public void OnClickPurchaseButton()
        {

        }

        public void OnClickSalesButton()
        {

        }

        #endregion
    }
}
