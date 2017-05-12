using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour {

    [SerializeField] List<BreakableObject> jobs = new List<BreakableObject>();
    [SerializeField] List<Transform> nullJobs = new List<Transform>();

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
}
