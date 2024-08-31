using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float stepDuration;

    private bool _isFirstRun = true;
    
    private IEnumerator Start()
    {
        while (true)
        {
            if (!_isFirstRun)
            {
                player.StepNext();   
            }

            _isFirstRun = false;
            yield return new WaitForSeconds(stepDuration);   
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.StepNext();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.StepBack();
        }
    }
}
