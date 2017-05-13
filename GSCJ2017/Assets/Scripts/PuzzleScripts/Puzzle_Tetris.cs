using UnityEngine;
using System.Collections.Generic;

public class Puzzle_Tetris : Puzzle {

    class SpinnerPosition
    {
        public bool complete;

        public int numberOfHitsLeft, shapeNeeded;

        
    }



    [SerializeField] int spinnerPosition  = 1;
    
	[SerializeField] RectTransform spinner = null;


    List<SpinnerPosition> Positions = new List<SpinnerPosition>();
    public  List<int> shapes = new List<int>();
    public List<int> TempList = new List<int>();

    public int dificulty = 1;


    void Start()
    {

        //set up the first shapes
      for (int i = 1; i < 5; i++)
        {

            SpinnerPosition pos = new SpinnerPosition();
            pos.shapeNeeded = i;
            pos.numberOfHitsLeft = dificulty;

            Positions.Add(pos);

        }

       foreach (SpinnerPosition spinPos in Positions)
        {
            for (int i= 0; i< spinPos.numberOfHitsLeft; i++)
            {

                shapes.Add(spinPos.shapeNeeded);
                
            }
            
        }

       

       foreach (int shape in shapes)
        {

            TempList.Insert(Random.Range(0, shapes.Count), shape);
        }


       foreach (int index in TempList)
        {
            
        }


    }


	void Update ()
	{

		//puzzle in here

		if (player.GetButtonDown("Right"))
		{

            spinner.transform.Rotate(new Vector3(0, 0, 45f));
            
		}

        if (player.GetButtonDown("Left"))
        {

            spinner.transform.Rotate(new Vector3(0, 0, -45f));

        }


        if (player.GetButton("Interact"))
        {

            //drop a shape from the list
            
            //if it matches the position of the spinner then 

        }




        
    }


   

}
