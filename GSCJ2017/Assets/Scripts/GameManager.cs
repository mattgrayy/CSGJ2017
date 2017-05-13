using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<FloorManager> floorManagers = new List<FloorManager>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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


}
