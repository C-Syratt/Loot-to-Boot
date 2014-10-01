using UnityEngine;
using System.Collections;

public class AIMelee : AIBehaviour {

	// Use this for initialization
	void Start () {
		type = AIType.HIT;
		Physics2D.IgnoreCollision(collider2D, GameObject.FindGameObjectWithTag("Player").collider2D);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
