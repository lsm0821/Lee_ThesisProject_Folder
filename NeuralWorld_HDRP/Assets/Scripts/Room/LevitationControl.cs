using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationControl : MonoBehaviour
{
    public float meditationData;
    public float alphaData;
    public bool floating;
    Vector3[] initialLocations;
    Quaternion[] initialRotation;
    GameObject[] LevitatingObjects;

    // Start is called before the first frame update
    void Start()
    {
        LevitatingObjects = GameObject.FindGameObjectsWithTag("Elevator");
        initialLocations = new Vector3[LevitatingObjects.Length];
        initialRotation = new Quaternion[LevitatingObjects.Length];
        for (int i = 0; i < LevitatingObjects.Length; i++)
        {
            initialLocations[i] = LevitatingObjects[i].transform.position;
            initialRotation[i] = LevitatingObjects[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LevitatingObjects.Length; i++)
        {
            if (floating == true)
            {
                int randomAxis = Random.Range(0, 3);
                Vector3 rotationVector = Vector3.zero;
                if (randomAxis == 0)
                {
                    rotationVector = new Vector3(alphaData, 0, 0);
                }
                else if (randomAxis == 1)
                {
                    rotationVector = new Vector3(0, alphaData, 0);
                }
                else if (randomAxis == 2)
                {
                    rotationVector = new Vector3(0, 0, alphaData);
                }
                LevitatingObjects[i].transform.position = Vector3.Lerp(LevitatingObjects[i].transform.position, initialLocations[i] + new Vector3(0, meditationData / 124, 0), Time.deltaTime);
                LevitatingObjects[i].transform.rotation = Quaternion.Lerp(LevitatingObjects[i].transform.rotation, Quaternion.Euler(rotationVector), Time.deltaTime);
            }
            else
            {
                LevitatingObjects[i].transform.position = Vector3.Lerp(LevitatingObjects[i].transform.position, initialLocations[i] + new Vector3(0, 0, 0), Time.deltaTime);
                LevitatingObjects[i].transform.rotation = Quaternion.Lerp(LevitatingObjects[i].transform.rotation, initialRotation[i], Time.deltaTime);
            }
        }
    }

    public void OnMessageArrived(SerialData data)
    {
        meditationData = data.meditation;
        alphaData = data.high_alpha/500;
        print(meditationData);
    }
}
