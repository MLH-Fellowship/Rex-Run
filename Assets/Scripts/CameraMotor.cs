using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Make camera follow player
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = transform.position;
        position[2] = startOffset.z + lookAt.position.z;
        position[0] = startOffset.x + lookAt.position.x;
        transform.position = position;
        // transform.position = lookAt.position + startOffset;
    }
}
