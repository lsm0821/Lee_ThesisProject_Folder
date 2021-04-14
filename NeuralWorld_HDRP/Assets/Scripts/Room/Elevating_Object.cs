using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevating_Object : MonoBehaviour
{
    public float speed = 2;

    Vector3 initialLocation;

    // Start is called before the first frame update
    void Start()
    {
        initialLocation = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, speed / 1000, 0));
        //transform.position += new Vector3(0, speed / 100, 0);
    }

    public void OnMessageArrived(int message)
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, speed / 150, 0));
    }
}
