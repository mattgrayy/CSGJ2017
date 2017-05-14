using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Puzzle_Simon : Puzzle
{

    public Image up = null, down = null, left = null, right = null, upLight = null, downLight = null, rightLight = null, leftLight = null, 
        upLightPlayer = null, downLightPlayer = null, rightLightPlayer = null, leftLightPlayer = null, upLightPlayerWrong = null,
        downLightPlayerWrong = null, rightLightPlayerWrong = null, leftLightPlayerWrong = null;


    //sequence is done on the D-pad
    [SerializeField] List<int> sequence = new List<int>();
    public bool sequencePlaying = true, startTimerFInished = false;
    public int sequenceIndex = 0, attempts = 0;
    public float sequenceTimer = 0, startTimer = 0;

    bool playerInputDisabled = true;

    public int playerInputIndex = 0;

    public int dificulty = 1;


    void Start()
    {

        for (int i = 0; i < dificulty * 4; i++)
        {
            //cerate a sequence
            int direction = Random.Range(0, 4);

            sequence.Add(direction);

        }

        sequencePlaying = true;

    }



    void Update()
    {
        if (!startTimerFInished)
        {
            startTimer += Time.deltaTime;
        }

        
        if (sequencePlaying && startTimer > 1)
        {
            
            sequenceTimer += Time.deltaTime;

            
            switch (sequence[sequenceIndex])
            {

                case 0:

                    if (sequenceTimer < 0.5f)
                    {
                        upLight.gameObject.SetActive(true);
                    }
                    else
                    {
                        upLight.gameObject.SetActive(false);

                    }

                    if (sequenceTimer > 1)
                    {

                        sequenceIndex++;
                        sequenceTimer = 0;

                    }
                    break;

                case 1:

                    if (sequenceTimer < 0.5f)
                    {
                        downLight.gameObject.SetActive(true);
                    }
                    else
                    {
                        downLight.gameObject.SetActive(false);

                    }

                    if (sequenceTimer > 1)
                    {

                        sequenceIndex++;
                        sequenceTimer = 0;

                    }
                    break;

                case 2:

                    if (sequenceTimer < 0.5f)
                    {
                        rightLight.gameObject.SetActive(true);
                    }
                    else
                    {
                        rightLight.gameObject.SetActive(false);

                    }

                    if (sequenceTimer > 1)
                    {

                        sequenceIndex++;
                        sequenceTimer = 0;

                    }
                    break;

                case 3:

                    if (sequenceTimer < 0.5f)
                    {
                        leftLight.gameObject.SetActive(true);
                    }
                    else
                    {
                        leftLight.gameObject.SetActive(false);

                    }

                    if (sequenceTimer > 1)
                    {

                        sequenceIndex++;
                        sequenceTimer = 0;

                    }
                    break;
            }

            if (sequenceIndex >= sequence.Count)
            {

                sequencePlaying = false;
                sequenceTimer = 0;
                sequenceIndex = 0;
                playerInputIndex = 0;
                playerInputDisabled = false;

            }
        }








        if (!playerInputDisabled)
        {








            if (player.GetButtonDown("Up"))
            {

                if (sequence[playerInputIndex] == 0)
                {
                    //this is correct
                    playerInputIndex++;
                    Debug.Log(playerInputIndex);
                    upLightPlayer.gameObject.SetActive(true);

                }
                else
                {

                    //this is wrong start again
                    upLightPlayerWrong.gameObject.SetActive(true);
                    attempts++;
                }

            }

            if (player.GetButtonUp("Up"))
            {
                if (upLightPlayerWrong.IsActive() == true)
                {
                    sequencePlaying = true;
                    playerInputDisabled = true;
                   

                }
                                
                upLightPlayer.gameObject.SetActive(false);
                upLightPlayerWrong.gameObject.SetActive(false);
                downLightPlayer.gameObject.SetActive(false);
                downLightPlayerWrong.gameObject.SetActive(false);
                rightLightPlayer.gameObject.SetActive(false);
                rightLightPlayerWrong.gameObject.SetActive(false);
                leftLightPlayer.gameObject.SetActive(false);
                leftLightPlayerWrong.gameObject.SetActive(false);
            }












            if (player.GetButtonDown("Down"))
            {

                if (sequence[playerInputIndex] == 1)
                {
                    //this is correct
                    playerInputIndex++;
                    Debug.Log(playerInputIndex);
                    downLightPlayer.gameObject.SetActive(true);

                }
                else
                {

                    //this is wrong start again
                    downLightPlayerWrong.gameObject.SetActive(true);
                    attempts++;
                }

            }

            if (player.GetButtonUp("Down"))
            {
                if (downLightPlayerWrong.IsActive() == true)
                {
                    sequencePlaying = true;
                    playerInputDisabled = true;
                    
                }

                upLightPlayer.gameObject.SetActive(false);
                upLightPlayerWrong.gameObject.SetActive(false);
                downLightPlayer.gameObject.SetActive(false);
                downLightPlayerWrong.gameObject.SetActive(false);
                rightLightPlayer.gameObject.SetActive(false);
                rightLightPlayerWrong.gameObject.SetActive(false);
                leftLightPlayer.gameObject.SetActive(false);
                leftLightPlayerWrong.gameObject.SetActive(false);
            }













            if (player.GetButtonDown("Right"))
            {

                if (sequence[playerInputIndex] == 2)
                {
                    //this is correct
                    playerInputIndex++;
                    Debug.Log(playerInputIndex);
                    rightLightPlayer.gameObject.SetActive(true);
                }
                else
                {

                    //this is wrong start again
                    rightLightPlayerWrong.gameObject.SetActive(true);
                    attempts++;
                }

            }

            if (player.GetButtonUp("Right"))
            {
                if (rightLightPlayerWrong.IsActive() == true)
                {
                    sequencePlaying = true;
                    playerInputDisabled = true;

                }

                upLightPlayer.gameObject.SetActive(false);
                upLightPlayerWrong.gameObject.SetActive(false);
                downLightPlayer.gameObject.SetActive(false);
                downLightPlayerWrong.gameObject.SetActive(false);
                rightLightPlayer.gameObject.SetActive(false);
                rightLightPlayerWrong.gameObject.SetActive(false);
                leftLightPlayer.gameObject.SetActive(false);
                leftLightPlayerWrong.gameObject.SetActive(false);
            }















            if (player.GetButtonDown("Left"))
            {

                if (sequence[playerInputIndex] == 3)
                {
                    //this is correct
                    playerInputIndex++;
                    Debug.Log(playerInputIndex);
                    leftLightPlayer.gameObject.SetActive(true);
                }
                else
                {

                    //this is wrong start again
                    leftLightPlayerWrong.gameObject.SetActive(true);
                    attempts++;
                }

            }

            if (player.GetButtonUp("Left"))
            {
                if (leftLightPlayerWrong.IsActive() == true)
                {
                    sequencePlaying = true;
                    playerInputDisabled = true;

                }


                upLightPlayer.gameObject.SetActive(false);
                upLightPlayerWrong.gameObject.SetActive(false);
                downLightPlayer.gameObject.SetActive(false);
                downLightPlayerWrong.gameObject.SetActive(false);
                rightLightPlayer.gameObject.SetActive(false);
                rightLightPlayerWrong.gameObject.SetActive(false);
                leftLightPlayer.gameObject.SetActive(false);
                leftLightPlayerWrong.gameObject.SetActive(false);
            }

            

            if (playerInputIndex >= sequence.Count)
            {

                completePuzzle(true, 50);
            }


            if(attempts >= 4)
            {
                completePuzzle(false,0);
            }
        }



        
    }




}



