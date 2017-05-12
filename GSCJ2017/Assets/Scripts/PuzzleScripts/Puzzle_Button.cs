using UnityEngine;
using System.Collections;

public class Puzzle_Button : Puzzle {

    bool switched = false;

	new void Update ()
    {
        if (player.GetButtonDown("Up") && !switched)
        {
            Debug.Log("YUS");
            switched = true;

            // should make animation but...
            completePuzzle(true);
        }
    }
}
