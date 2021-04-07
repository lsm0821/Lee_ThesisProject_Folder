using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageListener : MonoBehaviour
{
    int midValue = 192;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMessageArrived(string message)
    {
        Debug.Log(message);

        /*if (midValue == 192)
        {
            midValue = System.Convert.ToInt32(message);
        }*/

        //GetComponent<Elevator>().speed = midValue - System.Convert.ToInt32(message);
        GetComponent<Elevator>().speed = System.Convert.ToInt32(message);

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
