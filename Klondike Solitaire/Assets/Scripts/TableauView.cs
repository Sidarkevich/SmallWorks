using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauView : MonoBehaviour
{
    [SerializeField] private float _yOffset;
    [SerializeField] private RectTransform _tableauTransform;

    public void SetupView(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var rect = cards[i].gameObject.GetComponent<RectTransform>();

            rect.SetParent(_tableauTransform);
            rect.SetLocalPositionAndRotation(new Vector3(0, _yOffset * i, 0), Quaternion.identity);
        }
    }
}
