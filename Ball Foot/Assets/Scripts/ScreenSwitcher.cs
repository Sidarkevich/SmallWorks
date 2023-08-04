using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _screens;
    [SerializeField] private GameObject _startScreen;

    private GameObject _currentScreen;
    private GameObject _prevScreen;

    public void Switch(GameObject nextScreen)
    {
        foreach (var screen in _screens)
        {
            screen.SetActive(false);
        }

        if (_currentScreen)
        {
            _prevScreen = _currentScreen;
        }

        _currentScreen = nextScreen;
        _currentScreen.SetActive(true);
    }
    
    public void Back()
    {
        Switch(_prevScreen);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    private void Start()
    {
        Switch(_startScreen);
    }
}
