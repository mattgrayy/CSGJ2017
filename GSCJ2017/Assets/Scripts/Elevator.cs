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

    public int ell;

    public bool puzzleOpen = false;
   
   [SerializeField] int floorchoice;
    public bool elevatorChild = false;

    void ElevatorUp()
    {

        transform.Translate(0, 2 * Time.deltaTime, 0);
    }
    void ElevatorDown()
    {

        transform.Translate(0, -2 * Time.deltaTime, 0);
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
    }

   public void CallElevator(int floortogo)
    {
        if (!MovingDown && !MovingUp)
        {
            ell = floortogo;

            if (currentLOC != floortogo)
            {
                if (floortogo < currentLOC)
                {
                    MovingDown = true;
                }
                if (floortogo > currentLOC)
                {
                    MovingUp = true;
                }
            }
        }
    }


    void OnCollisionEnter(Collision col)
    {
        col.transform.parent = transform;
        floorchoice = currentLOC;
        elevatorChild = true;
      
    }
    void OnCollisionExit(Collision col)
    {
        col.transform.parent = null;
        elevatorChild = false;
    }

    override public void interact(int interactedPlayer)
    {
        if (!puzzleOpen && (currentLOC == floorchoice) && !MovingDown && !MovingUp)
        {
            PuzzleManager.m_instance.loadElevatorPuzzle(interactedPlayer, this);
        }
    }

    override public void completedInteraction(bool outcome)
    {
        puzzleOpen = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (MovingUp)
        {
            if (col.gameObject == Top[ell-1])
            {
                MovingUp = false;
                currentLOC = ell;
            }
        }
        if (MovingDown)
        {
            if (col.gameObject == Bottom[ell])
            {
                MovingDown = false;
                currentLOC = ell;
            }
        }
    }
}
