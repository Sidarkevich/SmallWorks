using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _screens;

    public void SwitchScreen(GameObject nextScreen)
    {
        foreach (var screen in _screens)
        {
            screen.SetActive(false);
        }

        nextScreen.SetActive(true);
    }
}
