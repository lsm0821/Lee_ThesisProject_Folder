using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataListener : MonoBehaviour
{
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
        int serialdata = System.Convert.ToInt32(message);

        GameObject.Find("TestingCube").GetComponent<Elevator>().OnMessageArrived(serialdata); //all objects that receive serial data come here

        GameObject.FindGameObjectWithTag("Particle").GetComponent<Serial_Particle>().OnMessageArrived(message);

        GameObject.Find("Mesh Generator").GetComponent<Instant_Mesh>().OnMessageArrived(serialdata);

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
