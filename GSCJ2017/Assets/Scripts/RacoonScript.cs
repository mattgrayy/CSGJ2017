using UnityEngine;
using System.Collections;

public class RacoonScript : InteractableObject {

    override public void interact(int interactedPlayer)
    {
        if (GetComponent<BlockMove>().isRacooning)
        {
            PuzzleManager.m_instance.players[interactedPlayer].GetComponent<PlayerController>().racoonsScared++;
            PuzzleManager.m_instance.setPuzzleIdle(interactedPlayer);
            GetComponent<BlockMove>().stopRacooning();
        }
    }
}
