using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serial_Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMessageArrived(string message)
    {
        Debug.Log(message);

        

        var main = gameObject.GetComponent<ParticleSystem>().main;
        var serial_income = System.Convert.ToInt32(message);
        
        main.simulationSpeed = serial_income/100;

        GetComponent<ParticleSystemRenderer>().material.color = Color.Lerp(Color.red, Color.blue, serial_income/1023);

        main.gravityModifier = (-1023 / 1.5f + serial_income)/200; //Change a range of gravity modifier. 

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
