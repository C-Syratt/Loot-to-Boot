using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] float maxVelocity = 10f;

	void FixedUpdate(){
		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0){
			transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * maxVelocity, transform.position.y);
		}
	}
}
