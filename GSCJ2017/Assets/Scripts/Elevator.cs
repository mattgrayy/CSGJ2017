using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Elevator : MonoBehaviour
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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!MovingDown || !MovingUp)
        {
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    if (!bottom&&!MovingDown&&!MovingUp)
            //    {
                    
            //        MovingDown = true;
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    if (!top && !MovingDown && !MovingUp)
            //    {
                    
            //        MovingUp = true;
            //    }

            //}

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

    void ElevatorUp()
    {
        
        transform.Translate(0, 2 * Time.deltaTime, 0);
    }
    void ElevatorDown()
    {
        
        transform.Translate(0, -2 * Time.deltaTime, 0);
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
      
    }
    void OnCollisionExit(Collision col)
    {
        Debug.Log("vasectomy");
        col.transform.parent = null;
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
