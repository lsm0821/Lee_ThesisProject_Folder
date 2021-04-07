using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(1, 1.5f, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
