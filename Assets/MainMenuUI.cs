using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoadOnPlay;
    public void PressPlay()
    {
        SceneManager.LoadScene(_sceneToLoadOnPlay);
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
