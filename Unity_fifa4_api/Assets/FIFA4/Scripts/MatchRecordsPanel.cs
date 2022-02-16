using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class MatchRecordsPanel : MonoBehaviour
    {
        [SerializeField] RectTransform m_rect;
        [SerializeField] bool m_isUpdated = false;

        [Header("UI")]
        [SerializeField] CanvasGroup m_canvas;
        [SerializeField] TextMeshProUGUI m_descText;
        [SerializeField] TextMeshProUGUI m_emptyText;
        [SerializeField] ScrollRect m_recordScrollView;
        [SerializeField] MatchRecordChild m_recordPrefab;

        [Header("Filter")]
        [SerializeField] ScrollRect m_filterScrollView;

        [Space]
        [SerializeField] Button m_showHideButton;
        [SerializeField] LoadingBehaviour m_loading;

        [Space]
        [SerializeField] List<MatchRecordChild> m_matchRecordList;

        #region Properties

        public bool IsUpdated
        {
            get { return m_isUpdated; }
            set
            {
                if (!value)
                {
                    m_matchRecordList.Clear();
                    foreach (Transform child in m_recordScrollView.content)
                    {
                        Destroy(child.gameObject);
                    }

                    for (int i = 0; i < m_filterScrollView.content.childCount; i++)
                    {
                        m_filterScrollView.content.GetChild(i).GetComponent<Button>().interactable = i != 0;
                    }
                }

                m_isUpdated = value;
            }
        }

        public Button ShowHideButton { get { return m_showHideButton; } }

        public bool IsHiding
        {
            get
            {
                return m_showHideButton.image.rectTransform.localRotation.z < 0;
            }
        }

        #endregion

        private void Start()
        {
            m_showHideButton.image.rectTransform.localRotation = Quaternion.Euler(0, 0, -90);
            m_emptyText.gameObject.SetActive(false);
            m_loading.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            var matchTypes = JsonHelper.LoadJson<MatchType[]>(PathList.MatchTypePath);
            Button prefab = m_filterScrollView.content.GetChild(0).GetComponent<Button>();

            prefab.GetComponentInChildren<TextMeshProUGUI>().text = matchTypes[0].description;
            prefab.onClick.AddListener(() => OnClickFilterButton(prefab));

            for (int i = 1; i < matchTypes.Length; i++)
            {
                Button button = Instantiate(prefab, m_filterScrollView.content);
                button.GetComponentInChildren<TextMeshProUGUI>().text = matchTypes[i].description;
                button.onClick.AddListener(() => OnClickFilterButton(button));
            }

            prefab.interactable = false;
        }

        public Sequence ShowAndHide()
        {
            return m_showHideButton.image.rectTransform.localRotation.z < 0 ? Show() : Hide();
        }

        public Sequence Show()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => 
            { 
                m_showHideButton.image.raycastTarget = false;
                m_emptyText.gameObject.SetActive(false);
                if (!m_isUpdated && m_matchRecordList.Count == 0)
                {
                    m_loading.Show("데이터를 불러오고 있습니다...");
                }
            }).OnComplete(() => 
            { 
                m_showHideButton.image.raycastTarget = true;
                if (!m_isUpdated && m_matchRecordList.Count == 0)
                {
                    StartCoroutine(Co_RecordUpdate(GameManager.Instance, JsonHelper.LoadJson<MatchType[]>(PathList.MatchTypePath)[0], null, () =>
                    {
                        IsUpdated = true;
                        m_loading.Hide();

                        m_emptyText.gameObject.SetActive(m_matchRecordList.Find(x => x.gameObject.activeSelf) == null);
                    }));
                }
            });

            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, 90), 0.2f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(0, 0.2f));
            sequence.Join(m_rect.DOLocalMoveX(-m_rect.sizeDelta.x, 0.5f).SetRelative(true));

            return sequence;
        }

        public Sequence Hide()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => m_showHideButton.image.raycastTarget = false).OnComplete(() => m_showHideButton.image.raycastTarget = true);

            sequence.Append(m_rect.DOLocalMoveX(m_rect.sizeDelta.x, 0.5f).SetRelative(true));
            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, -90), 0.2f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(1, 0.2f));

            return sequence;
        }

        #region Button methods

        private void OnClickFilterButton(Button button)
        {
            StopAllCoroutines();

            foreach (var child in m_filterScrollView.content.GetComponentsInChildren<Button>())
            {
                child.interactable = child.GetInstanceID() != button.GetInstanceID();
            }

            StartCoroutine(Co_RecordUpdate(GameManager.Instance, JsonHelper.LoadJson<MatchType[]>(PathList.MatchTypePath)[button.transform.GetSiblingIndex()], () => 
            {
                m_emptyText.gameObject.SetActive(false);
                m_loading.Show("데이터를 불러오고 있습니다...");
                foreach (Transform child in m_recordScrollView.content)
                {
                    child.gameObject.SetActive(false);
                }
            }, () => 
            {
                m_loading.Hide();
                m_emptyText.gameObject.SetActive(m_matchRecordList.Find(x => x.gameObject.activeSelf) == null);
                m_recordScrollView.verticalNormalizedPosition = 1;
            }));
        }

        #endregion

        public IEnumerator Co_RecordUpdate(GameManager manager, MatchType matchType, UnityAction onStart, UnityAction onComplete, int limit = 100)
        {
            if (onStart != null)
                onStart();

            string[] records = null;

            yield return manager.RequestService.GetMatchRecords((response) => { records = response.data; }, null, manager.UserInformation.accessId, matchType.matchType, 0, limit);

            foreach (Transform child in m_recordScrollView.content)
            {
                child.gameObject.SetActive(false);
            }

            List<UnityAction> actionList = new List<UnityAction>();

            for (int i = 0; i < records.Length; i++)
            {
                MatchDTO matchDTO = null;

                yield return manager.RequestService.GetMatchDetailRecord((response) => { matchDTO = response.data; }, null, records[i]);

                if ((i + 1) > m_matchRecordList.Count)
                    m_matchRecordList.Add(Instantiate(m_recordPrefab, m_recordScrollView.content));

                m_matchRecordList[i].gameObject.SetActive(false);
                if (m_matchRecordList[i].SetRecord(manager, matchDTO))
                {
                    int x = i;
                    actionList.Add(() => m_matchRecordList[x].gameObject.SetActive(true));
                }
                //m_matchRecordList[i].gameObject.SetActive(m_matchRecordList[i].SetRecord(manager, matchDTO));
            }

            foreach (var action in actionList)
            {
                action();
            }

            yield return null;

            if (onComplete != null)
                onComplete();
        }
    }
}
