using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_ButtonMash : Puzzle {

    SpriteRenderer sr;

    int mashed = 0, attempts = 0, score = 25;
    public int difficulty = 10;
    public bool sequencePlaying = true;
    bool isSpam = true, choice = true;
    bool playerInputDisabled = true;

    public Image spam = null, safe = null, wrong = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mashed = 0;
        attempts = 0;
        sequencePlaying = true;
    }

    void Update()
    {
        if (sequencePlaying)
        {
            if (choice)
            {
                //select spam or safe
                int emailType = Random.Range(0, 6);
                if (emailType == 0)
                {
                    isSpam = false;
                    safe.gameObject.SetActive(true);
                    spam.gameObject.SetActive(false);
                    wrong.gameObject.SetActive(false);
                }
                else if (emailType >= 1)
                {
                    isSpam = true;
                    safe.gameObject.SetActive(false);
                    spam.gameObject.SetActive(true);
                    wrong.gameObject.SetActive(false);
                }
                choice = false;
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
                choice = true;
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
                choice = true;
            }
        }
    }

    void correctButton()
    {
        mashed++;
        if (mashed == difficulty)
        {
            completePuzzle(true, score);
        }
        
    }

    void wrongButton()
    {
        mashed = 0;
        attempts++;
        score -= 5;
        if (attempts >= 4)
            completePuzzle(true, 0);
        else
        {
            safe.gameObject.SetActive(false);
            spam.gameObject.SetActive(false);
            wrong.gameObject.SetActive(true);
        }
    }
}
