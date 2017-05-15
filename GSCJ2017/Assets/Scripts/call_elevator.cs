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

    public bool broken = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
     


        if (lift.GetComponent<Elevator>().currentLOC == floortogoto)
        {
            called = false;
        }


    }

    void OnTriggerEnter(Collider col)
    {
      
    }


    override public void interact(int interactedPlayer)
    {
        if (Random.Range(0, 10) == 0)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                    buttons[i].breakObject();
            }
            breakObject();
        }

        if (!broken)
        {
          
                lift.GetComponent<Elevator>().CallElevator(floortogoto);
            
        }

        if (broken)
        {
            PuzzleManager.m_instance.loadPuzzle(interactedPlayer, this);
        }
        
    }



    public void breakObject()
    {
        if (!broken)
        {
            broken = true;
            AlertImage.enabled = true;
            sparksParticle.SetActive(true);
        }
    }

    public void fixObject()
    {
        if (broken)
        {
            broken = false;
            AlertImage.enabled = false;
            sparksParticle.SetActive(false);
        }
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
