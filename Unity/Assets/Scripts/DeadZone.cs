using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player")
			col.gameObject.transform.position = new Vector2(0f, 0f);
		else
			Destroy(col.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
			col.gameObject.transform.position = new Vector2(0f, 0f);
		else
			Destroy(col.gameObject);
	}
}
