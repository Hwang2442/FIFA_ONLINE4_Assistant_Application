using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FIFA4
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        [Header("User information")]
        [SerializeField] UserInformation m_userInformation;

        [Header("UI")]
        [SerializeField] UIManager m_ui;

        [Header("Components")]
        [SerializeField] Login m_login;
        [SerializeField] Loading m_loading;

        Request m_request;

        #endregion

        #region Properties

        public static GameManager Instance { get; private set; }

        public UIManager UI => m_ui;

        public Login LoginComponent => m_login;
        public Loading LoadingComponent => m_loading;

        public Request RequestService => m_request;

        public UserInformation UserInformation => m_userInformation;

        #endregion

        private void Awake()
        {
            Instance = this;

            m_request = new Request();
        }

        public void SetUserInformation()
        {

        }
    }
}
