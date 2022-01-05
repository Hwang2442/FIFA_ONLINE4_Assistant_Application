using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties

    public static GameManager Instance { get; private set; }

    #endregion

    private void Awake()
    {
        Instance = this;
    }
}
