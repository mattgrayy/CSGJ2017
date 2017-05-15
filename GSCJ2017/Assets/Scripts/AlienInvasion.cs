using UnityEngine;
using System.Collections.Generic;

public class AlienInvasion : MonoBehaviour {

    public GameObject explosion = null, roofPiece = null, door1 = null, door2 = null;
    public Transform target = null;
    bool entranceComplete = false, doorsOpen = false;
    public float rotTarget1 = 140f, rotTarget2 = -42;
    

    Vector3 currentRotation1 = new Vector3(38, -90, 90), currentRotation2 = new Vector3(38, -90, 90);
    public List<BlockMove> aliens = new List<BlockMove>();

    void Awake()
    {

        foreach (BlockMove alien in aliens)
        {
            alien.floorManager = GameManager.m_instance.floorManagers[0];
            alien.invaderControlerI = this;
        }


    }



    // Update is called once per frame
    void Update()
    {


        // move UFO
        //1 , 12.4, -1.2        
        if (transform.position.y > 12 && !entranceComplete)
        {
            transform.Translate(new Vector3(15, -15, 0) * Time.deltaTime);

        }
        else
        {

            entranceComplete = true;

           


        }

        if (transform.position.y < 13 && !entranceComplete)
        {

            Instantiate(explosion, target.transform.position, Quaternion.identity);
            roofPiece.SetActive(false);
        }


        if (entranceComplete && !doorsOpen)
        {
            //open doors



            currentRotation1.x = Mathf.LerpAngle(currentRotation1.x, rotTarget1, Time.deltaTime * 4);
            door1.transform.eulerAngles = currentRotation1;


            currentRotation2.x = Mathf.LerpAngle(currentRotation2.x, rotTarget2, Time.deltaTime * 4);
            door2.transform.eulerAngles = currentRotation2;



            if (door1.transform.eulerAngles.x >= 130)
            {
                //doors have opened
                doorsOpen = true;

            }


        }


        if (entranceComplete && doorsOpen)
        {

            //spawn the aliens



        }
    }


    public void recalInvaders()
    {


    }


}
