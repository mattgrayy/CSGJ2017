using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_BreakOut : Puzzle {


    public GameObject playerWall;
    public USBall ball = null;

    public Text startText;
    bool timerGo = true;
    float wallXPos = 0, timer;


	// Update is called once per frame
	void Update () {
        
        if (timerGo)
        {
            timer += Time.deltaTime;
        }

        if (timer > 2 && timerGo)
        {
            startText.gameObject.SetActive(false);
            timerGo = false;
            ball.StartGame();
        }
        
                
        //Right
        if (player.GetAxis("Horizontal") > 0 && wallXPos < 80)
        {
            playerWall.transform.position = playerWall.transform.position + new Vector3(70, 0) * Time.deltaTime;
            wallXPos += 70 * Time.deltaTime;
        }

        //Left
        if (player.GetAxis("Horizontal") < 0 && wallXPos > -80)
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
        completePuzzle(true, 100);
    }



}
