using UnityEngine;
using System.Collections;

public class Puzzle_Elevator : Puzzle{
    [SerializeField]  int floorchoice;
	// Use this for initialization
	void Start () {
       // floorchoice = myCreator.GetComponent<Elevator>().currentLOC;
    }
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
           
            if ( player.GetButtonDown("Up"))
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            floorchoice += 1 ;
               
                if (floorchoice > 3)
            {
                floorchoice = 3;
            }
        }

        if (player.GetButtonDown("Left"))
        //if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            floorchoice -= 1;
                
            if (floorchoice < 0)
            {
                floorchoice = 0;
            }
               
        }
            if (player.GetButtonDown("Interact"))
          
            {

                
              
                myCreator.GetComponent<Elevator>().ell = floorchoice;
                myCreator.GetComponent<Elevator>().callel = true;
                   
                    completePuzzle(true);
                   
                

            }
        }
    }
}
