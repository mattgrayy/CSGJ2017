using UnityEngine;
using System.Collections;

public class Puzzle_Tetris : Puzzle {




	[SerializeField] RectTransform spinner;

	void Update ()
	{

		//puzzle in here

		if (player.GetButtonDown("Right"))
		{

            spinner.transform.Rotate(new Vector3(0, 0, 45f));

		}

        if (player.GetButtonDown("Left"))
        {

            spinner.transform.Rotate(new Vector3(0, 0, -45f));

        }
        
    }
}
