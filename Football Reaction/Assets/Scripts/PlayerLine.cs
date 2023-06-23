using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLine : MonoBehaviour
{
    public UnityEvent LossEvent;
    public UnityEvent PlayerChanged;

    [SerializeField] private Player[] _players;

    private Player _lastPlayer;

    private void OnEnable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.AddListener(ChangePlayer);
            player.PlayerKickedBallEvent.AddListener(OnPlayerKickedBall);
        }

        ChangePlayer(_players[_players.Length/2]);
    }

    private void OnPlayerKickedBall()
    {
        LossEvent?.Invoke();
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.RemoveListener(ChangePlayer);
            player.PlayerKickedBallEvent.RemoveListener(OnPlayerKickedBall);
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
            PlayerChanged?.Invoke();
            _lastPlayer.ChangeState(true);
        }

        _lastPlayer = player;
        _lastPlayer.ChangeState(false);
    }
}
