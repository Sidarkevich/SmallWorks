using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private Player player;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.StepNext();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            player.StepBack();
        }
    }
}
