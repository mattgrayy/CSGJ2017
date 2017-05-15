using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Puzzle_Slider : Puzzle
{



    [SerializeField]
    public Texture2D source;
    [SerializeField]
    GameObject spritesRoot;

    [SerializeField]
    List<int> isopen =new List<int>();

    [SerializeField]
    List<GameObject> objectmoving;
    // Use this for initialization
    void Start()
    {
        isopen.Add(0);
        isopen.Add(1);
        isopen.Add(1);
        isopen.Add(1);
        int o = 0;

        for (float i = 0; i < 2; i++)
        {
            for (float j = 0; j < 2; j++)
            {
                o++;
                    Sprite newSprite = Sprite.Create(source, new Rect(i * 50, j * 50, 50, 50), new Vector2(0f, 0f));
                    GameObject n = new GameObject();
                Puzzle_Slider_Segment seg = n.AddComponent<Puzzle_Slider_Segment>();
                    SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                //    BoxCollider2D BC = n.AddComponent<BoxCollider2D>();
                //BC.size = n.GetComponent<SpriteRenderer>().bounds.size;
            
                    sr.sprite = newSprite;
                    n.transform.position = new Vector3(i/1.9f , j/1.9f , 0);
                    n.transform.parent = spritesRoot.gameObject.transform.parent;
                  objectmoving.Add(n);
                    n.name = "slider" + " " + o;

            }
       }
        if (gameObject.transform.GetChild(4).gameObject.name == "slider 4")
        {
            Destroy(gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>());
            objectmoving.Remove(objectmoving[3]);
        }
       


    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int o = 1;
            if (isopen[o + 1] == 0 || isopen[o - 1] == 0)
            {
                if (isopen[o + 1] == 0)
                {
                    objectmoving[o].transform.Translate(0.5f, 0, 0);
                }
                else if ( isopen[o - 1] == 0)
                {
                    objectmoving[o].transform.Translate(0,0.5f, 0);
                }
            }
        }
        if (player != null)
        {
            if (player.GetButtonDown("Up"))
            {
                isopen[3] = 5;
            }
         

            if (player.GetButtonDown("Down"))

            {

            }
        }
    }

}