using UnityEngine;
using System.Collections;

public class WeaponDisplay : MonoBehaviour {

	[SerializeField] int id;

	void Update () {
		if(GameManager.gm.weaponStatus[id])
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
		else
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}
}
