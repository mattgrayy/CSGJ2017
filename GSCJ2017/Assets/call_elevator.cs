using UnityEngine;
using System.Collections;
using Rewired;

public class call_elevator : InteractableObject {

    [SerializeField] GameObject lift;
    [SerializeField] int floortogoto;
    [SerializeField]bool called=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(called)
        {
            lift.GetComponent<Elevator>().CallElevator(floortogoto);
           
        }
    if(lift.GetComponent<Elevator>().currentLOC == floortogoto)
        {
            called = false;
        }
	}

    void OnTriggerEnter(Collider col)
    {
      
    }


    override public void interact(int interactedPlayer)
    {
        if (!called)
        {
            called = true;
        }
    }
}
