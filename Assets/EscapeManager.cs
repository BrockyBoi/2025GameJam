using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EscapeManager : MonoBehaviour
{
    public static EscapeManager Instance;

    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } }

    [SerializeField]
    private PlayableDirector _timeLineDirector;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SuspicionManager.Instance.IsGameOver)
        {
            Pause(!_isPaused);
        }
    }

    public void Pause(bool pause)
    {
        _isPaused = pause;
        if (pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PauseUI.Instance.ShowUI();
            PauseTimeline(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            PauseUI.Instance.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PauseTimeline(false);
        }
    }

    public void PauseTimeline(bool pause)
    {
        if (pause)
        {
            _timeLineDirector.Pause();
        }
        else
        {
            _timeLineDirector.Resume();

        }
    }
}
