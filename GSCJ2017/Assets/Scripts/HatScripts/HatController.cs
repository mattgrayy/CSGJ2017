using UnityEngine;
using System.Collections.Generic;

public class HatController : MonoBehaviour {

    [SerializeField] GameObject HatPosition;

    [SerializeField]
    Transform Cap;
    [SerializeField]
    Transform Alien;
    [SerializeField]
    Transform Pirate;
    Transform Hat;

    public List<Transform> hats = new List<Transform>();

    public void addHat(int _hatNum)
    {
        hatSelect(_hatNum);
        if (hats.Count == 0)
        {
            Debug.Log("Add Hat");
            Transform newHat  = Instantiate(Hat, HatPosition.transform.position, transform.rotation, transform) as Transform;
            hats.Add(newHat);
        }
        else if (hats.Count<=5)
        {

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

