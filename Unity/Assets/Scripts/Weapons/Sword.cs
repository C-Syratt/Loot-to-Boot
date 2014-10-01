using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	void Update () {
		float speed = 5f;
		if(GameManager.gm.playerStats.hasWeaponPowerup[1])
			speed *= 2;
		transform.Rotate(new Vector3(0f, 0f, speed));
	}
		
}
