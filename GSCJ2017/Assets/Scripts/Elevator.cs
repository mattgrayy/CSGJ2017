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

    int ell;
    bool callel;


    private Player player;
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
       if(elevatorChild)
        {
            interact(1);
        }

        if (!MovingDown || !MovingUp)
        {

        }

        if (MovingUp)
        {

            ElevatorUp();
        }
        if (MovingDown)
        {
            ElevatorDown();
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
    }

    

   public void CallElevator(int floortogo)
    {
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

    new  void interact(int interactedPlayer)
    {
        //if(  player.GetButtonDown("Up"))
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            floorchoice += 1;
            if (floorchoice > 3)
            {
                floorchoice = 3;
            }
        }

        //if (player.GetButtonDown("Down"))
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            floorchoice -= 1;
            if(floorchoice < 0)
            {
                floorchoice = 0;
            }
        }
        //if (player.GetButtonDown("Interact"))
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ell = floorchoice;
            callel = true;
           
            
        }
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
                currentLOC =2;
            }
            if (col.gameObject == Top[2])
            {
                Debug.Log("floor2U");
                MovingUp = false;
                top = true;
                currentLOC =3;
            }
        }
        if (MovingDown)
        {
            if (col.gameObject == Bottom[0])
            {
                Debug.Log("basement");
                MovingDown = false;
                bottom = true;
                currentLOC =0;
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
                currentLOC =2;
                top = false;
            }
            
         
        }
      
    }


   
}
