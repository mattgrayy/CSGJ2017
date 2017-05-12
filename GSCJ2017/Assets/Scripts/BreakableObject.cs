using UnityEngine;
using System.Collections;

public class BreakableObject : MonoBehaviour {

    bool broken = false;
    bool inUse = false;

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

    public bool getIsInUse()
    {
        return inUse;
    }
    public void setIsInUse(bool usingBool)
    {
        inUse = usingBool;
    }
}
