using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BreakableObject : InteractableObject {

    [SerializeField] GameObject sparksParticle;
    [SerializeField] Image AlertImage;

    bool broken = false;
    bool inUse = false;

    public void breakObject()
    {
        broken = true;
        AlertImage.enabled = true;
        sparksParticle.SetActive(true);
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
        if (broken)
        {
            PuzzleManager.m_instance.loadPuzzle(interactedPlayer, this);
        }
    }
    override public void completedInteraction(bool outcome)
    {
        if (outcome)
        {
            fixObject();
        }
    }
}
