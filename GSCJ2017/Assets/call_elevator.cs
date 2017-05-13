using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine.UI;

public class call_elevator : InteractableObject {

    [SerializeField] GameObject lift;
    [SerializeField] int floortogoto;
    [SerializeField]bool called=false;


    [SerializeField]
    GameObject sparksParticle;
    [SerializeField]
    Image AlertImage;

    [SerializeField] List<call_elevator> buttons;

    bool broken = false;
    bool inUse = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(broken)
        {
            for(int i=0; i<buttons.Count; i++)
            {
                buttons[i].breakObject();
            }
        }

        if (called)
        {
           
                lift.GetComponent<Elevator>().CallElevator(floortogoto);

            
            if (lift.GetComponent<Elevator>().currentLOC == floortogoto)
            {
                called = false;
            }
        }
        
       
    }

    void OnTriggerEnter(Collider col)
    {
      
    }


    override public void interact(int interactedPlayer)
    {
        if (Random.Range(0, 4) == 0)
        {
            breakObject();
        }
            if(!called && !broken)
            {
                called = true;
            }
            else if (broken)
            {
                PuzzleManager.m_instance.loadPuzzle(interactedPlayer, this);
            }
        
    }



    public void breakObject()
    {
        broken = true;
        AlertImage.enabled = true;
        sparksParticle.SetActive(true);
    }

    public void fixObject()
    {
        broken = false;
        AlertImage.enabled = false;
        sparksParticle.SetActive(false);
    }

    public bool getIsBroken()
    {
        return broken;
    }

    override public void completedInteraction(bool outcome)
    {
        if (outcome)
        {
            fixObject();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].fixObject();
            }
        }
       
    }
}
