using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private CellMap map;

    private Cell currentCell => _steps.LastOrDefault();
    
    private List<Cell> _steps = new List<Cell>();
    private Cell _nextStep;
    
    public void StepNext()
    {
        if (currentCell.IsObstacle)
        {
            Debug.LogError("Game over!");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
        currentCell.View.SetPrevState();
        
        _nextStep.View.SetPlayerState();
        _steps.Add(_nextStep);
        _nextStep.IsFree = false;

        _nextStep = GetNextStep();
        _nextStep.View.SetNextStepState();
    }

    public void StepBack()
    {
        if (_steps.Count < 2)
            return;
        
        _nextStep.View.SetFreeState();
        currentCell.View.SetFreeState();
        currentCell.IsFree = true;

        _steps.Remove(currentCell);

        currentCell.View.SetPlayerState();
        currentCell.IsFree = false;

        _nextStep = GetNextStep();
        _nextStep.View.SetNextStepState();
    }

    private void Start()
    {
        Restart();
    }

    private Cell GetNextStep()
    {
        var possibleSteps = map.GetFreeNeighbors(currentCell.QRS);
        return possibleSteps[Random.Range(0, possibleSteps.Count)];
    }

    private void Restart()
    {
        var startCell = map.StartCell;
        _steps.Add(startCell);
        startCell.View.SetPlayerState();
        startCell.IsFree = false;
        
        _nextStep = GetNextStep();
        _nextStep.View.SetNextStepState();
    }
}
