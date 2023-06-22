using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLine : MonoBehaviour
{
    public UnityEvent LossEvent;
    public UnityEvent GoalEvent;

    [SerializeField] private Player[] _players;
    [SerializeField] private ScoreHandler _score;

    private Player _lastPlayer;

    private void OnEnable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.AddListener(ChangePlayer);
            player.PlayerKickedBallEvent.AddListener(OnPlayerKickedBall);
            player.PlayerSkippedBallEvent.AddListener(OnPlayerSkippedBall);
        }

        ChangePlayer(_players[_players.Length/2]);
    }

    private void OnPlayerKickedBall()
    {
        LossEvent?.Invoke();
    }

    private void OnPlayerSkippedBall()
    {
        _score.IncreaseScore(1);
        GoalEvent?.Invoke();
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.RemoveListener(ChangePlayer);
            player.PlayerKickedBallEvent.RemoveListener(OnPlayerKickedBall);
            player.PlayerSkippedBallEvent.RemoveListener(OnPlayerSkippedBall);
        }
    }

    private void ChangePlayer(Player player)
    {
        if (_lastPlayer == player)
        {
            return;
        }

        if (_lastPlayer)
        {
            _lastPlayer.ChangeState(true);
        }

        _lastPlayer = player;
        _lastPlayer.ChangeState(false);
    }
}
