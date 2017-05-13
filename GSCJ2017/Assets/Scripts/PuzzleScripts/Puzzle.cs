using UnityEngine;
using System.Collections;
using Rewired;

public class Puzzle : MonoBehaviour {

    protected int playerIndex;
    protected Player player;
    protected InteractableObject myCreator;

    virtual public void setPlayer(int _playerIndex, InteractableObject _creator)
    {
        playerIndex = _playerIndex;
        player = ReInput.players.GetPlayer(playerIndex);
        myCreator = _creator;
    }

    protected void completePuzzle(bool outcome)
    {
        PuzzleManager.m_instance.puzzleComplete(outcome, playerIndex, myCreator);
        Destroy(gameObject);
    }
}
