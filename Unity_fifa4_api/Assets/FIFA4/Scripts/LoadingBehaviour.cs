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
        private void Start()
        {
            var manager = GameManager.Instance;

            manager.UI.LoadingCanvas.alpha = 0;
            manager.UI.LoadingCanvas.blocksRaycasts = false;
        }

        public void Show(string text)
        {
            var manager = GameManager.Instance;

            manager.UI.LoadingCanvas.blocksRaycasts = true;
            manager.UI.LoadingCanvas.DOKill();
            manager.UI.LoadingCanvas.DOFade(1, 0.2f).From(0);
            manager.UI.LoadingProgressImage.DOLocalRotate(new Vector3(0, 0, 180), 90, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetSpeedBased(true).From(Vector3.zero);

            manager.UI.LoadingDescriptionText.text = text;
        }

        public void Hide()
        {
            var manager = GameManager.Instance;

            manager.UI.LoadingCanvas.blocksRaycasts = false;
            manager.UI.LoadingCanvas.DOKill();
            manager.UI.LoadingCanvas.DOFade(0, 0.2f);

            manager.UI.LoadingProgressImage.DOKill();

            manager.UI.LoadingDescriptionText.text = "";
        }
    }
}
