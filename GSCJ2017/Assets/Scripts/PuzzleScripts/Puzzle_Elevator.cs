using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Puzzle_Elevator : Puzzle
{
    [SerializeField]  int floorchoice;
    [SerializeField]Text floornum;
    public bool started;
    float timer = 0;
    bool endel=false;
    // Use this for initialization
    override public void setPlayer(int _playerIndex, InteractableObject _creator)
    {
        base.setPlayer(_playerIndex, _creator);    

        floorchoice = myCreator.GetComponent<Elevator>().currentLOC;
        floornum.text = floorchoice.ToString();
        started = true;
    
    }
	
	// Update is called once per frame
    void Update ()
    {
        if(player != null)
        {
           
            if (player.GetButtonDown("Up"))
            {
                floorchoice += 1;

                if (floorchoice > 3)
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


            if (player.GetButtonDown("Interact"))
            {
                myCreator.GetComponent<Elevator>().ell = floorchoice;
                myCreator.GetComponent<Elevator>().callel = true;
             
                floornum.text = floorchoice.ToString();
                endel = true;
                timer = 0.1f;
            }


            if (endel)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    completePuzzle(true);
                }
            }
        }
    }
}

           
        
    

