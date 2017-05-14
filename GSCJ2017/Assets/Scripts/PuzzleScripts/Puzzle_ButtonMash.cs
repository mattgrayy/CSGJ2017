using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_ButtonMash : Puzzle {

    
    int mashed = 0, attempts = 0;
    public int difficulty = 10;
    public bool sequencePlaying = true;
    bool isSpam = true;
    bool playerInputDisabled = true;

    public Image spam = null, safe = null, wrong = null;

    void Start()
    {
        mashed = 0;
        attempts = 0;
        sequencePlaying = true;
    }

    void Update()
    {
        if (sequencePlaying)
        {
            //select spam or safe
            int emailType = Random.Range(0, 6);
            if (emailType == 0)
            {
                isSpam = false;
                safe.gameObject.SetActive(true);
                spam.gameObject.SetActive(false);
            }
            else if (emailType >= 1)
            {
                isSpam = true;
                safe.gameObject.SetActive(false);
                spam.gameObject.SetActive(true);
            }

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
        if (mashed == difficulty)
        {
            completePuzzle(true);
        }
    }

    void wrongButton()
    {
        mashed = 0;
        attempts++;
        if (attempts >= 4)
            completePuzzle(false);
        else
        {
            safe.gameObject.SetActive(false);
            spam.gameObject.SetActive(false);
            wrong.gameObject.SetActive(true);
        }
    }
}
