using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionManager : MonoBehaviour
{
    public static SuspicionManager Instance;

    public bool IsGameOver { get; private set; }

    private float _currentSuspicionLevel = 0;

    [SerializeField]
    private float _maxSuspicionAllowed = 1;

    private HashSet<PickableObject> _objectsSeen;

    private void Awake()
    {
        Instance = this;
        _objectsSeen = new HashSet<PickableObject>();
    }

    public void OnSeeSuspicousObject(PickableObject suspiciousObject)
    {
        if (suspiciousObject && suspiciousObject.IsObjectSuspicous && !_objectsSeen.Contains(suspiciousObject))
        {
            _currentSuspicionLevel += suspiciousObject.SuspicionLevel;
            _objectsSeen.Add(suspiciousObject);

            if (_currentSuspicionLevel >= _maxSuspicionAllowed)
            {
                LoseGame();
            }
        }
    }

    public void OnSeePlayer()
    {
        LoseGame();
    }

    private void LoseGame()
    {
        IsGameOver = true;
        EndGameUI.Instance.ShowUI();
    }
}
