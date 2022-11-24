using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] LevelsSO _levels;

    private void Awake()
    {
        _levels.CurrentIndex = 0;
    }

    public void Play()
    {
        SceneManager.LoadScene(_levels.LevelNames[_levels.CurrentIndex]);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
