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
        _creditsGameObjectParent.SetActive(true);
        _mainMenuGameObject.SetActive(false);
    }

    public void PressBackFromCredits()
    {
        _creditsGameObjectParent.SetActive(false);
        _mainMenuGameObject.SetActive(true);
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
