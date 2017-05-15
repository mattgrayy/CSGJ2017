using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_QuickTIme : Puzzle {


    float fillAmount = 0, dificulty = 0.1f;
    [SerializeField] Image fill;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (fillAmount > 0)
        {
            fillAmount -= Time.deltaTime * dificulty;

        }


        if(player.GetButtonDown("Interact"))
        {
            fillAmount += 0.05f;

        }

        fill.fillAmount = fillAmount;


        if (fillAmount >= 1)
        {
            completePuzzle(true, 20);
        }



	
	}
}
