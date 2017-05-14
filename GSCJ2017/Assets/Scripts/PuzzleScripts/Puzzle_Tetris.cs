using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Puzzle_Tetris : Puzzle {

    class SpinnerPosition
    {
        public bool complete;

        public int numberOfHitsLeft, shapeNeeded;
        public Image greenCover = null;
        
    }

    public Sprite Circle = null, Square = null, Triangle = null, Heart = null;
    public Image squareGreen, triangleGreen, heartGreen, circlegreen;

    [SerializeField] int spinnerPosition  = 1;
    
	[SerializeField] RectTransform spinner = null;
    [SerializeField] Image nextShape = null;


    List<SpinnerPosition> Positions = new List<SpinnerPosition>();
    public  List<int> shapes = new List<int>();
    List<int> TempList = new List<int>();

    public int dificulty = 1;

    float targetRotation;



    /*  What the ints represent
        1 = Circle
        2 = Square
        3 = Triangle
        4 = Heart
    */




    void Start()
    {

        targetRotation = spinner.transform.eulerAngles.z -45;

        //set up the first shapes
      for (int i = 1; i < 5; i++)
        {
            SpinnerPosition pos = new SpinnerPosition();
            pos.shapeNeeded = i;
            pos.numberOfHitsLeft = dificulty;

            Positions.Add(pos);
            TempList.Add(10);
        }


        Positions[0].greenCover = circlegreen;
        Positions[1].greenCover = squareGreen;
        Positions[2].greenCover = triangleGreen;
        Positions[3].greenCover = heartGreen;


        foreach (SpinnerPosition spinPos in Positions)
        {
            for (int i= 0; i< spinPos.numberOfHitsLeft; i++)
            {
                shapes.Add(spinPos.shapeNeeded);
            }
        }

       
       foreach (int shape in shapes)
        {
            int radom = Random.Range(0, shapes.Count - 1);
            Debug.Log("RANDOM INT: " + radom);
            TempList.Insert(radom, shape);
            Debug.Log("inserted");
        }

       for (int i = 0; i < 4; i++)
        {
            TempList.Remove(10);
        }
       
        shapes = TempList;

    }





	void Update ()
	{

       switch(shapes[0])
        {
            case 1:
                nextShape.sprite = Circle;
                break;

            case 2:
                nextShape.sprite = Square;
                break;

            case 3:
                nextShape.sprite = Triangle;
                break;

            case 4:
                nextShape.sprite = Heart;
                break;
        }




		//puzzle in here

        
		if (player.GetButtonDown("Right"))
		{
            
            targetRotation += 90;

            spinnerPosition++;

            if (spinnerPosition > 4)
            {
                spinnerPosition = 1;
            }
        }

        if (player.GetButtonDown("Left"))
        {
            
            targetRotation -= 90;

            
            spinnerPosition--;

            if (spinnerPosition <= 0)
            {
                spinnerPosition = 4;
            }

        }



        Vector3 currentRotation = spinner.transform.eulerAngles;
        
        currentRotation.z = Mathf.LerpAngle(currentRotation.z, targetRotation, Time.deltaTime * 7f);
        spinner.transform.eulerAngles = currentRotation;

        
        if (player.GetButtonDown("Interact"))
        {
            
            if (!Positions[spinnerPosition - 1].complete)
            {
                //drop a shape from the list

                //if it matches the position of the spinner then 
                if (shapes[0] == spinnerPosition)
                {
                    Debug.Log("match");
                    Positions[spinnerPosition - 1].numberOfHitsLeft--;

                    if (Positions[spinnerPosition - 1].numberOfHitsLeft == 0)
                    {
                        Debug.Log("complete");
                        Positions[spinnerPosition - 1].complete = true;
                        Positions[spinnerPosition - 1].greenCover.gameObject.SetActive(true);
                    }


                    //remove the shape from the list
                    shapes.RemoveAt(0);
                    
                }
                else
                {
                    Debug.Log("not a match");

                    int lastPos = shapes.Count - 1;
                    //the shape is not a match so move it to the back of the list
                    int shape = shapes[0];

                    shapes.RemoveAt(0);
                    shapes.Insert(lastPos, shape);
                    
                }
            }

        }






        //check if the puzzel is complete
        if (shapes.Count <= 0)
        {

            completePuzzle(true, 0);

        }

        
    }


   

}
