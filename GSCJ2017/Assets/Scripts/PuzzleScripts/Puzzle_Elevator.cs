using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Puzzle_Elevator : Puzzle{
    [SerializeField]  int floorchoice;
    [SerializeField]Text floornum;
    bool started = false;
	// Use this for initialization
	void Start () {
        floorchoice = myCreator.GetComponent<Elevator>().currentLOC;
       // floornum.text = floorchoice.ToString();
        started = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
           
                if (player.GetButtonDown("Up"))
                {
                    floorchoice += 1;

                    if (floorchoice > 2)
                    {
                        floorchoice = 3;
                    }
                    floornum.text = floorchoice.ToString();
                }

                if (player.GetButtonDown("Left"))

                {
                    floorchoice -= 1;

                    if (floorchoice < 0)
                    {
                        floorchoice = 0;
                    }
                    floornum.text = floorchoice.ToString();
                }
                Debug.Log(started);
            
   


                    if (player.GetButtonDown("Interact"))

                    {
                started = true;
                if (started)
                {

                    myCreator.GetComponent<Elevator>().ell = floorchoice;
                    myCreator.GetComponent<Elevator>().callel = true;
                }
                completePuzzle(true);
                Debug.Log(started);
               // floornum.text = myCreator.GetComponent<Elevator>().currentLOC.ToString();
            }
                    
       
        }
    }
}
           
        
    

