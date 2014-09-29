using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameManager gm;
	[SerializeField] float maxSpeed = 10f;
	bool jump = false;
	bool grounded = false;
	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] float jumpForce = 0f;

	[SerializeField] public float spdMulti = 1f;

	Transform groundCheck;
	[SerializeField] LayerMask groundObjects;
	Animator anim;
	
	void Start(){
		groundCheck = transform.Find("GroundCheck");
	}
	
	void Update(){
		if (gm.gs == GameManager.GameState.Game) 
		{
			if (grounded && Input.GetButtonDown ("Jump"))
				jump = true;

			rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * (maxSpeed * spdMulti), rigidbody2D.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			gm.gs = GameManager.GameState.Store;
		}
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundObjects);
		
		if(jump){
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
		
	}

	public void BoughtSpeed()
	{
		spdMulti = 1.5f;		
	}

	public void BoughtBow()
	{
		foreach(Transform child in transform)
		{
			if(child.name == "Weapon")
			{
				child.gameObject.SetActive(true);
			}
		}
	}
//
//	public void BoughtCoolDown()
//	{
//		SendMessage("ReduceCoolDown");
//	}

	
}
