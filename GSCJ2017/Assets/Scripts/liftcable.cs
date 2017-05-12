using UnityEngine;
using System.Collections;

public class liftcable : MonoBehaviour {

    public Transform roof;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (roof != null)
        {
            GetComponent<LineRenderer>().SetPosition(0, roof.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
	}
}
