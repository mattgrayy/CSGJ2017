using UnityEngine;
using System.Collections;
using Rewired;

public class Puzzle : MonoBehaviour {

    protected int playerIndex;
    protected Player player;
    InteractableObject myCreator;

    public void setPlayer(int _playerIndex, InteractableObject _creator)
    {
        playerIndex = _playerIndex;
        player = ReInput.players.GetPlayer(playerIndex);
        myCreator = _creator;
    }

    protected void completePuzzle(bool won)
    {
        PuzzleManager.m_instance.puzzleComplete(won, playerIndex, myCreator);
        Destroy(gameObject);
    }
}
