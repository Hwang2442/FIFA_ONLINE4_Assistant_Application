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

        [Header("UI")]
        [SerializeField] CanvasGroup m_canvas;
        [SerializeField] TextMeshProUGUI m_descText;
        [SerializeField] ScrollRect m_recordScrollView;
        [SerializeField] MatchRecordChild m_recordPrefab;

        [Header("Filter")]
        [SerializeField] ScrollRect m_filterScrollView;
        [SerializeField] Button m_filterButtonPrefab;

        [Space]
        [SerializeField] Button m_showHideButton;

        private void Start()
        {
            m_showHideButton.image.rectTransform.localRotation = Quaternion.Euler(0, 0, -90);
        }

        public Sequence ShowAndHide()
        {
            return m_showHideButton.image.rectTransform.localRotation.z < 0 ? Show() : Hide();
        }

        public Sequence Show()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => m_showHideButton.image.raycastTarget = false).OnComplete(() => m_showHideButton.image.raycastTarget = true);

            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, 90), 0.5f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(0, 0.5f).From(1));
            sequence.Join(m_rect.DOLocalMoveX(-m_rect.sizeDelta.x, 1).SetRelative(true));

            return sequence;
        }

        public Sequence Hide()
        {
            Sequence sequence = DOTween.Sequence().OnStart(() => m_showHideButton.image.raycastTarget = false).OnComplete(() => m_showHideButton.image.raycastTarget = true);

            sequence.Append(m_rect.DOLocalMoveX(m_rect.sizeDelta.x, 1).SetRelative(true));
            sequence.Append(m_showHideButton.image.rectTransform.DOLocalRotate(new Vector3(0, 0, -90), 0.5f, RotateMode.FastBeyond360));
            sequence.Join(m_descText.DOFade(1, 0.5f).From(0));

            return sequence;
        }

        #region Button methods

        private void OnClickFilterButton(Button button)
        {
            foreach (var child in m_filterScrollView.content.GetComponentsInChildren<Button>())
            {
                child.interactable = child.GetInstanceID() != button.GetInstanceID();
            }

            
        }

        #endregion

        public IEnumerator Co_RecordUpdate(GameManager manager, MatchType matchType, UnityAction onStart, UnityAction onComplete)
        {
            if (onStart != null)
                onStart();

            string[] records = null;

            yield return manager.RequestService.GetMatchRecords((response) => { records = response.data; }, null, manager.UserInformation.accessId, matchType.matchType);

            for (int i = 0; i < records.Length; i++)
            {
                yield return manager.RequestService.GetMatchDetailRecord((response) =>
                {
                    MatchRecordChild child = (i + 1) > m_recordScrollView.content.childCount ? Instantiate(m_recordPrefab, m_recordScrollView.content) : m_recordScrollView.content.GetChild(i).GetComponent<MatchRecordChild>();
                    child.SetRecord(manager, response.data);
                }, null, records[i]);
            }

            if (onComplete != null)
                onComplete();
        }
    }
}
