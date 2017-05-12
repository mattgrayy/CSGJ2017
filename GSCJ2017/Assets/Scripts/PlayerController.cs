using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour {

    public float speed = 25.0f;
    public int playerIndex;

    private Player player;
    private Rigidbody rb;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerIndex);
        Debug.Log(player);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (player.GetButton("Right"))
        {
            Debug.Log("blep");
            rb.AddForce((Vector3.right * (speed))* Time.deltaTime);
        }
    }

    void Update()
    {

    }
}

