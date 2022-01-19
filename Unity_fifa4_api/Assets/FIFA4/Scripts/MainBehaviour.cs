using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class MainBehaviour : MonoBehaviour
    {
        private void Start()
        {
            var manager = GameManager.Instance;

            manager.UI.MainCanvas.alpha = 0;
            manager.UI.MainCanvas.blocksRaycasts = false;
        }

        public Tween Show()
        {
            var manager = GameManager.Instance;

            manager.UI.MainCanvas.alpha = 1;
            manager.UI.MainCanvas.blocksRaycasts = true;

            return manager.UI.UserInformationPanel.rectTransform.DOScale(1, 0.5f).From(0).SetEase(Ease.InOutQuad);
        }
        public Tween Hide()
        {
            var manager = GameManager.Instance;

            manager.UI.MainCanvas.alpha = 1;
            manager.UI.MainCanvas.blocksRaycasts = false;

            return GameManager.Instance.UI.UserInformationPanel.rectTransform.DOScale(0, 0.5f).From(1).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                manager.UI.MainCanvas.alpha = 0;
            });
        }

        public void SetUserInformation(UserInformation information)
        {
            var manager = GameManager.Instance;

            manager.UI.NicknameText.text = information.nickname;
            manager.UI.LevelText.text = "Level : " + information.level.ToString();

            StartCoroutine(Co_SetIcon());
        }

        private IEnumerator Co_SetIcon()
        {
            var manager = GameManager.Instance;
            Spid spid = manager.Spid[Random.Range(0, manager.Spid.Length)];

            Debug.Log(spid.id);
            Debug.Log(spid.name);

            manager.UI.PortraitImage.DOFade(0, 0);
            manager.UI.PortraitImage.sprite = null;
            manager.UI.PlayerNameText.text = "";

            yield return manager.RequestService.GetPlayerImage(this, (response) => manager.UI.PortraitImage.sprite = response.data.Value, (response) => manager.UI.PortraitImage.sprite = response.data, spid.id);
            yield return null;

            if (manager.UI.PortraitImage.sprite == null)
            {
                StartCoroutine(Co_SetIcon());
            }
            else
            {
                manager.UI.PortraitImage.DOFade(1, 0.2f).From(0);
                manager.UI.PlayerNameText.DOText(spid.name, 0.2f).From("");
            }
        }

        private IEnumerator Co_SetHighestGradeEver()
        {
            var manager = GameManager.Instance;

            yield return null;
        }
    }
}
