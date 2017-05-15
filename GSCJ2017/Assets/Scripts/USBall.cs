using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class USBall : MonoBehaviour {

    [SerializeField] protected Rigidbody2D ridg;
    private Transform myTransform = null;
     [SerializeField] protected float projectileSpeed = 5.0f;
    private float timer = 10f;

    public Puzzle_BreakOut controler;
    public Text timerText;
    public bool play = false;


    private void Awake()
    {
        myTransform = transform;
        ridg = GetComponent<Rigidbody2D>();
        ridg.isKinematic = true;
        controler.ball = this;

    }


	
	void Update () {

        if (play)
        {    
                   
            timer -= Time.deltaTime;
            timerText.text = timer.ToString();

            if (timer <= 0f)
            {
                controler.WinPuzzle();
            }
        }	
	}


    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Slot")
        {
            controler.LosePuzzle();
        }
    }


    public void StartGame()
    {
        play = true;
        ridg.isKinematic = false;
        ridg.velocity += Vector2.down * 1;
        ridg.velocity += Vector2.left * 1;


    }





}
