using UnityEngine;
using System.Collections.Generic;

public class HatController : MonoBehaviour {

    [SerializeField] GameObject HatPosition;

    [SerializeField]
    GameObject Cap;
    [SerializeField]
    GameObject Alien;
    [SerializeField]
    GameObject Pirate;
    GameObject Hat;

    public List<GameObject> hats = new List<GameObject>();

    void Start()
    {
        hats.Clear();
    }

    public void addHat(int _hatNum)
    {
        hatSelect(_hatNum);
        if (hats.Count == 0)
        {
            Debug.Log("Add Hat");
            GameObject newHat  = Instantiate(Hat, HatPosition.transform.position, transform.rotation, transform) as GameObject;
            hats.Add(newHat);
        }
        else if (hats.Count<=3)
        {
            Vector3 spawnPos = hats[hats.Count - 1].GetComponent<HatSocket>().hatSocket.transform.position;
            GameObject newHat = Instantiate(Hat, spawnPos, transform.rotation, transform) as GameObject;
            hats.Add(newHat);
        }
    }

    void hatSelect(int _hatNum)
    {
        switch(_hatNum)
        {
            case 0: Hat = Cap;
                break;
            case 1:
                Hat = Alien;
                break;
            case 2:
                Hat = Pirate;
                break;
        }
    }
}

