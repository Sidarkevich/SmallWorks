using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private Player player;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.StepBack();
        }
    }
}
