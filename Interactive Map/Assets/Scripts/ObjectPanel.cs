using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPanel : MonoBehaviour
{
    [SerializeField] private Image _labelImage;
    [SerializeField] private TMP_Text _typeText;
    [SerializeField] private TMP_Text _nameText;

    public void Setup(MapObject mapObject)
    {
        switch (mapObject.ObjectTypeIndex)
        {
            case 1:
            {
                _labelImage.enabled = true;
                _labelImage.sprite = mapObject.Label;
                _typeText.text = "Национальный парк";
                _nameText.text = mapObject.Name;

                break;
            }
            case 2:
            {
                _labelImage.enabled = false;
                _typeText.text = "Заповедник";
                _nameText.text = mapObject.Name;

                break;
            }
            case 3:
            {
                _labelImage.enabled = false;
                _typeText.text = "Заказник республиканского значения";
                _nameText.text = mapObject.Name;

                break;
            }
            default:
            {
                Debug.LogError("Something WRONG!!!");
                break;
            }
        }
    }
}
