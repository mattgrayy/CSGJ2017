using UnityEngine;
using System.Collections;
using Rewired;

public class call_elevator : MonoBehaviour {

    [SerializeField] GameObject lift;
    [SerializeField] int floortogoto;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {

        lift.GetComponent<Elevator>().CallElevator(floortogoto);
    }
    
}
