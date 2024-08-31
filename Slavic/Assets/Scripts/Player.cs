using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CellMap map;

    private Cell currentCell => _steps.LastOrDefault();
    
    private List<Cell> _steps = new List<Cell>();
    private Cell _nextStep;
    
    public void StepNext()
    {
        currentCell.View.SetPrevState();
        
        _nextStep.View.SetPlayerState();
        _steps.Add(_nextStep);

        _nextStep = GetNextStep();
        _nextStep.View.SetNextStepState();
    }

    public void StepBack()
    {
        
    }

    private Cell GetNextStep()
    {
        var possibleSteps = map.GetFreeNeighbors(currentCell.QRS);
        return possibleSteps[Random.Range(0, possibleSteps.Count)];
    }
}
