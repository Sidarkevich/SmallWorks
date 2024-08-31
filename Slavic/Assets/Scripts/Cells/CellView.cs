using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private Image image;

    public void SetPlayerState()
    {
        image.color = Color.red;
    }

    public void SetNextStepState()
    {
        image.color = Color.yellow;
    }

    public void SetPrevState()
    {
        image.color = Color.gray;
    }

    public void SetFreeState()
    {
        image.color = Color.white;
    }
}
