using UnityEngine;
using System.Collections.Generic;

public class FloorManager : MonoBehaviour {

    [SerializeField] List<BreakableObject> jobs = new List<BreakableObject>();
    [SerializeField] List<Transform> nullJobs = new List<Transform>();

    public Transform requestJob()
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            if (!jobs[i].getIsBroken() && !jobs[i].getIsInUse())
            {
                Debug.Log("hu");
                jobs[i].setIsInUse(true);
                return jobs[i].transform;
            }
        }

        // only null jobs left

        int randIndex = Random.Range(0, nullJobs.Count);

        return nullJobs[randIndex];
    }
}
