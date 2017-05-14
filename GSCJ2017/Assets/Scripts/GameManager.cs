using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    float worldTimer = 0, newEventTimer = 0, eventCoolDown = 0;
    int eventReserve = 1;
    public float eventThreshhold = 120f;

    public List<GameObject> events = new List<GameObject>();
    

    public List<FloorManager> floorManagers = new List<FloorManager>();

    [SerializeField] int globalScore = 0;
    [SerializeField] float globalStress = 0;
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

        worldTimer += Time.deltaTime;
        newEventTimer += Time.deltaTime;

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


        if (eventReserve > 0 && !eventsOnCoolDown)
        {

            //there is a chance for an event to trigger
            int eventChance = Random.Range(0, 100);

            switch (eventChance)
            {
                case 0:
                   //Alien
                    break;

                case 1:
                    //Pirate
                    //spawn point
                    // 3.86  17.12  -1.24

                    Instantiate(events[1], new Vector3(3.86f, 17.1f, -1.24f), Quaternion.identity);
                    
                    break;

                case 2:
                    //Fre
                    break;

                case 3:
                    //Fire
                    break;

                case 4:
                    //Fire
                    break;

                default:
                    //do nothing
                    break;

            }

        }





        if (stressOut)
        {
            globalStress = Mathf.Clamp(globalStress += Time.deltaTime, 0, 100);
        }
        else
        {
            globalStress = Mathf.Clamp(globalStress -= Time.deltaTime, 0, 100);
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
}
