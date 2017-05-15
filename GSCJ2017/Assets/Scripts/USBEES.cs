using UnityEngine;
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

    [SerializeField]
    float bTimer;

    bool bTset = false;

    float movedelay;

    [SerializeField]
    GameObject beemanager;

    int spawnnum;

    // Use this for initialization
    void Start()
    {
       
        USB.transform.parent = Wings.transform;
        USB.GetComponent<BoxCollider>().enabled = false;
        USB.GetComponent<Rigidbody>().isKinematic = true;

        movedelay = Random.Range(10, 50);

       

    }

    // Update is called once per frame
    void Update()
    {
        if(props !=null&&Wings !=null &&USB!=null)
        { 
            props.transform.Rotate(0, 0, 5);

            if (die)
            {
               

                BoxCollider[] BOXES= USB.GetComponents<BoxCollider>();
                foreach(BoxCollider Box in BOXES)
                {
                    Box.enabled = true;
                }

               

                USB.transform.parent = null;
                USB.GetComponent<Rigidbody>().isKinematic = false;
                beemanager.GetComponent<USBEE_spawner>().respawn();
                Debug.Log("REspawn");
                Destroy(gameObject);
               
            }

            if (GoHome&& Wings.transform.position.x >= beeSpawn.transform.position.x)
        {
            USGO=false;
        }


        if (Wings.transform.position.x <= farLeft.transform.position.x && !GoHome)
        {
            GoHome = true;
                USB.transform.Rotate(0, 180, 0);
            }

        if (Random.Range(0, 2) == 0 && !USGO)
        {
            USGO = true;
               
            }

            if (USGO)
            {

                movedelay -= Time.deltaTime;

                if(movedelay<0)
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

                            if (!bTset)
                            {
                                bTimer = Random.Range(5, 30);
                                bTset = true;
                            }



                            ////bouncy movement when in the building.
                            if (Wings.transform.position.y < roomtop.transform.position.y && !TopB)
                            {
                                Wings.transform.Translate(0, Random.Range(-1f, 2.5f) * Time.deltaTime, 0);


                            }
                            if (Wings.transform.position.y >= roomtop.transform.position.y && !TopB)
                            {
                                TopB = true;
                                BottomB = false;
                            }
                            if (TopB && !BottomB && Wings.transform.position.y > roomBottom.transform.position.y)
                            {
                                Wings.transform.Translate(0, -Random.Range(0.5f, 2.5f) * Time.deltaTime, 0);

                            }
                            if (TopB && !BottomB && Wings.transform.position.y <= roomBottom.transform.position.y)
                            {
                                TopB = false;
                                BottomB = true;
                            }


                            if (bTset)
                            {
                                bTimer -= Time.deltaTime;

                            }
                            if (bTimer < 0)
                            {
                                die = true;
                            }
                        }
                    }

                 
                }


            }
            
        }

       
    }
}       
            
        
    
