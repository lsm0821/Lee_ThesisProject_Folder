using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public GameObject[] MainLight;
    public float alphaData;


    // Start is called before the first frame update
    void Start()
    {
        MainLight = GameObject.FindGameObjectsWithTag("LightFlicker");
    }

    // Update is called once per frame

    public void OnMessageReceived(SerialData data)
    {
        alphaData = data.low_alpha;
    }

    void Update()
    {
        foreach (GameObject Light in MainLight)
        {
            Light.GetComponent<Light>().intensity = Mathf.Lerp(Light.GetComponent<Light>().intensity, alphaData, Time.deltaTime);
        }
    }
}
