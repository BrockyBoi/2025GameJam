using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Playables;

public class EndGameUI : MonoBehaviour
{
    public static EndGameUI Instance;

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private string _sceneToLoadOnRetry;

    [SerializeField]
    private float _totalDuration = 114;

    private void Awake()
    {
        Instance = this;
        _canvas.enabled = false;
    }

    private void Start()
    {
        Invoke("OnTimerEnd", _totalDuration);
    }

    private void OnTimerEnd()
    {
        ShowUI(false);
    }

    public void ShowUI(bool loseGame)
    {
        _text.text = loseGame ? "You Were Discovered" : "You Remained Hidden!";
        _canvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EscapeManager.Instance.PauseTimeline(true);
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
