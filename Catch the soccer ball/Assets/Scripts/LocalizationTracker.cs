using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizationTracker : MonoBehaviour
{
    [SerializeField] private Toggle _EngToggle;
    [SerializeField] private Toggle _RuToggle;

    public void ChangeLocale(bool value)
    {
        StartCoroutine(LocaleCoroutine(value? 0 : 1));
    }

    private void Awake()
    {
        int id = PlayerPrefs.GetInt("LocaleSettings", 0);

        _EngToggle.isOn = id == 0 ? true : false;
        _RuToggle.isOn = !_EngToggle.isOn;

        ChangeLocale(id == 0 ? true : false);
    }

    private IEnumerator LocaleCoroutine(int id)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleSettings", id);
    }
}