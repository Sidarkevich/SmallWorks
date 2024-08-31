using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;

    public void SetPlayerState()
    {
        renderer.color = Color.red;
    }

    public void SetNextStepState()
    {
        renderer.color = Color.yellow;
    }

    public void SetPrevState()
    {
        renderer.color = Color.gray;
    }

    public void SetFreeState()
    {
        renderer.color = Color.white;
    }
}
