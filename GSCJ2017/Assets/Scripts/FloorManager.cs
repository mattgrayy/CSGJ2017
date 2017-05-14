using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour {

    [SerializeField] List<BreakableObject> jobs = new List<BreakableObject>();
    [SerializeField] List<Transform> nullJobs = new List<Transform>();

    public bool onFire = false, TimerStart = false, burning = false;
    [SerializeField] GameObject sprinklerSystem, Fire;
    float burnTimer = 0;
    


    public Transform requestJob()
    {
        int jobIndex = getRandomJob();

        if(jobIndex != 99)
        {
            jobs[jobIndex].setIsInUse(true);
            return jobs[jobIndex].transform;
        }
        // only null jobs left

        int randIndex = Random.Range(0, nullJobs.Count);

        return nullJobs[randIndex];
    }

    int getRandomJob()
    {
        int selectionType = Random.Range(0, 4);

        switch (selectionType)
        {
            case 0:
                for (int i = 0; i < jobs.Count; i++)
                {
                    if (!jobs[i].getIsBroken() && !jobs[i].getIsInUse())
                    {
                        return i;
                    }
                }
                break;
            case 1:
                for (int i = jobs.Count-1; i > 0; i--)
                {
                    if (!jobs[i].getIsBroken() && !jobs[i].getIsInUse())
                    {
                        return i;
                    }
                }
                break;
            case 2:
                int randIndex = Random.Range(0, jobs.Count);
                for (int i = randIndex; i > 0; i--)
                {
                    if (!jobs[i].getIsBroken() && !jobs[i].getIsInUse())
                    {
                        return i;
                    }
                }
                break;
            case 3:
                int randIndex2 = Random.Range(0, jobs.Count);
                for (int i = randIndex2; i < jobs.Count; i++)
                {
                    if (!jobs[i].getIsBroken() && !jobs[i].getIsInUse())
                    {
                        return i;
                    }
                }
                break;
            default:
                break;
        }
        return 99;
    }

    public void PutOutFire(bool ExtinguishFire)
    {

        //activate the sprinkeler system for this foor
        sprinklerSystem.SetActive(true);
        
        if (ExtinguishFire)
        {
            //and put out the fire after a timer
            onFire = false;

            //also get all the breakable object on the floor and break them all!!!
            foreach (BreakableObject obj in jobs)
            {
                obj.breakObject();
            }
        }

        
    }


    public void DeactivateSprinklers()
    {
        sprinklerSystem.SetActive(false);
    }




    void Update()
    {



        if (onFire)
        {


            Fire.gameObject.SetActive(true);

            //player cant fix things either



        }
        else
        {

            Fire.gameObject.SetActive(false);
            
        }






    }

    


}
