﻿using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour {

    public List<BreakableObject> jobs = new List<BreakableObject>();
    [SerializeField] List<Transform> nullJobs = new List<Transform>();

    public bool onFire = false, TimerStart = false, audioPlay = false, audioStarted = false;
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
        sprinklerSystem.transform.FindChild("Water sprinkelers 1").GetComponent<ParticleSystem>().Play();
        sprinklerSystem.transform.FindChild("Water sprinkelers 2").GetComponent<ParticleSystem>().Play();
        sprinklerSystem.transform.FindChild("Water sprinkelers 3").GetComponent<ParticleSystem>().Play();

        if (!ExtinguishFire)
        {
            sprinklerSystem.GetComponent<AudioSource>().Play();
        }

        if (ExtinguishFire)
        {
            //and put out the fire after a timer
            onFire = false;
            Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().Stop();
            Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().Stop();
            Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().Stop();
            
            audioStarted = false;


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
        sprinklerSystem.transform.FindChild("Water sprinkelers 1").GetComponent<ParticleSystem>().Stop();
        sprinklerSystem.transform.FindChild("Water sprinkelers 2").GetComponent<ParticleSystem>().Stop();
        sprinklerSystem.transform.FindChild("Water sprinkelers 3").GetComponent<ParticleSystem>().Stop();
    }




    void Update()
    {
        if (gameObject.name != "Basement")
        {

            if (audioPlay)
            {
                GetComponent<AudioSource>().Play();
                Fire.GetComponent<AudioSource>().Play();
                audioPlay = false;
            }

            if (onFire && burnTimer <= 7)
            {
                burnTimer += Time.deltaTime;

                Fire.transform.FindChild("Fires").GetComponent<ParticleSystem>().Play();
                Fire.transform.FindChild("Sparks").GetComponent<ParticleSystem>().Play();
                Fire.transform.FindChild("Smoke").GetComponent<ParticleSystem>().Play();

                if (!audioStarted)
                {
                    audioStarted = true;
                    audioPlay = true;
                }

                
                Fire.GetComponent<AudioSource>().volume = 0.1f * burnTimer;


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


            if (!onFire)
            {
                if (Fire.GetComponent<AudioSource>().volume > 0)
                {
                    Fire.GetComponent<AudioSource>().volume -= 0.5f * Time.deltaTime;
                }

                if (Fire.GetComponent<AudioSource>().volume == 0)
                {
                    Fire.GetComponent<AudioSource>().Stop();
                    Fire.GetComponent<AudioSource>().volume = 1;
                    GetComponent<AudioSource>().Stop();
                }


            }

        }
    }

    


}
