using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour {

    public float speed = 25.0f;
    public int playerIndex;
    public bool spawned = false;

    private Player player;
    private Rigidbody rb;
    [SerializeField]
    private GameObject canvas;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerIndex);
        Debug.Log(player);
        rb = GetComponent<Rigidbody>();
        foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
            m.enabled = false;
        spawned = false;
        canvas.SetActive(false); 

    }

    void FixedUpdate()
    {
        if(player.GetButtonDown("Start"))
        {
            if (spawned)
            {
                foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
                    m.enabled = false;
                canvas.SetActive(false);
                spawned = false;
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
            if (player.GetButton("Right"))
            {
                rb.AddForce((Vector3.right * (speed)) * Time.deltaTime);
            }
            if (player.GetButton("Left"))
            {
                rb.AddForce((-Vector3.right * (speed)) * Time.deltaTime);
            }
        }
    }

    void Update()
    {

    }
}

