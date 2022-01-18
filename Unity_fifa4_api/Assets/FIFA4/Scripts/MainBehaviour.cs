using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FIFA4
{
    public class MainBehaviour : MonoBehaviour
    {
        public void SetUserInformation(UserInformation information)
        {
            var manager = GameManager.Instance;

            manager.UI.NicknameText.text = information.nickname;
            manager.UI.LevelText.text = "Level : " + information.level.ToString();
        }

        private IEnumerator Co_SetIcon()
        {
            var manager = GameManager.Instance;
            bool exist = true;

            Spid spid = manager.Spid[Random.Range(0, manager.Spid.Length)];

            yield return manager.RequestService.UpdatePlayerActionImageFromSpid((response) =>
            {
                if (!response.isError)
                {
                    
                }
            }, null, spid.id);

            if (!exist)
            {

            }


            yield return null;
        }

        private IEnumerator Co_SetHighestGradeEver()
        {
            var manager = GameManager.Instance;

            yield return null;
        }
    }
}
