using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationHandler : MonoBehaviour
{
    private bool _active = false;
    private int _currentId;

    public void ChangeLocale()
    {
        ChangeLocale(_currentId != 0 ? _currentId = 0 : _currentId = 1);
    }

    private void ChangeLocale(int id)
    {
        if (_active) return;

        StartCoroutine(LocaleCoroutine(id));
    }

    private void Awake()
    {
        _currentId = PlayerPrefs.GetInt("LocaleSettings", 0);
        ChangeLocale(_currentId);
    }

    private IEnumerator LocaleCoroutine(int id)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleSettings", id);
        _active = false;
    }
}
