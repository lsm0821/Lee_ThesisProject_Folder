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
        main.simulationSpeed = System.Convert.ToInt32(message);
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device Connected" : "Device disconnected");
    }
}
