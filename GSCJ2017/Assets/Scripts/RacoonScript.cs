using UnityEngine;
using System.Collections;

public class RacoonScript : InteractableObject {

    override public void interact(int interactedPlayer)
    {
        GetComponent<BlockMove>().stopRacooning();
    }
}
