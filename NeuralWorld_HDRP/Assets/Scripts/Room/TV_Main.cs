using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_Main : MonoBehaviour
{
    int frameCount = 0;
    bool TV_on = false;
    public UnityEngine.Video.VideoClip[] channels;
    int currentChannel = 0;
    public GameObject UI_Text;
    public GameObject transition;
    public GameObject particle;
    public LevitationControl controller;

    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.tag);

            if (hit.collider.tag == "TV_Screen")
            {
                frameCount++;
                if (TV_on == true)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        currentChannel++;
                    }else if (Input.GetKeyDown("q"))
                    {
                        currentChannel--;
                    }
                    updateChannel();
                }
            }

        }
        float fps = 1.0f / Time.deltaTime;
        if (frameCount >= fps*5 && TV_on == false)
        {
            print("TV_On");
            TV_on = true;
            activateTV();
        }
    }

    void activateTV()
    {
        GameObject TV = GameObject.FindGameObjectWithTag("TV_Screen");
        TV.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
        TV.GetComponent<UnityEngine.Video.VideoPlayer>().enabled = true;    //Turning the tv on when you gaze


    }

    void updateChannel()
    {
        GameObject TV = GameObject.FindGameObjectWithTag("TV_Screen");
        UnityEngine.Video.VideoClip selectedMaterial = channels[currentChannel];
        TV.GetComponent<UnityEngine.Video.VideoPlayer>().clip = selectedMaterial;

    }

    public void onMessageReceived(SerialData value)
    {
        if (currentChannel == 0 && TV_on == true)
        {
            controller.floating = true;
            controller.OnMessageArrived(value);

            //GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevating_Object>().OnMessageArrived(value);
            //GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevating_Object>().floating = true;
        }

        if (currentChannel == 1 && TV_on == true)
        {
            particle.SetActive(true);
            controller.floating = false;

        }

        if (currentChannel == 2 && TV_on == true)
        {
            UI_Text.SetActive(true);
            transition.SetActive(true);
        }
    }
}
