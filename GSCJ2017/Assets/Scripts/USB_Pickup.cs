using UnityEngine;
using System.Collections;

public class USB_Pickup : InteractableObject {

    override public void interact(int interactedPlayer)
    {
        Destroy(gameObject);
    }
}
