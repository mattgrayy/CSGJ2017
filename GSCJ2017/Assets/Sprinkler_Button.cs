using UnityEngine;
using System.Collections;



public class Sprinkler_Button : InteractableObject
{

    public GameManager theMan;

    float timer = 0;
    bool startTimer = false, triggerAllFloors = false;

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

        if (timer >= 2f)
        {
            if (!triggerAllFloors)
            {
                Debug.Log(targetFloor);
                theMan.PutOutFireOnFloor(targetFloor);
                
            }
            else
            {
                theMan.PutOutFireOnFloor(0);
                theMan.PutOutFireOnFloor(1);
                theMan.PutOutFireOnFloor(2);

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
        startTimer = true;
        targetFloor = 7;

        if (startTimer == true)
        {
            timer = 2f;
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
                Debug.Log(targetFloor);

            }

            i++;

        }
        


        //if there is no fire call all the floors to put out their fires
        if (targetFloor == 7)
        {
            triggerAllFloors = true;
            theMan.StartSprinklers(0);
            theMan.StartSprinklers(1);
            theMan.StartSprinklers(2);

        }

        
    }




}
