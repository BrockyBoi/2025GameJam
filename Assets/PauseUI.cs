using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance;
    [SerializeField]
    private Canvas _canvas;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    public void PressResume()
    {
        EscapeManager.Instance.Pause(false);
    }

    public void PressQuit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
