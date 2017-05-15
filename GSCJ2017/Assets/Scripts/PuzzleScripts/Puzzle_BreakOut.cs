using UnityEngine;
using System.Collections;

public class Puzzle_BreakOut : Puzzle {


    public GameObject playerWall;


    float wallXPos = 0;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Right
        if (player.GetAxis("Horizontal") > 0 && wallXPos < 50)
        {
            playerWall.transform.position = playerWall.transform.position + new Vector3(70, 0) * Time.deltaTime;
            wallXPos += 70 * Time.deltaTime;
        }

        //Left
        if (player.GetAxis("Horizontal") < 0 && wallXPos > -50)
        {
            playerWall.transform.position = playerWall.transform.position + new Vector3(-70, 0) * Time.deltaTime;
            wallXPos += -70 * Time.deltaTime;
        }


    }


    public void LosePuzzle()
    {
        completePuzzle(true, -25);
    }

    public void WinPuzzle()
    {
        completePuzzle(true, 50);
    }



}
