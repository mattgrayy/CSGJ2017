using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour {

    public float speed = 25.0f;
    public int playerIndex;
    public bool spawned = false;

    public float rightRot = -10;
    public float leftRot = 10;
    float target = 0;

    private Player player;
    private Rigidbody rb;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject spawnPoint;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerIndex);
        Debug.Log(player);
        rb = GetComponent<Rigidbody>();
        foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
            m.enabled = false;
        spawned = false;
        canvas.SetActive(false);
        transform.position = spawnPoint.transform.position;

    }

    void FixedUpdate()
    {
        
        if (player.GetButtonDown("Start"))
        {
            if (spawned)
            {
                foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                    m.enabled = false;
                canvas.SetActive(false);
                spawned = false;
                transform.position = spawnPoint.transform.position;
            }
            else
            {
                foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                    m.enabled = true;
                spawned = true;
                canvas.SetActive(true);
            }
        }
        if (spawned)
        {
            Vector3 currentRotation = transform.eulerAngles;
           // float zTarget = Mathf.Round(currentRotation.z / 18) * 180;

            currentRotation.z = Mathf.LerpAngle(currentRotation.z, target, Time.deltaTime * 4);
            transform.eulerAngles = currentRotation;

            if (player.GetButton("Right"))
            {
                rb.AddForce((Vector3.right * (speed)) * Time.deltaTime);
                target = rightRot;
            }
            if (player.GetButton("Left"))
            {
                rb.AddForce((-Vector3.right * (speed)) * Time.deltaTime);
                target = leftRot;
            }
            if(!player.GetButton("Right") && !player.GetButton("Left"))
            {
                target = 0;
            }
        }
    }
    
    void OnTriggerEnter(Collider col)
    {

    }
}

