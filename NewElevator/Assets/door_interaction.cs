using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        print(other.tag);
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.parent.gameObject.GetComponent<Animator>().SetBool("Open", true);
                
                print("hi");
            }
        }
    }
}
