using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationTracker : MonoBehaviour
{
    [SerializeField] private ToggleButton _EnToggle; 
    [SerializeField] private ToggleButton _SpToggle; 

    public void ChangeLocale(bool value)
    {
        StartCoroutine(LocaleCoroutine(value? 0 : 1));
    }

    private void Awake()
    {
        int id = PlayerPrefs.GetInt("LocaleSettings", 0);
        _EnToggle.SetValue(id == 0 ? true : false);
        _SpToggle.SetValue(id == 0 ? false : true);

        ChangeLocale(id == 0 ? true : false);
    }

    private IEnumerator LocaleCoroutine(int id)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleSettings", id);
        PlayerPrefs.Save();
    }
}
