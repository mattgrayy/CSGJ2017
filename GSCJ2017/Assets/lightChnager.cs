using UnityEngine;
using System.Collections;

public class lightChnager : MonoBehaviour
{


    public  Material Red, Green, Blue, Yellow, White;

    float timer;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;


        //the time could be related to the amout of stuff that is borken
        //will need to get it rom whatever manger that is going to be made

        if (timer > 2)
        {

            int lightInt = Random.Range(0, 5);

            switch (lightInt)
            {
                case 0:
                    spriteRenderer.material = Red;
                    break;

                case 1:
                    spriteRenderer.material = Green;
                    break;

                case 2:
                    spriteRenderer.material = Blue;
                    break;

                case 3:
                    spriteRenderer.material = Yellow;
                    break;

                case 4:
                    spriteRenderer.material = White;
                    break;

            }
            timer = 0f;

        }

    }
}
