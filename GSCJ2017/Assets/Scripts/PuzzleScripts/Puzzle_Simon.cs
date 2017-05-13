using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Puzzle_Simon : Puzzle
{

    public Image up = null, down = null, left = null, right = null, upLight = null, downLight = null, rightLight = null, leftLight = null;


    //sequence is done on the D-pad
    [SerializeField] List<int> sequence = new List<int>();
    bool sequencePlaying = true;
    int sequenceIndex = 0;

    public int dificulty = 1;


    void Start()
    {

        for (int i = 0; i < dificulty * 4; i++)
        {
            //cerate a sequence
            int direction = Random.Range(0, 3);

            sequence.Add(direction);

        }

    }






    void Update()
    {

        if (sequencePlaying)
        {

            switch (sequence[sequenceIndex])
            {

                case 0:

                    Debug.Log("UP ");

                    upLight.gameObject.SetActive(true);
                    System.Threading.Thread.Sleep(1);
                    upLight.gameObject.SetActive(false);
                    break;

                case 1:

                    Debug.Log("DOWN ");

                    downLight.gameObject.SetActive(true);
                    System.Threading.Thread.Sleep(1);
                    downLight.gameObject.SetActive(false);
                    break;

                case 2:

                    Debug.Log("RIGHT " + rightLight.gameObject.active);

                    rightLight.gameObject.SetActive(true);
                    System.Threading.Thread.Sleep(1);
                    rightLight.gameObject.SetActive(false);
                    break;

                case 3:

                    Debug.Log("LEFT ");

                    leftLight.gameObject.SetActive(true);
                    System.Threading.Thread.Sleep(1);
                    leftLight.gameObject.SetActive(false);
                    break;
            }


        }



    }

    //when the sequence is over get the player to input it

    //ticking of their input as they go

    //if they get it wrong say they didnt do it right

    //then play it again for them



}


