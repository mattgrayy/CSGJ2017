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


    private void Awake()
    {
        myTransform = transform;
        ridg = GetComponent<Rigidbody2D>();
    }



    // Use this for initialization
    void Start () {

       ridg.velocity += Vector2.down * 1;
       ridg.velocity += Vector2.left * 1;


    }
	
	
	void Update () {

        timer -= Time.deltaTime;
        timerText.text = timer.ToString();

        if (timer <= 0f)
        {
            controler.WinPuzzle();
        }	
	}


    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Slot")
        {
            controler.LosePuzzle();
        }
    }

}
