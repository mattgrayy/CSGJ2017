using UnityEngine;
using System.Collections;

public class PirateInvasion : MonoBehaviour {

    public GameObject anchorTop = null, boat = null, explosion = null, roofPiece = null;
    [SerializeField] Transform target = null;
    

    public bool entranceComplete = false;
    
	// Use this for initialization
	void Awake () {


        Instantiate(explosion, target.transform.position, Quaternion.identity);
        
	}

    // Update is called once per frame
    void Update() {

        if (roofPiece != null)
        {
            roofPiece.gameObject.SetActive(false);
        }


        //drop the anchor
        if (transform.position.y > 8.8 && !entranceComplete)
        {
            transform.Translate(new Vector3(0, -15, 0) * Time.deltaTime);

        }
        else
        {
            entranceComplete = true;

            //unparent pirates
            //let them move

        }

        GetComponent<LineRenderer>().SetPosition(0, boat.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, anchorTop.transform.position);







    }
}
