using UnityEngine;
using System.Collections;

public class BreakableObject : MonoBehaviour {

    bool broken = false;

    public void breakObject()
    {
        broken = true;
    }

    public void fixObject()
    {
        broken = true;
    }

    public bool getIsBroken()
    {
        return broken;
    }
}
