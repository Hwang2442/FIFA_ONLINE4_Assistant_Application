using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class TransactionRecordsPanel : MonoBehaviour
    {
        [SerializeField] RectTransform m_rect;
        [SerializeField] bool m_isUpdated = false;

        [Header("UI")]
        [SerializeField] CanvasGroup m_canvas;
        [SerializeField] TextMeshProUGUI m_descText;
        [SerializeField] TextMeshProUGUI m_emptyText;
        [SerializeField] ScrollRect m_scrollView;
        [SerializeField] TransactionRecordChild m_transactionRecordPrefab;

        [Header("Filter")]
        [SerializeField] Button m_filterAllButton;
        [SerializeField] Button m_filterPurchaseButton;
        [SerializeField] Button m_filterSalesButton;

        [Space]
        [SerializeField] Button m_showHideButton;
        [SerializeField] LoadingBehaviour m_loading;

        [Space]
        [SerializeField] List<TransactionRecordChild> m_transactionRecordList = new List<TransactionRecordChild>();

        public bool IsUpdated
        {
            get { return m_isUpdated; }
            set
            {
                if (!value)
                {
                    m_transactionRecordList.Clear();
                    foreach (Transform child in m_scrollView.content)
                    {
                        Destroy(child.gameObject);
                    }
                }
                    
                m_isUpdated = value;
            }
        }
        private void Start()
        {
            m_showHideButton.image.rectTransform.localRotation = Quaternion.Euler(0, 0, 90);
            m_emptyText.gameObject.SetActive(false);

            m_filterAllButton.onClick.Invoke();
        }

        public Sequence ShowAndHide()
        {
            return m_showHideButton.image.rectTransform.localRotation.z > 0 ? Show() : Hide();
        }

        public Sequence Show()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => 
            {
                m_showHideButton.image.raycastTarget = false; 
                if (!m_isUpdated && m_transactionRecordList.Count == 0)
                {
                    m_loading.Show("데이터를 불러오고 있습니다...");
                }
            }).OnComplete(() => 
            { 
                m_showHideButton.image.raycastTarget = true;
                if (!m_isUpdated && m_transactionRecordList.Count == 0)
                {
                    StartCoroutine(Co_RecordsUpdate(GameManager.Instance, null, () =>
                    {
                        m_loading.Hide();
                        IsUpdated = true;

                        m_emptyText.gameObject.SetActive(m_transactionRecordList.Count == 0);
                    }));
                }
            });

            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, -90), 0.5f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(0, 0.5f).From(1));
            sequence.Join(m_rect.DOLocalMoveX(m_rect.sizeDelta.x, 1).SetRelative(true));

            return sequence;
        }

        public Sequence Hide()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => m_showHideButton.image.raycastTarget = false).OnComplete(() => m_showHideButton.image.raycastTarget = true);

            sequence.Append(m_rect.DOLocalMoveX(-m_rect.sizeDelta.x, 1).SetRelative(true));
            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, 90), 0.5f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(1, 0.5f).From(0));

            return sequence;
        }

        public void UpdateRecords(UnityAction onStart, UnityAction onComplete)
        {
            StartCoroutine(Co_RecordsUpdate(GameManager.Instance, onStart, onComplete));
        }

        #region Button methods

        public void OnClickAllButton()
        {
            foreach (var record in m_transactionRecordList)
            {
                record.gameObject.SetActive(true);
            }
        }

        public void OnClickPurchaseButton()
        {
            foreach (var record in m_transactionRecordList)
            {
                record.gameObject.SetActive(record.IsPurchase);
            }
        }

        public void OnClickSalesButton()
        {
            foreach (var record in m_transactionRecordList)
            {
                record.gameObject.SetActive(!record.IsPurchase);
            }
        }

        #endregion

        public IEnumerator Co_RecordsUpdate(GameManager manager, UnityAction onStart, UnityAction onComplete)
        {
            if (onStart != null)
                onStart();

            TransactionRecords[] purchaseRecords = null;
            TransactionRecords[] salesRecords = null;

            yield return manager.RequestService.GetPurchaseRecords((response) => purchaseRecords = response.data, null, manager.UserInformation.accessId);
            yield return manager.RequestService.GetSalesRecord((response) => salesRecords = response.data, null, manager.UserInformation.accessId);

            if (purchaseRecords == null && salesRecords == null)
                yield break;

            // Purchase.
            foreach (var record in purchaseRecords)
            {
                m_transactionRecordList.Add(Instantiate(m_transactionRecordPrefab, m_scrollView.content));
                m_transactionRecordList.Last().SetRecord(manager, record, true);
            }
            // Sales.
            foreach (var record in salesRecords)
            {
                m_transactionRecordList.Add(Instantiate(m_transactionRecordPrefab, m_scrollView.content));
                m_transactionRecordList.Last().SetRecord(manager, record, false);
            }

            m_transactionRecordList.Sort((a, b) => System.DateTime.Compare(b.Date, a.Date));

            for (int i = 0; i < m_transactionRecordList.Count; i++)
            {
                m_transactionRecordList[i].Rect.SetSiblingIndex(i);
            }

            if (onComplete != null)
                onComplete();
        }
    }
}
