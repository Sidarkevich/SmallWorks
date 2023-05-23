using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauView : MonoBehaviour
{
    [SerializeField] private float _yOffset;
    [SerializeField] private RectTransform _tableauTransform;

    public void SetupView(List<Card> cards)
    {
        if (cards.Count > 0)
        {
            var rect = cards[0].gameObject.GetComponent<RectTransform>();
            rect.SetParent(_tableauTransform);
            rect.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        for (int i = 1; i < cards.Count; i++)
        {
            var rect = cards[i].gameObject.GetComponent<RectTransform>();

            rect.SetParent(cards[i-1].gameObject.GetComponent<RectTransform>());
            rect.SetLocalPositionAndRotation(new Vector3(0, _yOffset, 0), Quaternion.identity);
        }
    }
}
