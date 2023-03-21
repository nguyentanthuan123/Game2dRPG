using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] Transform objectFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transform.position + objectFollow.forward);
        transform.rotation = Quaternion.LookRotation(transform.position - objectFollow.transform.position);
    }
}
