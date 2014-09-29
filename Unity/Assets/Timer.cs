using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	float counter = 0;
	public float t = 5f;

	void Start(){
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").collider2D, collider2D);
	}

	void Update()
	{
		counter += Time.deltaTime;
		if(counter >= t)
			Destroy (gameObject);
	}

}
