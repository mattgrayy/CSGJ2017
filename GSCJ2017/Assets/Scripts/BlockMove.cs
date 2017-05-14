using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockMove : MonoBehaviour {

    [SerializeField] Transform leftCorner;
    [SerializeField] Transform rightCorner;

    [SerializeField] Transform leftNext;
    [SerializeField] Transform rightNext;

    bool rotating = false;
    Transform rotatePoint = null;

    [SerializeField]float rotatedDegrees = 0;
    [SerializeField]float rotateModifier = 1f;

    [SerializeField] Transform targetObject;
    Transform previousTarget;

    [SerializeField] Sprite faceHappy = null, faceNormal = null, faceWorried = null, faceUSB = null;
    [SerializeField] Image faceImage;
    
    public AudioSource soundTip, SoundPush;

    // variables for breaking objects:

    float newTaskTimer = 0;
    [SerializeField] FloorManager floorManager;

    [SerializeField] Transform tail;
    Vector3 tailRot;

    [SerializeField] bool isRacoon = false;
    [SerializeField] Transform racoonSpawn;
    [SerializeField] Transform usbPrefab;
    public bool isRacooning = false;

    bool hasUSB = false;

    void Start()
    {
        if (tail != null)
        {
            tailRot = tail.eulerAngles;
        }
    }

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
                changeFace();
                resetRotPoints();
                rotating = false;
            }
        }
        else
        {
            if (targetObject != null)
            {
                if (Vector3.Distance(transform.position, new Vector3(targetObject.position.x, transform.position.y, transform.position.z)) > 1.2f)
                {
                    if (targetObject.position.x > transform.position.x)
                    {
                        rotateMe(transform.position - Vector3.right);
                    }
                    else
                    {
                        rotateMe(transform.position + Vector3.right);
                    }
                }
                else
                {
                    previousTarget = targetObject;
                    targetObject = null;
                    // random value should be relative to game time or something
                    if (hasUSB || Random.Range(0, 8) == 0)
                    {
                        if (previousTarget.GetComponent<BreakableObject>())
                        {
                            previousTarget.GetComponent<BreakableObject>().breakObject();
                            hasUSB = false;
                            //Change face from usb face
                            if (faceImage != null && faceWorried != null && faceHappy != null && faceNormal != null)
                            {
                                faceImage.sprite = faceWorried;
                            }
                        }
                    }
                }
            }
            else
            {
                lookForNewJob();
            }
        }

        if (tail != null)
        {
            // fix rotation of tail
            Vector3 currentRotation = tail.eulerAngles;

            currentRotation.x = Mathf.LerpAngle(currentRotation.x, tailRot.x, Time.deltaTime * 10);
            currentRotation.y = Mathf.LerpAngle(currentRotation.y, tailRot.y, Time.deltaTime * 10);
            currentRotation.z = Mathf.LerpAngle(currentRotation.z, tailRot.z, Time.deltaTime * 10);
            tail.eulerAngles = currentRotation;
        }
    }

    void lookForNewJob()
    {
        if (newTaskTimer > 0)
        {
            newTaskTimer -= Time.deltaTime;
        }
        else
        {
            if (floorManager != null)
            {
                newTaskTimer = 2;

                // a lower chance to racoon
                if (isRacoon && !isRacooning)
                {
                    if (Random.Range(0, 5) > 0)
                    {
                        return;
                    }
                    else
                    {
                        isRacooning = true;
                        targetObject = floorManager.requestJob();

                        if (previousTarget != null && previousTarget.GetComponent<BreakableObject>())
                        {
                            previousTarget.GetComponent<BreakableObject>().setIsInUse(false);
                        }
                        return;
                    }
                }

                // random value should be relative to game time or something
                if (Random.Range(0,3) == 0)
                {
                    targetObject = floorManager.requestJob();
                    if (previousTarget != null && previousTarget.GetComponent<BreakableObject>())
                    {
                        previousTarget.GetComponent<BreakableObject>().setIsInUse(false);
                    }
                }
                else
                {
                    if (isRacoon && isRacooning && Random.Range(0, 3) == 0)
                    {
                        stopRacooning();
                    }
                }
            }
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

    public void stopRacooning()
    {
        if (Random.Range(0,3) == 0)
        {
            Instantiate(usbPrefab, transform.position, usbPrefab.rotation);
        }

        isRacooning = false;
        targetObject = racoonSpawn;
    }

    void changeFace()
    {
        if (faceImage!= null && faceWorried != null && faceHappy != null && faceNormal != null && faceImage.sprite != faceUSB)
        {
            int faceRand = Random.Range(0, 15);
            if (faceRand == 0)
            {
                faceImage.sprite = faceWorried;
            }
            else if (faceRand == 1)
            {
                faceImage.sprite = faceHappy;
            }
            else
            {
                faceImage.sprite = faceNormal;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Interactable" && col.GetComponent<USB_Pickup>())
        {
            if (faceImage != null && faceUSB != null)
            {
                faceImage.sprite = faceUSB;
            }
            hasUSB = true;
            // change screen to usb
            Destroy(col.gameObject);
        }
    }
}
