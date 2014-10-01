using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	void Update () {
		transform.Rotate(new Vector3(0f, 0f, 5f)* GameManager.gm.swingSpeed);
	}
		
}
