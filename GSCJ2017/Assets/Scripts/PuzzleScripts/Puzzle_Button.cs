using UnityEngine;
using System.Collections;

public class Puzzle_Button : Puzzle {

    bool switched = false;

	void Update ()
    {
        if (player.GetButtonDown("Up") && !switched)
        {
            switched = true;

            // should make animation but...
            completePuzzle(true);
        }
    }
}
