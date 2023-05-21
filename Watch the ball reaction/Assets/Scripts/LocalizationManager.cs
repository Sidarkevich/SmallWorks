using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Toggle _toggle; 
    private bool _active = false;

    public void ChangeLocale(bool value)
    {
        if (_active) return;

        StartCoroutine(LocaleCoroutine(value? 1 : 0));
    }

    private void Awake()
    {
        int id = PlayerPrefs.GetInt("LocaleSettings", 0);
        _toggle.isOn = id == 0 ? false : true;
        ChangeLocale(id == 0 ? false : true);
    }

    private IEnumerator LocaleCoroutine(int id)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleSettings", id);
    }
}
