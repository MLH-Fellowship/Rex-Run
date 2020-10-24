using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;

    void Start () {
        controller = GetComponent<CharacterController> ();
    }
	
	// Update is called once per frame
	void Update () {
		// float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		// float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		// transform.Translate(horizontalMovement, 0, verticalMovement);
        controller.Move((Vector3.forward * speed) * Time.deltaTime);
	}

}
