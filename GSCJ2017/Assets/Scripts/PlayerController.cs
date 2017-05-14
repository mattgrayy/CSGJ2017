using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour {

    public float speed = 25.0f;
    public int playerIndex;
    bool spawned = false;
    bool puzzled = false;

    public int score = 0;
    public int racoonsScared = 0;
    public int puzzlesSolved = 0;

    public float rightRot = -10;
    public float leftRot = 10;
    float target = 0;

    private Player player;
    private Rigidbody rb;
    //[SerializeField] private GameObject canvas;
    [SerializeField]
    private GameObject spawnPoint;

    private GameObject interaction;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerIndex);
        Debug.Log(player);
        rb = GetComponent<Rigidbody>();
        foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
            m.enabled = false;
        spawned = false;
        //canvas.SetActive(false);
        transform.position = spawnPoint.transform.position;

    }

    void FixedUpdate()
    {
        if (!puzzled)
        {
            if (player.GetButtonDown("Start"))
            {
                if (spawned)
                {
                    foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                        m.enabled = false;
                    //canvas.SetActive(false);
                    spawned = false;
                    transform.position = spawnPoint.transform.position;
                    PuzzleManager.m_instance.setPuzzleDropout(playerIndex);
                }
                else
                {
                    foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                        m.enabled = true;
                    spawned = true;
                    //canvas.SetActive(true);
                    PuzzleManager.m_instance.setPuzzleIdle(playerIndex);
                }
            }
            if (spawned)
            {
                Vector3 currentRotation = transform.eulerAngles;

                currentRotation.z = Mathf.LerpAngle(currentRotation.z, target, Time.deltaTime * 4);
                transform.eulerAngles = currentRotation;

                if (player.GetButton("Right") || (player.GetAxis("Horizontal") > 0))
                {
                    rb.AddForce((Vector3.right * (speed)) * Time.deltaTime);
                    target = rightRot;
                }
                if (player.GetButton("Left") || (player.GetAxis("Horizontal") < 0))
                {
                    rb.AddForce((-Vector3.right * (speed)) * Time.deltaTime);
                    target = leftRot;
                }
                if (!player.GetButton("Right") && !player.GetButton("Left") && player.GetAxis("Horizontal") == 0)
                {
                    target = 0;
                }
                if (player.GetButtonDown("Interact"))
                {

                    if (interaction != null)
                    {
                        interaction.GetComponent<InteractableObject>().interact(playerIndex);
                    }
                }
            }
        }
    }
    
    void Update()
    {
        if (player.GetButtonDown("B"))
        {
            Debug.Log("B");
        }
        if (player.GetButtonDown("Y"))
        {
            Debug.Log("Y");
        }
    }
    
    void OnTriggerStay(Collider col)
    {
        
        if(col.tag == "Interactable")
        {
            if (interaction != null && interaction.GetComponent<BreakableObject>() && interaction.GetComponent<BreakableObject>().getIsBroken())
            {
                
            }
            else
            {
                interaction = col.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Interactable")
        {
            interaction = null;
        }
    }

    public void isInPuzzle(bool _isTrue)
    {
        puzzled = _isTrue;
    }

    public bool getPuzzled()
    {
        return puzzled;
    }
}

