using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class USBEE_spawner : MonoBehaviour {

    [SerializeField]
    List<Transform> Spawns = new List<Transform>();
  
    [SerializeField]
    GameObject Bee;

    Transform spawnpoint;

    [SerializeField]
    int spawnnum;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void respawn()
    {
        spawnnum = Random.Range(0, 2);
        if(spawnnum==2)
        {
            spawnnum = 1;
        }
        Debug.Log(spawnnum);
        Instantiate(Bee,Spawns[spawnnum].position, Quaternion.identity);

    }
}
