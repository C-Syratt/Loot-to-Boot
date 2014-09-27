using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	[SerializeField] GameObject[] loot;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Instantiate(loot[Random.Range(0, loot.Length)], transform.position, Quaternion.identity);
		}
	}
}
