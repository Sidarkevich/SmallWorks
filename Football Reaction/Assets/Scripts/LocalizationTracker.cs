using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine;

public class LocalizationTracker : MonoBehaviour
{
    [SerializeField] private LocalizationButton[] _buttons;

    private int _index;

    public void ChangeLocale(int index)
    {
        if (index == _index)
        {
            return;
        }

        _index = index;
        SetButtons(_index);
        StartCoroutine(LocaleCoroutine(_index));
    }

    private void Awake()
    {
        _index = PlayerPrefs.GetInt("LocaleSettings", 0);

        SetButtons(_index);
        StartCoroutine(LocaleCoroutine(_index));
    }

    private IEnumerator LocaleCoroutine(int id)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleSettings", id);
    }

    private void SetButtons(int activeIndex)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].ChangeState(i == activeIndex);
        }
    }
}
