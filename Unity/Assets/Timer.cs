using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float t = 5f;

	void Update()
	{
		Destroy (gameObject, t);
	}

}
