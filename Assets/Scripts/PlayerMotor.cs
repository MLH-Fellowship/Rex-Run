using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 3.0f;
    //private float verticalVelocity = 0.0f;
    // private float gravity = 12.0f

    // how high we want to jump
    public float jumpForce = 100;

    public BoxCollider col;
    public Rigidbody rb;

    private bool jumping = false;

    private bool isDead = false;

    void Start () {
        controller = GetComponent<CharacterController> ();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {


    if (isDead)
      return;
    
    moveVector = Vector3.zero;

    // left and right
    moveVector.x = Input.GetAxisRaw("Horizontal") * 4.0f;

    // forward
    moveVector.z = speed;

    if(jumping &&GameObject.FindGameObjectWithTag("Player").transform.position.y < 5.0f){
      moveVector.y += 3f;
    }else{
      jumping = false;
    }
  
    // jumping
    if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)){
        jumping = true;
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

  // private void OnControllerColliderHit(ControllerColliderHit hit)
  // {
  //   if (hit.point.z > transform.position.z + controller.radius){
  //     // Debug.Log ("DID IT HIT");
  //     // Debug.Log (transform.position.z);
  //     // Debug.Log (controller.radius);
  //     Death ();//hit.point.z);  
  //     }
  
  // }

  void OnCollisionEnter(Collision collision)
    { 
      if (collision.gameObject.tag != "Road" && collision.gameObject.tag != "Player") {
        Death();
      }
      // Debug.Log(collision.ToString());
        // foreach (ContactPoint contact in collision.contacts)
        // {
        //     Death ();  
        // }
    }

  private void Death()//float zPoint)
  {
    isDead = true;
    Debug.Log ("IT HIT");
    GetComponent<Score> ().OnDeath ();
    // Debug.Log (zPoint);
    // Debug.Log ("IT HIT");
    
  }  

}
