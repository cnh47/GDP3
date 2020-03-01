using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float t;
    float t2;
    public Vector3 startPosition;
    public Vector3 target;
    public Vector3 target2;
    public float timeToReachTarget;
    void Start()
    {
       this.transform.position = new Vector3(11.03f, 9.71f, 7.01f);

    }
    void Update()
    {
        

        if (Input.GetButton("C"))
        {
            MovePlayerSS();

        }

        if (Input.GetButton("R"))
        {
            RunDive();
            
        }

    }


    public void RunDive()
    {
        t2 += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(target, target2, t2);
        if (transform.position == target2)
        {
            GetComponent<Rigidbody>().useGravity = true;

        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void MovePlayerSS()
    {
        
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
        if (transform.position == target)
        {
            GetComponent<Rigidbody>().useGravity = true;

        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }


    /*
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }
    */
}
