﻿using UnityEngine;
using System.Collections;

public class HatPickup : InteractableObject {

    [SerializeField]
    HatManager hatMan;

    public enum HatType
    {
        Cap, Alien, Pirate
    }
    public HatType _hatType;

    public int hatNum;

	void Start ()
    {
	switch (_hatType)
        {
            case HatType.Cap:
                hatNum = 0;
                break;
            case HatType.Alien:
                hatNum = 1;
                break;
            case HatType.Pirate:
                hatNum = 2;
                break;
        }
	}

    new void interact(int interactedPlayer)
    {
        hatMan.addHat(interactedPlayer, hatNum);
        Destroy(gameObject);
    }
}