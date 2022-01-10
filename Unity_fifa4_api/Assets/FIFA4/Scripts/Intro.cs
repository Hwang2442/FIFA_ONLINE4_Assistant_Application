using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class Intro : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2.5f);

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
}
