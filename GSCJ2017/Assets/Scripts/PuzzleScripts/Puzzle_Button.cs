using UnityEngine;
using System.Collections;

public class Puzzle_Button : Puzzle {

    bool switched = false;

    [SerializeField] RectTransform button;

    Vector3 buttonOriginalPos;

	void Update ()
    {
        if ((player.GetButtonDown("Up") || player.GetAxis("Vertical") > 0) && !switched)
        {
            switched = true;

            if (button != null)
            {
                buttonOriginalPos = button.position;
            }
        }

        if (switched && button != null)
        {
            if (button.position.y < buttonOriginalPos.y + 30)
            {
                button.position += new Vector3(0, 4, 0);
            }
            else
            {
                completePuzzle(true, 5);
            }
        }
    }
}
