﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class GameManager : MonoBehaviour {

    [SerializeField] float worldTimer = 0, newEventTimer = 0, eventCoolDown = 0, chanceTimer = 0;
    [SerializeField] int eventReserve = 0;
    public float eventThreshhold = 30f;
    public GameObject roofPiece = null, boom = null, target = null;
    

    public List<GameObject> events = new List<GameObject>();

    public List<FloorManager> floorManagers = new List<FloorManager>();
    [SerializeField] Image failingImage;

    [SerializeField] Image startScreen;
    [SerializeField] Image endScreen;
    public float endGameTimer = 0;

    public bool gameStarted = false;

    public int globalScore = 0;
    public float globalStress = 0;
    bool stressOut = false, eventsOnCoolDown = true;

    public static GameManager m_instance = null;

    void Start()
    {
        if (m_instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
        }
    }

    void Update()
    {
        if (gameStarted)
        {
            worldTimer += Time.deltaTime;
            newEventTimer += Time.deltaTime;
            chanceTimer += Time.deltaTime;

            if (newEventTimer >= eventThreshhold)
            {
                newEventTimer = 0;
                eventReserve++;
            }

            if (eventsOnCoolDown)
            {
                eventCoolDown += Time.deltaTime;

                if (eventCoolDown > eventThreshhold)
                {
                    eventsOnCoolDown = false;
                    eventCoolDown = 0;
                }
            }

            if (eventReserve > 0 && !eventsOnCoolDown && chanceTimer > 5)
            {
                //there is a chance for an event to trigger
                int eventChance = Random.Range(0, 10);

                switch (eventChance)
                {
                    /*
                    case 0:
                        //Alien
                        GameObject eventt1 = Instantiate(events[0], new Vector3(-5.3f, 19.1f, -1.24f), Quaternion.identity) as GameObject;
                        eventt1.GetComponent<AlienInvasion>().roofPiece = roofPiece;
                        eventt1.GetComponent<AlienInvasion>().target = target.transform;
                        

                        eventReserve--;
                        eventsOnCoolDown = true;
                        break;
                        */

                    case 1:
                        //Pirate
                        //spawn point
                        // 3.86  17.12  -1.24

                        GameObject eventt2 = Instantiate(events[1], new Vector3(3.86f, 17.1f, -1.24f), Quaternion.identity) as GameObject;
                        eventt2.GetComponent<PirateInvasion>().roofPiece = roofPiece;
                        

                        eventReserve--;
                        eventsOnCoolDown = true;
                        break;

                    case 2:
                    case 3:
                    case 4:
                        //Fire
                        int ranFloor = Random.Range(0, 3);
                        floorManagers[ranFloor].onFire = true;

                        eventReserve--;
                        eventsOnCoolDown = true;
                        break;


                    default:
                        //do nothing




                        break;
                }

                chanceTimer = 0;

            }


            if (stressOut)
            {
                globalStress = Mathf.Clamp(globalStress += Time.deltaTime, 0, 100);

                if (failingImage.color.a < 1)
                {
                    failingImage.color = new Color(failingImage.color.r, failingImage.color.g, failingImage.color.b, (globalStress / 200));
                }

                if (globalStress == 100 && endGameTimer <=0)
                {
                    endGameTimer = 3;
                    endScreen.gameObject.SetActive(true);
                }
            }
            else
            {
                globalStress = Mathf.Clamp(globalStress -= Time.deltaTime/3, 0, 100);

                if (failingImage.color.a > 0)
                {
                    failingImage.color = new Color(failingImage.color.r, failingImage.color.g, failingImage.color.b, (globalStress / 200));
                }
            }

            if (endGameTimer > 0)
            {
                endGameTimer -= Time.deltaTime;


                if (endGameTimer <= 0)
                {
                    Debug.Log("Ended");
                    gameOver();
                }
            }
        }
        else
        {
            foreach (Player p in ReInput.players.GetPlayers())
            {
                if (p.GetButtonDown("Start"))
                {
                    gameStarted = true;
                    startScreen.gameObject.SetActive(false);
                }
            }
        }
    }

    public void PutOutFireOnFloor(int floorIndex)
    {
        floorManagers[floorIndex].PutOutFire(true);
    }
    public void StartSprinklers(int floorIndex)
    {
        floorManagers[floorIndex].PutOutFire(false);
    }

    public void DeactivateAllSprinklers()
    {
        foreach (FloorManager floor in floorManagers)
        {
            if (floor.gameObject.name != "Basement")
            {
                floor.DeactivateSprinklers();
            }
        }
    }

    public void addToGlobalScore(int _scoreToAdd)
    {
        globalScore += _scoreToAdd;
        addToGlobalStress(-1);
    }

    public void addToGlobalStress(int _stressToAdd)
    {
        globalStress += _stressToAdd;
        checkStressLevels();
    }

    void checkStressLevels()
    {
        int totalJobs = 0;
        int brokenJobs = 0;

        foreach (FloorManager floor in floorManagers)
        {
            foreach (BreakableObject obj in floor.jobs)
            {
                totalJobs++;

                if (obj.getIsBroken())
                {
                    brokenJobs++;
                }
            }
        }

        if (brokenJobs > totalJobs/2)
        {
            stressOut = true;
        }
        else
        {
            stressOut = false;
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene("TempLoader");
    }

    
}
