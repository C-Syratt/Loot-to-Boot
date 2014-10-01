using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	[SerializeField] GameObject[] loot;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Instantiate(loot[Random.Range(0, loot.Length)], transform.position, Quaternion.identity);
		}
		if (col.gameObject.tag == "Projectile")
		{
			// ALL THE LOOT!!!
			for(int i = 0; i < 20; i++)
				Instantiate(loot[Random.Range(0, loot.Length)], transform.position, Quaternion.identity);
			Destroy(col.gameObject);
		}
	}
}
