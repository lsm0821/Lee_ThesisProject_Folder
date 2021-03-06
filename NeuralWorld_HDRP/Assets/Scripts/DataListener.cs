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
        //int serialdata = System.Convert.ToInt32(message);

        string[] data = message.Split(',');
        SerialData compiledData = new SerialData();
        compiledData.attention = System.Convert.ToInt32(data[1]);
        compiledData.meditation = System.Convert.ToInt32(data[2]);
        compiledData.delta = System.Convert.ToInt32(data[3]);
        compiledData.theta = System.Convert.ToInt32(data[4]);
        compiledData.low_alpha = System.Convert.ToInt32(data[5]);
        compiledData.high_alpha = System.Convert.ToInt32(data[6]);
        compiledData.low_beta = System.Convert.ToInt32(data[7]);
        compiledData.high_beta = System.Convert.ToInt32(data[8]);
        compiledData.low_gamma = System.Convert.ToInt32(data[9]);
        compiledData.high_gamma = System.Convert.ToInt32(data[10]);



        GetComponent<LightFlicker>().OnMessageReceived(compiledData);
        if (GameObject.FindGameObjectWithTag("Elevator"))
        {
            GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator>().OnMessageArrived(compiledData);
        }
        


    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}

public class SerialData
{
    public int attention;
    public int meditation;
    public int delta;
    public int theta;
    public int low_alpha;
    public int high_alpha;
    public int low_beta;
    public int high_beta;
    public int low_gamma;
    public int high_gamma;

}