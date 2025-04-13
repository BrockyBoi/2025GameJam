using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{
    public static EscapeManager Instance;

    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        }
        else
        {
            Time.timeScale = 1.0f;
            PauseUI.Instance.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
