using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject[] MainLight;


    // Start is called before the first frame update
    void Start()
    {
        MainLight = GameObject.FindGameObjectsWithTag("LightFlicker");
    }

    // Update is called once per frame

    public void OnMessageReceived(SerialData data)
    {
        foreach (GameObject Light in MainLight)
        {
            Light.GetComponent<Light>().intensity = data.low_alpha;
        }
    }

    void Update()
    {
        
    }
}
