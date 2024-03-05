using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayzoneRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Z-axis (forward) by rotationSpeed degrees per second
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
