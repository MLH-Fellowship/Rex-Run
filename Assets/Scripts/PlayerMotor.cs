using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 3.0f;
    private Vector3 moveVector;

    // how high we want to jump
    public float jumpForce = 100;

    public BoxCollider col;
    public Rigidbody rb;

    void Start () {
        controller = GetComponent<CharacterController> ();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
    moveVector = Vector3.zero;

    // left and right
    moveVector.x = Input.GetAxisRaw("Horizontal") * 4.0f;

    // forward
    moveVector.z = speed;

    // jumping
    if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)){
      moveVector.y += 10f * speed;
    }else{
      moveVector.y -= 20f * speed * Time.deltaTime;
    }
    
    controller.Move(moveVector * speed * Time.deltaTime);
	}

  // Update speed according to difficulty level
  public void SetSpeed(int modifier)
  {
      speed = 3.0f + modifier/4.0f;
  }
}
