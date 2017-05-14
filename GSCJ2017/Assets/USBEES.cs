﻿using UnityEngine;
using System.Collections;

public class USBEES : MonoBehaviour
{

    [SerializeField]
    GameObject Wings;
    [SerializeField] GameObject props;
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
        USB.GetComponent<BoxCollider>().enabled = false;

       
    }

    // Update is called once per frame
    void Update()
    {
        props.transform.Rotate(0, 0, 1);

        if (GoHome&& Wings.transform.position.x >= beeSpawn.transform.position.x)
        {
            USGO=false;
        }
       

        if (Random.Range(0, 2) == 0 && !USGO)
        {
            USGO = true;
        }

        if (USGO)
        {

            if (Wings.transform.position.x < window.transform.position.x && !windowB)
            {
                windowB = true;

            }
            if (Wings.transform.position.x >= window.transform.position.x && windowB)
            {
                windowB = false;

            }

            if (!GoHome)
            {
                Wings.transform.Translate(-1 * Time.deltaTime, 0, 0);
            }

            if (GoHome)
            {
                if (Wings.transform.position.x < beeSpawn.transform.position.x)
                {
                    
                    Wings.transform.Translate(1 * Time.deltaTime, 0, 0);
                }
            }

            if (Wings.transform.position.x > farLeft.transform.position.x)
            {
               
               

              

                if (windowB)
                {
                    if(TopB||BottomB)
                    {
                        Wings.transform.Translate(0, Random.Range(-3f, 3.5f) * Time.deltaTime, 0);
                    }
                    if (Wings.transform.position.y < roomtop.transform.position.y&&!TopB)
                    {
                       
                      
                    }
                    if (Wings.transform.position.y>= roomtop.transform.position.y && !TopB)
                    {
                        TopB = true;
                        BottomB = false;
                    }
                    if (TopB && !BottomB && Wings.transform.position.y > roomBottom.transform.position.y)
                    {
                       // Wings.transform.Translate(0, - Random.Range(0.5f, 3.5f) * Time.deltaTime, 0);
                        
                    }
                    if (TopB && !BottomB && Wings.transform.position.y <= roomBottom.transform.position.y)
                    {
                        TopB = false;
                        BottomB = true;
                    }




                }
            }
            else if (Wings.transform.position.x <= farLeft.transform.position.x&&!GoHome)
            {
                GoHome = true;
            }
                

            
        }
    }
}       
            
        
    
