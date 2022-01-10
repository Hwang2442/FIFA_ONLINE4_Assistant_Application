using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] UIManager m_ui;

        #endregion

        #region Properties

        public static GameManager Instance { get; private set; }

        #endregion

        private void Awake()
        {
            Instance = this;
        }
    }
}
