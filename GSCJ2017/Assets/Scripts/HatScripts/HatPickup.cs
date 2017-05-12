using UnityEngine;
using System.Collections;

public class HatPickup : InteractableObject {

    [SerializeField]
    HatManager hatMan;

    public enum HatType
    {
        Cap, Alien, Pirate
    }
    public HatType _hatType;

    int hatNum;

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

    override public void interact(int interactedPlayer)
    {
        Debug.Log("Hat");
        hatMan.addHat(interactedPlayer, hatNum);
        Destroy(gameObject);
    }
}
