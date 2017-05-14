using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<FloorManager> floorManagers = new List<FloorManager>();

    [SerializeField] int globalScore = 0;
    [SerializeField] float globalStress = 0;
    bool stressOut = false;

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
            floor.DeactivateSprinklers();
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
