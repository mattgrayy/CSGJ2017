using UnityEngine;
using System.Collections;

public class Puzzle_ButtonMash : Puzzle {

    bool switched = false;
    int mashed = 0;

    [SerializeField]
    RectTransform button;

    void Update()
    {
        if (player.GetButtonDown("Interact") && !switched)
        {
            mashed++;
            if(mashed == 20)
            {
                switched = true;
                completePuzzle(true);
            }

            // should make animation but...

        }
    }
}
