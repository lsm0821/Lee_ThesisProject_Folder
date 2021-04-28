using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevating_Object : MonoBehaviour
{
    public float speed = 2;
    public float meditationData;
    public float alphaData;
    public bool floating;

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
        if (floating == true)
        {
            transform.position = Vector3.Lerp(transform.position, initialLocation + new Vector3(0, meditationData / 124, 0), Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(alphaData, Random.Range(5, 100), 0)), Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialLocation + new Vector3(0, 0, 0), Time.deltaTime);
        }
        
    }

    public void OnMessageArrived(SerialData data)
    {
        meditationData = data.meditation;
        alphaData = data.high_alpha;
        print(meditationData);
    }
}
