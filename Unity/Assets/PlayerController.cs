using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[SerializeField] float maxSpeed = 10f;
	bool jump = false;
	bool grounded = false;
	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] float jumpForce = 0f;
	
	Transform groundCheck;
	[SerializeField] LayerMask groundObjects;
	Animator anim;
	
	void Start(){
		groundCheck = transform.Find("GroundCheck");
	}
	
	void Update(){
		if(grounded && Input.GetButtonDown("Jump"))
			jump = true;
		
		rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, rigidbody2D.velocity.y);
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundObjects);
		
		if(jump){
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
		
	}
	
}
