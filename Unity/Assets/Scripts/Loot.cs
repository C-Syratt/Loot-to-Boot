using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

	bool grounded = false;
	[SerializeField] [Range(0, 10)] float maxHeight = 4;
	[SerializeField] [Range(0, 10)] float minHeight = 2;
	[SerializeField] [Range(0, 10)] float distanceX = 2;

	Vector3 vel = new Vector3(2, 2, 0);
	Vector3 grav = new Vector3(0, -2, 0);
	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] LayerMask groundObjects;
	Transform groundCheck;

	void Start(){
		vel = new Vector3(Random.Range(-distanceX, distanceX), Random.Range(minHeight, maxHeight), 0f);
		grav = new Vector3(0f, Random.Range(-minHeight, -maxHeight), 0f);
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(transform.position, groundRadius, groundObjects);
		if(!grounded){
			transform.position = transform.position + vel * Time.deltaTime;
			vel = vel + grav * Time.deltaTime;
		}
	}
}
