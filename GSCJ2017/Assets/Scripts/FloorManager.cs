using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour {

    public List<BreakableObject> jobs = new List<BreakableObject>();
    [SerializeField] List<Transform> nullJobs = new List<Transform>();

    public bool onFire = false, TimerStart = false;
    [SerializeField] GameObject sprinklerSystem, Fire;
    public float burnTimer = 0;
    


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
            Fire.gameObject.SetActive(false);


            burnTimer = 0;

            ParticleSystem.ShapeModule shapeMod = Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().shape;
            shapeMod.radius = 1;

            ParticleSystem.EmissionModule emisionMod = Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().emission;
            emisionMod.rate = 50;

            ParticleSystem.ShapeModule shapeMod2 = Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().shape;
            shapeMod2.radius = 1;

            ParticleSystem.EmissionModule emisionMod2 = Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().emission;
            emisionMod2.rate = 50;

            ParticleSystem.ShapeModule shapeMod3 = Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().shape;
            shapeMod3.radius = 1;

            ParticleSystem.EmissionModule emisionMod3 = Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().emission;
            emisionMod3.rate = 10;





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



        if (onFire && burnTimer <= 7)
        {
            burnTimer += Time.deltaTime;

            Fire.gameObject.SetActive(true);

            ParticleSystem.ShapeModule shapeMod = Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().shape;
            shapeMod.radius = 1 + 1 * burnTimer;

            ParticleSystem.EmissionModule emisionMod = Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().emission;
            emisionMod.rate = 50 + 50 * burnTimer;


            ParticleSystem.ShapeModule shapeMod2 = Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().shape;
            shapeMod2.radius = 1 + 1 * burnTimer;

            ParticleSystem.EmissionModule emisionMod2 = Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().emission;
            emisionMod2.rate = 50 + 50 * burnTimer;

            ParticleSystem.ShapeModule shapeMod3 = Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().shape;
            shapeMod3.radius = 1 + 1 * burnTimer;

            ParticleSystem.EmissionModule emisionMod3 = Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().emission;
            emisionMod3.rate = 10 + 10 * burnTimer;
            

        }
        






    }

    


}
