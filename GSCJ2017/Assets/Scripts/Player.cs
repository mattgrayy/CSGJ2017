using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 5.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * (speed));
    }

    void Update()
    {

    }
}

