﻿using UnityEngine;
using System.Collections;
using Rewired;

public class Puzzle : MonoBehaviour {

    protected int playerIndex;
    protected Player player;

    public void setPlayer(int _playerIndex)
    {
        playerIndex = _playerIndex;
        player = ReInput.players.GetPlayer(playerIndex);
    }

    protected void completePuzzle(bool won)
    {
        PuzzleManager.m_instance.puzzleComplete(won, playerIndex);
    }
}
