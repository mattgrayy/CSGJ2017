using UnityEngine;
using System.Collections;

public class Puzzle_Elevator : Puzzle{
      int floorchoice;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        { 
        if ( player.GetButton("Up"))
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            floorchoice += 1;
            if (floorchoice > 3)
            {
                floorchoice = 3;
            }
        }

        if (player.GetButtonDown("Down"))
        //if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            floorchoice -= 1;
            if (floorchoice < 0)
            {
                floorchoice = 0;
            }
        }
            if (player.GetButtonDown("Interact"))
            //if (Input.GetKeyDown(KeyCode.Return))
            {
                myCreator.GetComponent<Elevator>().CallElevator(floorchoice);
                if (myCreator.GetComponent<Elevator>().currentLOC == floorchoice)
                {
                    completePuzzle(true);
                }

            }
        }
    }
}
