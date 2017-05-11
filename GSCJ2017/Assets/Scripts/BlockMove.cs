using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour {

    [SerializeField] Transform leftCorner;
    [SerializeField] Transform rightCorner;

    [SerializeField] Transform leftNext;
    [SerializeField] Transform rightNext;

    public bool rotating = false;
    [SerializeField]
    Transform rotatePoint = null;

    [SerializeField]float rotatedDegrees = 0;
    [SerializeField]float rotateModifier = 1f;

    public AudioSource soundTip, SoundPush;

    // Update is called once per frame
    void Update ()
    {
        if (rotating)
        {
            if (rotatePoint == leftCorner)
            {
                float ammount = (rotateModifier + (5*rotatedDegrees)) * Time.deltaTime;

                if (rotatedDegrees + ammount > 90)
                {
                    float tempDegree = rotatedDegrees + ammount;
                    tempDegree = Mathf.Clamp(tempDegree, 0, 90);
                    ammount = tempDegree - rotatedDegrees;
                }

                transform.RotateAround(rotatePoint.position, Vector3.forward, ammount);
                rotatedDegrees += ammount;
            }
            else
            {
                float ammount = (rotateModifier + (5*rotatedDegrees)) * Time.deltaTime;

                if (rotatedDegrees + ammount > 90)
                {
                    float tempDegree = rotatedDegrees + ammount;
                    tempDegree = Mathf.Clamp(tempDegree, 0, 90);
                    ammount = tempDegree - rotatedDegrees;
                }

                transform.RotateAround(rotatePoint.position, Vector3.forward, -ammount);
                rotatedDegrees += ammount;
            }

            if (rotatedDegrees >= 90)
            {
                soundTip.Play();
                //CS.ShakeCamera(0.1f, 0.1f);
                resetRotPoints();
                rotating = false;
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform == transform)
            {
                rotateMe(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            nudgeLeft();
        }
    }

    public void rotateMe(Vector2 contactPoint)
    {
        if (!rotating)
        {
            
            float distLeft = Vector2.Distance(contactPoint, leftCorner.position);
            float distRight = Vector2.Distance(contactPoint, rightCorner.position);

            if (distLeft > distRight)
            {
                rotatePoint = leftCorner;
                //lvlMan.AddScore(10, 2);
            }
            else
            {
                rotatePoint = rightCorner;
                //lvlMan.AddScore(10, 1);
            }
            rotatedDegrees = 0;
            rotating = true;
        }
    }

    void resetRotPoints()
    {
        if (rotatePoint == leftCorner)
        {
            Vector2 prevRightPos = rightCorner.position;
            rightCorner.position = leftCorner.position;
            leftCorner.position = leftNext.position;
            leftNext.position = rightNext.position;
            rightNext.position = prevRightPos;
        }
        else
        {
            Vector2 prevLeftPos = leftCorner.position;
            leftCorner.position = rightCorner.position;
            rightCorner.position = rightNext.position;
            rightNext.position = leftNext.position;
            leftNext.position = prevLeftPos;
        }
    }

    public void nudgeLeft()
    {
        if (!rotating)
        {
            SoundPush.Play();
            transform.position += -Vector3.right * 0.01f;
        }
    }

    public void nudgeRight()
    {
        if (!rotating)
        {
            SoundPush.Play();
            transform.position += Vector3.right * 0.01f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Explosion")
        {
            rotateMe(other.transform.position);
        }
    }
}
