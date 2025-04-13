using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private string _sceneToLoadOnPlay;

    [SerializeField]
    private GameObject _creditsGameObjectParent;

    [SerializeField]
    private GameObject _mainMenuGameObject;
    public void PressPlay()
    {
        SceneManager.LoadScene(_sceneToLoadOnPlay);
    }

    public void PressCredits()
    {

    }

    public void PressBackFromCredits()
    {

    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
