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
        rb = GetComponent<Rigidbody>();

        transform.position = spawnPoint.transform.position + new Vector3(0,0,playerIndex*0.1f);
    }

    void FixedUpdate()
    {
        if (!puzzled)
        {
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
            }
        }
    }
    
    void Update()
    {
        if (!puzzled)
        {
            if (player.GetButtonDown("Start"))
            {
                if (spawned)
                {
                    foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                        m.enabled = false;
                    spawned = false;
                    rb.velocity = Vector3.zero;
                    transform.position = spawnPoint.transform.position + new Vector3(0, 0, playerIndex * 0.1f);
                    PuzzleManager.m_instance.setPuzzleDropout(playerIndex);
                }
                else
                {
                    foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                        m.enabled = true;
                    spawned = true;
                    PuzzleManager.m_instance.setPuzzleIdle(playerIndex);
                }
            }
            if (spawned)
            {
                if (player.GetButtonDown("Interact"))
                {

                    if (interaction != null)
                    {
                        interaction.GetComponent<InteractableObject>().interact(playerIndex);
                        rb.velocity = Vector3.zero;
                    }
                }
            }
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

