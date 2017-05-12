using UnityEngine;
using System.Collections;

public class Puzzle_Button : Puzzle {

    bool switched = false;

    [SerializeField] RectTransform button;

	void Update ()
    {
        if (player.GetButtonDown("Up") && !switched)
        {
            switched = true;

            // should make animation but...
            completePuzzle(true);
        }

        if (switched)
        {
            //button.position += new Vector3(0, 2, 0);
        }
    }
}
