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

        Request m_request;

        #endregion

        #region Properties

        public static GameManager Instance { get; private set; }

        public UIManager UI => m_ui;

        public Request RequestService => m_request;

        #endregion

        private void Awake()
        {
            Instance = this;

            m_request = new Request();
        }
    }
}
