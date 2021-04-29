using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public Camera cam;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
