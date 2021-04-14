using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataListener_Room : MonoBehaviour
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

        GetComponent<LightFlicker>().OnMessageReceived(serialdata);
        //GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>().OnMessageArrived(serialdata);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TV_Main>().onMessageReceived(serialdata);


    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
