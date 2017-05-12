using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rewired;

public class Elevator : InteractableObject
{

    [SerializeField]List<GameObject> Top;
    [SerializeField] List<GameObject> Bottom;
    [SerializeField]
    public int currentLOC;
    [SerializeField]
   bool MovingUp;
    [SerializeField]
    bool MovingDown;
    [SerializeField]
    bool top;
    [SerializeField]
    bool bottom;

    public int ell;
    public bool callel;


   
   [SerializeField] int floorchoice;
    public bool elevatorChild = false;
    // Use this for initialization


    


    void ElevatorUp()
    {

        transform.Translate(0, 2 * Time.deltaTime, 0);
    }
    void ElevatorDown()
    {

        transform.Translate(0, -2 * Time.deltaTime, 0);
    }

    

    void Start()
    {
        

    }
  
    // Update is called once per frame
    void Update()
    {
      

        if (!MovingDown || !MovingUp)
        {



            if (MovingUp)
            {

                ElevatorUp();
            }
            if (MovingDown)
            {
                ElevatorDown();
            }


            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            callel = true;
            ell = 0;

        }



        if (Input.GetKeyDown(KeyCode.U))
        {
            callel = true;
            ell = 1;

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            callel = true;
            ell = 2;

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            callel = true;
            ell = 3;

        }

        if (callel)
        {
            CallElevator(ell);
        }

        if (MovingDown&&MovingUp)
        {
            MovingUp = false;
            MovingDown = false;
            Debug.Log("UP AND DOWN");
        }
    }

    

   public void CallElevator(int floortogo)
    {
        floorchoice = floortogo;
        if(currentLOC!= floortogo)
        {
            if(floortogo<currentLOC)
            {
               
                  MovingDown = true;
            }
            if(floortogo>currentLOC)
            {

               
               
                MovingUp = true;
            }
        }
        if(currentLOC==floortogo)
        {
            callel = false;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("chillen");
        col.transform.parent = transform;
        floorchoice = currentLOC;
        elevatorChild = true;
      
    }
    void OnCollisionExit(Collision col)
    {
        Debug.Log("vasectomy");
        col.transform.parent = null;
        elevatorChild = false;
    }

    override public void interact(int interactedPlayer)
    {
        Debug.Log("Elle is called");
        PuzzleManager.m_instance.loadElevatorPuzzle(interactedPlayer, this);
    }

    void OnTriggerEnter(Collider col)
    {
        
            if (MovingUp)
            {

                if (col.gameObject == Top[0])
                {
                    Debug.Log("groundU");
                    MovingUp = false;
                    bottom = false;
                    currentLOC = 1;
                }

                if (col.gameObject == Top[1])
                {
                    Debug.Log("floor1U");
                    MovingUp = false;
                    currentLOC = 2;
                }
                if (col.gameObject == Top[2])
                {
                    Debug.Log("floor2U");
                    MovingUp = false;
                    top = true;
                    currentLOC = 3;
                }

            }
            if (MovingDown)
            {
                if (col.gameObject == Bottom[0])
                {
                    Debug.Log("basement");
                    MovingDown = false;
                    bottom = true;
                    currentLOC = 0;
                }

                if (col.gameObject == Bottom[1])
                {
                    Debug.Log("groundD");
                    MovingDown = false;
                    currentLOC = 1;
                }

                if (col.gameObject == Bottom[2])
                {
                    Debug.Log("floor1D");
                    MovingDown = false;
                    currentLOC = 2;
                    top = false;
                }


            }
        }



   
}
