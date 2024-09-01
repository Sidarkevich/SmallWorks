using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer topRenderer;

    [SerializeField] private Color stepColor;
    [SerializeField] private Color defaultColor;
    
    public void SetPlayerState()
    {
        topRenderer.color = stepColor;

        transform.DOMoveY(transform.position.y - 0.07f, 0.3f);
    }
    
    public void SetNextStepState()
    {
        topRenderer.color = Color.yellow;
    }
    
    public void SetFreeState()
    {
        topRenderer.color = defaultColor;
    }
}
