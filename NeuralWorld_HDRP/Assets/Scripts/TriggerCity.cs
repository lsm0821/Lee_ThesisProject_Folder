using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCity : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road;
    void OnTriggerEnter(Collider other)
    {
        road.GetComponent<Animator>().SetTrigger("Unfold");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
