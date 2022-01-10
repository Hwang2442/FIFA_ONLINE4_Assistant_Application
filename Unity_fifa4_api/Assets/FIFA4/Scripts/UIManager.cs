using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FIFA4
{
    public class UIManager : MonoBehaviour
    {
        [Header("Login UI")]
        [SerializeField] CanvasGroup m_loginTransform;
        [SerializeField] TMP_InputField m_nicknameField;
    }
}
