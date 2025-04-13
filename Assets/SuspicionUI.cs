using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionUI : MonoBehaviour
{
    public static SuspicionUI Instance;

    [SerializeField]
    private Scrollbar _scrollbar;

    private void Awake()
    {
        Instance = this;
        SetSuspicionLevel(0);
    }

    public void SetSuspicionLevel(float suspicionLevel)
    {
        _scrollbar.size = 1 - suspicionLevel;
    }
}
