using UnityEngine;
using System.Collections;

public class USBEES : MonoBehaviour
{

    [SerializeField]
    GameObject Wings;
    [SerializeField]
    GameObject USB;

    [SerializeField]
    Transform beeSpawn;
    [SerializeField]
    Transform window;
    [SerializeField]
    Transform roomtop;
    [SerializeField]
    Transform roomBottom;
    [SerializeField]
    Transform farLeft;

    [SerializeField]
    bool windowB;
    [SerializeField]
    bool TopB;
    [SerializeField]
    bool BottomB;
    [SerializeField]
    bool GoHome;

    [SerializeField]
    bool die;
    [SerializeField]
    bool USGO;

    // Use this for initialization
    void Start()
    {
        USB.transform.parent = Wings.transform;
        USB.GetComponent<BoxCollider>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 2) == 0)
        {
            USGO = true;
        }

        if (USGO)
        {
            if (Wings.transform.position.x > farLeft.transform.position.x)
            {
                if (Wings.transform.position.x >= window.transform.position.x&&!windowB)
                {
                    Wings.transform.Translate(-1 * Time.deltaTime, 0, 0);
                }

                if (Wings.transform.position.x <= window.transform.position.x)
                {
                    windowB = true;
                }

                if (windowB)
                {
                
                    if (Wings.transform.position.y <= roomtop.transform.position.y)
                    {
                        if (!TopB)
                        {
                            Wings.transform.Translate(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
                        }
                        f(Wings.transform.position.y == roomtop.transform.position.y)
                    {
                            TopB = true;
                            BottomB = false;
                        }
                    }

                    if (TopB && !BottomB)
                    {
                        Wings.transform.Translate(-1 * Time.deltaTime, -1 * Time.deltaTime, 0);
                    }


                    //if (Wings.transform.position.y > roomBottom.transform.position.y)
                    //{
                    //    if (!BottomB)
                    //    {
                    //        Wings.transform.Translate(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
                    //    }
                    //}

                    i

                    if (Wings.transform.position.y == roomBottom.transform.position.y)
                    {
                        BottomB = true;
                        TopB = false;
                    }

                }
            }
        }
    }
}