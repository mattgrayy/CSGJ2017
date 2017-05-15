using UnityEngine;
using System.Collections;

public class WorldEventInteractable : InteractableObject
{
    override public void completedInteraction(bool outcome)
    {


        //unparent player
        //make rotation zero
        //enable movment
        if (GetComponent<PirateInvasion>() != null)
        {
            GetComponent<PirateInvasion>().abductedPlayer.transform.rotation = Quaternion.identity;
            GetComponent<PirateInvasion>().abductedPlayer.parent = null;
            GetComponent<PirateInvasion>().abductedPlayer.GetComponent<PlayerController>().canMove = true;
            GetComponent<PirateInvasion>().abductedPlayer.GetComponent<Rigidbody>().isKinematic = false;

            Destroy(gameObject);

        }

        //delete invasion

    }
}
