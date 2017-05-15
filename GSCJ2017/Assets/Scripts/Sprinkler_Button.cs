using UnityEngine;
using System.Collections;



public class Sprinkler_Button : InteractableObject
{

    public GameManager theMan;

    float timer = 0, pressedTimer = 0;
    bool startTimer = false, triggerAllFloors = false, canWater = false, beenPressed = false;
    int ranFloor = 0;
   int targetFloor = 7;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (startTimer)
        {
            timer += Time.deltaTime;
        }


        if (beenPressed)
        {
            pressedTimer += Time.deltaTime;

            if (pressedTimer > 6)
            {
                beenPressed = false;
                pressedTimer = 0;
            }

        }


        if (timer >= 2f && canWater)
        {
            canWater = false;
            if (!triggerAllFloors)
            {

                Debug.Log("floor fire:" + targetFloor);
                theMan.PutOutFireOnFloor(targetFloor);
                canWater = false;
            }
            else
            {
                Debug.Log("floor fire:" + ranFloor);

                theMan.PutOutFireOnFloor(ranFloor);
                canWater = false;

            }

        }

        if (timer > 5)
        {

            startTimer = false;
            timer = 0;

            theMan.DeactivateAllSprinklers();
            
            
        }
        
    }

    override public void interact(int interactedPlayer)
    {
        if (!beenPressed)
        {
            beenPressed = true;
            startTimer = true;
            canWater = true;
            targetFloor = 7;
            triggerAllFloors = false;

            if (startTimer == true)
            {
                timer = 0f;
            }


            //check if there is a fire on any of the floors
            //if there is then call putPutFire for that floor
            //and the floor above if there is one
            int i = 0;

            foreach (FloorManager floor in theMan.floorManagers)
            {
                if (floor.onFire)
                {

                    targetFloor = i;
                    theMan.StartSprinklers(i);


                }

                i++;

            }



            //if there is no fire call all the floors to put out their fires
            if (targetFloor == 7)
            {
                triggerAllFloors = true;

                ranFloor = Random.Range(0, 3);
                
                theMan.StartSprinklers(ranFloor);

            }

        }
    }




}
