using UnityEngine;
using System.Collections.Generic;

public class HatController : MonoBehaviour {

    [SerializeField] GameObject HatPosition;

    [SerializeField]
    GameObject Cap;
    GameObject Hat;

    public List<Transform> hats = new List<Transform>();

    public void addHat(int _hatNum)
    {
        if (hats.Count == 0)
        {
            hatSelect(_hatNum);
            Instantiate(Hat, HatPosition.transform.position, transform.rotation, transform);
        }
    }

    void hatSelect(int _hatNum)
    {
        switch(_hatNum)
        {
            case 0: Hat = Cap;
                break;
        }
    }
}

