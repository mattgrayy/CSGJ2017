using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle_ButtonMash : Puzzle {

    SpriteRenderer sr;

    int mashed = 0, attempts = 0, score = 25;
    public int difficulty = 6;
    public bool sequencePlaying = true;
    bool isSpam = true, choice = true;
    bool playerInputDisabled = true;
    float timer = 0;

    int inbox ;

    public Image spam = null, safe = null, wrong = null, correct = null;
    public Text number = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mashed = 0;
        attempts = 0;
        sequencePlaying = true;
        number.text = mashed.ToString();
        inbox = difficulty;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (sequencePlaying && timer < 0)
        {
            if (choice)
            {
                //select spam or safe
                int emailType = Random.Range(0, 3);
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
                choice = false;
            }
            correct.gameObject.SetActive(false);
            wrong.gameObject.SetActive(false);
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
        inbox--;
        number.text = inbox.ToString();
        correct.gameObject.SetActive(true);
        timer = 0.3f;
        //right.gameObject.SetActive(true);
        if (mashed == difficulty)
        {
            completePuzzle(true, score);
        }
        
    }

    void wrongButton()
    {
        attempts++;
        score -= 5;
        if (attempts >= 4)
            completePuzzle(true, 0);
        else
        {
            wrong.gameObject.SetActive(true);
            timer = 0.3f;
        }
    }
}
