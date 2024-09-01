using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class Player : MonoBehaviour
{
    [SerializeField] private CellMap map;
    [SerializeField] private float stepDuration;
    [SerializeField] private Animation animation;

    private Cell currentCell => _steps.LastOrDefault();

    private List<Cell> _steps = new List<Cell>();
    private Cell _nextStep;
    
    private bool _isFirstRun = true;

    private TweenerCore<Vector3,Vector3,VectorOptions> _movingTween;
    
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
        if (_steps.Count == 0)
            return;

        _nextStep.View.SetFreeState();
        
        animation.Stop();
        _movingTween.Kill();
        _movingTween = transform.DOMove(currentCell.transform.position, 0.2f).OnComplete((() =>
        {
            _nextStep = GetNextStep();
            _nextStep.View.SetNextStepState();
            
            animation.Stop();
            _movingTween = transform.DOMove(_nextStep.transform.position, stepDuration).OnComplete(Move);
            animation.Play("Jump");
        }));
    }

    private void Start()
    {
        Restart();

        _movingTween = transform.DOMove(_nextStep.transform.position, stepDuration).OnComplete(Move);
        animation.Stop();
        animation.Play("Jump");
    }

    private void Move()
    {
        StepNext();
        _movingTween = transform.DOMove(_nextStep.transform.position, stepDuration).OnComplete(Move);
        animation.Stop();
        animation.Play("Jump");
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
