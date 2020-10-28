using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor: MonoBehaviour {
  const float X_INT = 6.0f;
  public AudioSource smash;
  private CharacterController controller;
  public BoxCollider col;
  public Rigidbody rb;
  private Vector3 moveVector;
  private float speed = 4.0f, math = -X_INT;
  private bool jumping = false, isDead = false;

  void Start() {
    smash = GetComponent < AudioSource > ();
    controller = GetComponent < CharacterController > ();
    rb = GetComponent < Rigidbody > ();
    col = GetComponent < BoxCollider > ();
  }

  // Update is called once per frame
  void Update() {
    if (isDead) return;

    moveVector = Vector3.zero;

    // left and right
    moveVector.x = Input.GetAxisRaw("Horizontal") * 2.0f;

    // forward
    moveVector.z = speed;

    // jumping
    if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
      jumping = true;
    } else {
      moveVector.y -= 38f * speed * Time.deltaTime;
    }

    if (jumping && math <= X_INT) {
      // math controls how fast to go through the function
      math += 0.4f;
      // jumping movement is mapped using f(x) = -0.12(x-X_INT))(x+X_INT)
      moveVector.y = -0.12f * (math - X_INT) * (math + X_INT);
    } else {
      jumping = false;
      math = -X_INT;
    }

    controller.Move(moveVector * speed * Time.deltaTime);
  }

  // Update speed according to difficulty level
  public void SetSpeed(int modifier) {
    speed = 4.0f + modifier / 6.0f;
  }

  void OnCollisionEnter(Collision collision) {
    // if it hits anything but the ground, it dies
    if (collision.gameObject.tag != "Road" && collision.gameObject.tag != "Player") {
      smash.Play();
      Death();
    }
  }

  private void Death() //float zPoint
  {
    isDead = true;
    Debug.Log("IT HIT");
    GetComponent < Score > ().OnDeath();
  }

}