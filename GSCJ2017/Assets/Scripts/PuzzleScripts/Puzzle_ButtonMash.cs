using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_ButtonMash : Puzzle {

    
    int mashed = 0;
    bool sequencePlaying = true;
    bool isSpam = true;

    public Image spam = null, safe = null, save = null, delete = null;

    void Start()
    {
        mashed = 0;
        sequencePlaying = true;
    }

    void Update()
    {
        if (sequencePlaying)
        {
            //select spam or safe
            int emailType = Random.Range(0, 6);
            if (emailType == 0)
                isSpam = false;
            else if (emailType >= 1)
                isSpam = true;

            if (player.GetButtonDown("Interact"))
            {
                if (!isSpam)
                {
                    correctButton();
                }
                else if (isSpam)
                {
                    wrongButton();
                }
            }

            if(player.GetButtonDown("B"))
            {
                if (isSpam)
                {
                    correctButton();
                }
                else if (!isSpam)
                {
                    wrongButton();
                }
            }
        }
    }

    void correctButton()
    {
        mashed++;
        if (mashed == 20)
        {

            completePuzzle(true);
        }
    }

    void wrongButton()
    {

    }
}
