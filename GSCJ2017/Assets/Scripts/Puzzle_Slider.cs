using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Puzzle_Slider : MonoBehaviour
{

    [SerializeField]
    Image slider;
    [SerializeField]
    Image slider3;
    [SerializeField]
    Image slider2;

    [SerializeField]
    public Texture2D source;
    [SerializeField]
    GameObject spritesRoot;
    // Use this for initialization
    void Start()
    {



        for (float i = 0; i < 2; i++)
        {
            for (float j = 0; j < 2; j++)
            {
               
                    Sprite newSprite = Sprite.Create(source, new Rect(i * 50, j * 50, 50, 50), new Vector2(0.1f, 0.1f));
                    GameObject n = new GameObject();
                    
                    SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                    sr.sprite = newSprite;
                    n.transform.position = new Vector3(i + 1, j + 1, 0);
                    n.transform.parent = spritesRoot.transform;

             
            }
    }
    
    }


    // Update is called once per frame
    void Update()
    {

    }

}