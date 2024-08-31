using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private CellMap map;
    [SerializeField] private float stepDuration;

    private Cell currentCell => _steps.LastOrDefault();

    private List<Cell> _steps = new List<Cell>();
    private Cell _nextStep;
    
    private bool _isFirstRun = true;

    private Sequence _movingSequence;
    
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
        if (_steps.Count < 2 )
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

        _movingSequence.Append(transform.DOMove(_nextStep.transform.position, stepDuration).OnComplete(Move));
    }

    private void Move()
    {
        Debug.LogError("Move");
        StepNext();
        _movingSequence.Append(transform.DOMove(_nextStep.transform.position, stepDuration).OnComplete(Move));
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
