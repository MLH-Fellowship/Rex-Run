using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 4.0f;
    private Vector3 moveVector;

    void Start () {
        controller = GetComponent<CharacterController> ();
    }
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;

        // left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // forward
        moveVector.z = speed;

        controller.Move(moveVector * speed * Time.deltaTime);
	}

}
