﻿using UnityEngine;
using System.Collections;

public class BreakableObject : InteractableObject {

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

    new void interact(int interactedPlayer)
    {
        if (broken)
        {
            // load random puzzle
        }
    }
}
