using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    virtual public void interact(int interactedPlayer)
    {
       
    }

    virtual public void completedInteraction(bool outcome)
    {

    }
}
