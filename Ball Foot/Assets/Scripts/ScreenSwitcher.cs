using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _screens;

    public void Switch(GameObject nextScreen)
    {
        foreach (var screen in _screens)
        {
            screen.SetActive(screen == nextScreen);
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
