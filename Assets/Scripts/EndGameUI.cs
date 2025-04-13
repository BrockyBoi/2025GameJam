using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public static EndGameUI Instance;

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private string _sceneToLoadOnRetry;

    private void Awake()
    {
        Instance = this;
        _canvas.enabled = false;
    }

    public void ShowUI()
    {
        _canvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PressRetry()
    {
        SceneManager.LoadScene(_sceneToLoadOnRetry);
    }

    public void PressQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
