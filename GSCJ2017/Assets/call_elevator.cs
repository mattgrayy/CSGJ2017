using UnityEngine;
using System.Collections;
using Rewired;

public class call_elevator : MonoBehaviour {

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
        Debug.Log("ITS A COMING"+floortogoto);
        if (!called)
        {
            called = true;
        }
    }
    
}
