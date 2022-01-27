using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace FIFA4
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_canvas = null;

        [Header("Panel")]
        [SerializeField] TextMeshProUGUI m_nicknameText = null;
        [SerializeField] TextMeshProUGUI m_levelText = null;

        [Header("Portrait")]
        [SerializeField] Button m_reloadingButton = null;
        [SerializeField] Image m_playerImage = null ;
        [SerializeField] Image m_seasonImage = null;
        [SerializeField] TextMeshProUGUI m_playerName = null;
        [SerializeField] LoadingBehaviour m_loading = null;

        [Header("Highest grade ever")]
        [SerializeField] ScrollRect m_highestScroll = null;
        [SerializeField] GameObject m_highestChild = null;

        public bool isHiding { get { return m_canvas.alpha < 1; } }

        public Tween Show()
        {
            m_loading.Hide();

            return GetComponent<RectTransform>().DOScale(Vector3.one, 0.5f).SetEase(Ease.InQuad).From(new Vector3(0, 1, 1)).OnStart(() => { m_canvas.alpha = 1; m_canvas.blocksRaycasts = true; });
        }

        public Tween Hide()
        {
            return GetComponent<RectTransform>().DOScale(new Vector3(0, 1, 1), 0.5f).SetEase(Ease.InQuad).From(Vector3.one).OnComplete(() => { m_canvas.alpha = 0; m_canvas.blocksRaycasts = false; });
        }

        public Tween AlphaTweening(float alpha, float duration)
        {
            return m_canvas.DOFade(alpha, duration);
        }

        public void SetInformation(UserInformation user)
        {
            m_nicknameText.text = user.nickname;
            m_levelText.text = string.Format("Level : {0}", user.level.ToString("N0"));

            StartCoroutine(Co_UpdatePortrait(GameManager.Instance, "정보를 불러오는 중입니다..."));
            StartCoroutine(Co_UpdateHighestGradeEver(GameManager.Instance));
        }

        public void OnClickUpdatePortrait()
        {
            StopAllCoroutines();
            StartCoroutine(Co_UpdatePortrait(GameManager.Instance, "이미지를 불러오고 있습니다..."));
        }

        private IEnumerator Co_UpdatePortrait(GameManager manager, string loadingDescription)
        {
            m_reloadingButton.interactable = false;
            m_loading.Show("");

            Spid spid = null;
            m_playerImage.sprite = null;
            m_seasonImage.sprite = null;

            m_playerImage.DOFade(0, 0);
            m_seasonImage.DOFade(0, 0);
            m_playerName.text = "";

            yield return new WaitForSeconds(0.1f);

            while (m_playerImage.sprite == null)
            {
                spid = manager.Spid[Random.Range(0, manager.Spid.Length)];

                Debug.Log(spid.id + " " + spid.name);

                yield return StartCoroutine(manager.RequestService.GetSeasonImageFromSpid((response) => { m_seasonImage.sprite = response.data; }, spid.id));
                yield return StartCoroutine(manager.RequestService.GetPlayerImage((response) => { m_playerImage.sprite = response.data.Value; }, (response) => { m_playerImage.sprite = response.data; }, spid.id));
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);

            m_playerImage.DOKill();
            m_playerImage.DOFade(1, 0.2f).From(0);
            m_playerImage.sprite.name = spid.id.ToString();

            m_seasonImage.DOKill();
            m_seasonImage.DOFade(1, 0.2f).From(0);

            m_playerName.DOText(spid.name, 0.2f).From("");

            m_loading.Hide();
            m_reloadingButton.interactable = true;
        }

        private IEnumerator Co_UpdateHighestGradeEver(GameManager manager)
        {
            yield return manager.RequestService.GetHighestGradeEver((response) =>
            {
                if (response.isError)
                    return;

                MatchType[] matchTypes = JsonHelper.LoadJson<MatchType[]>(PathList.MatchTypePath);
                Division[] divisions = JsonHelper.LoadJson<Division[]>(PathList.DivisionPath);
                Division[] divisions_volta = JsonHelper.LoadJson<Division[]>(PathList.Division_VoltaPath);

                Transform child = null;

                foreach (var grade in response.data)
                {
                    child = Instantiate(m_highestChild, m_highestScroll.content).transform;

                    string datetime = grade.achievementDate.ToString("yyyy'년\n'MM'월 'dd'일 '");
                    string divisionName = "";
                    string matchtypeDesc = "";

                    foreach (var matchType in matchTypes)
                    {
                        if (grade.matchType != matchType.matchType)
                            continue;

                        foreach (var division in (grade.matchType < 204 ? divisions : divisions_volta))
                        {
                            if (grade.division != division.divisionId)
                                continue;

                            divisionName = division.divisionName;

                            break;
                        }

                        matchtypeDesc = matchType.description;

                        break;
                    }

                    child.Find("Text.Matchtype").GetComponent<TextMeshProUGUI>().text = matchtypeDesc;
                    child.Find("Text.Division").GetComponent<TextMeshProUGUI>().text = divisionName;
                    child.Find("Text.Datetime").GetComponent<TextMeshProUGUI>().text = datetime;
                }

                child.Find("Image.Boundary").gameObject.SetActive(false);
            }, null, manager.UserInformation.accessId);
        }
    }
}
