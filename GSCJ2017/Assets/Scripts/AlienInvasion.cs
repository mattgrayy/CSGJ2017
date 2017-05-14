using UnityEngine;
using System.Collections;

public class AlienInvasion : MonoBehaviour {

    bool entranceComplete = false;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        // move UFO
        //1 , 12.4, -1.2        
        if (transform.position.y > 8.8 && !entranceComplete)
        {
            transform.Translate(new Vector3(0, -15, 0) * Time.deltaTime);

        }
        else
        {
            entranceComplete = true;
        }




    }
}
