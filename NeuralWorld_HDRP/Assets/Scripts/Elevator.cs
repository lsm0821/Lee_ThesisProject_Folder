using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public float speed = 2;
    public float meditationData;
    public bool detect;

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
        if(detect == true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, meditationData / 50, 0), Time.deltaTime);
        }
    }

    public void OnMessageArrived(SerialData data)
    {
        meditationData = data.meditation;
    }

    private void OnTriggerEnter(Collider other)
    {
        detect = true;
    }
}
