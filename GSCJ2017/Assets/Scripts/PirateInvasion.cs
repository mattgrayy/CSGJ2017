using UnityEngine;
using System.Collections;

public class PirateInvasion : MonoBehaviour {

    [SerializeField] GameObject anchorTop = null, boat = null, explosion = null, roofPiece = null;
    [SerializeField] Transform target = null;
    

    bool entranceComplete = false;
    
	// Use this for initialization
	void Start () {


        Debug.Log("booom!!!");
        Instantiate(explosion, target.transform.position, Quaternion.identity);
        roofPiece.SetActive(false);
        
	}

    // Update is called once per frame
    void Update() {


        //drop the anchor
        if (transform.position.y > 8.8 && !entranceComplete)
        {
            transform.Translate(new Vector3(0, -15, 0) * Time.deltaTime);

        }
        else
        {
            entranceComplete = true;
        }
        
        GetComponent<LineRenderer>().SetPosition(0, boat.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, anchorTop.transform.position);







    }
}
