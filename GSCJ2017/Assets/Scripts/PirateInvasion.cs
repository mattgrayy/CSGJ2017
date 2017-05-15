using UnityEngine;
using System.Collections.Generic;

public class PirateInvasion : MonoBehaviour {

    public GameObject anchorTop = null, boat = null, explosion = null, roofPiece = null;
    [SerializeField] Transform target = null;
    public float waitTimer = 0;

    public List<BlockMove> pirates = new List<BlockMove>();
    public int abductedPlayerIndex;


    public bool entranceComplete = false, waiting = false, puzzleLoaded = false;
    
	// Use this for initialization
	void Awake () {

        Instantiate(explosion, target.transform.position, Quaternion.identity);

        foreach (BlockMove pirate in pirates)
        {
            pirate.floorManager = GameManager.m_instance.floorManagers[0];
            pirate.invaderControlerP = this;
            pirate.abductor = true;
            pirate.SetTargetObject(pirate.floorManager.requestJob());
        }


    }

    // Update is called once per frame
    void Update() {

        if (waiting)
        {
            waitTimer += Time.deltaTime;
        }

        if (waitTimer > 3)
        {

            waiting = false;

            //pirates leave
            foreach (BlockMove pirate in pirates)
            {
                pirate.canMove = false;
                pirate.transform.parent = transform;
            }

            //then leave
            if (transform.position.y < 0)
            {
                //retract anchor
                transform.Translate(new Vector3(0, 15, 0) * Time.deltaTime);
            }
            else
            {
                if (!puzzleLoaded)
                {
                    PuzzleManager.m_instance.loadWorldEventPuzzle(abductedPlayerIndex, GetComponent<InteractableObject>());
                    puzzleLoaded = true;
                }
            }
            
        }


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
            foreach(BlockMove pirate in pirates)
            {
                pirate.canMove = true;
                pirate.transform.parent = null;
                
            }
            
        }

        GetComponent<LineRenderer>().SetPosition(0, boat.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, anchorTop.transform.position);
        

    }


    public void recalInvaders()
    {
        foreach (BlockMove pirate in pirates)
        {
            pirate.SetTargetObject(transform.FindChild("Anchor Model").transform);
            pirate.leaving = true;
            pirate.Gottem = true;
        }

        waiting = true;

    }



}
