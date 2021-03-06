﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreakableObject : InteractableObject {

    [SerializeField] GameObject sparksParticle;
    [SerializeField] Image AlertImage;

    bool broken = false;
    bool inUse = false;
    bool inFixed = false;

    public void breakObject()
    {
        if (!broken)
        {
            broken = true;
            AlertImage.enabled = true;
            sparksParticle.SetActive(true);
            GameManager.m_instance.addToGlobalStress(2);
        }
    }

    public void fixObject()
    {
        broken = false;
        AlertImage.enabled = false;
        sparksParticle.SetActive(false);
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

    override public void interact(int interactedPlayer)
    {
        if (broken && !inFixed)
        {
            PuzzleManager.m_instance.loadPuzzle(interactedPlayer, this);
            inFixed = true;
        }
    }
    override public void completedInteraction(bool outcome)
    {
        if (outcome)
        {
            fixObject();
            
        }
        inFixed = false;
    }
}
