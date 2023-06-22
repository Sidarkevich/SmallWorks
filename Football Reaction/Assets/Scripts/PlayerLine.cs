using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    [SerializeField] private Player[] _players;

    private Player _lastPlayer;

    private void OnEnable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.AddListener(ChangePlayer);
        }

        ChangePlayer(_players[_players.Length/2]);
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.PlayerClickedEvent.RemoveListener(ChangePlayer);
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
