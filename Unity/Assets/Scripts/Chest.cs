using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	[SerializeField] GameObject[] loot;
	[SerializeField] GameObject[] particles;
	[SerializeField] AudioClip[] sounds;

	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D col){
		anim.SetBool("Open", true);
		GameManager.gm.PlaySound(sounds);
		Particles();
		if(col.gameObject.tag == "Player"){
			Instantiate(loot[Random.Range(0, loot.Length)], transform.position + transform.up, Quaternion.identity);
			Instantiate(loot[Random.Range(0, particles.Length)], transform.position, Quaternion.identity);
		}
		if (col.gameObject.tag == "Projectile")
		{
			// ALL THE LOOT!!!
			for(int i = 0; i < 20; i++){
				Instantiate(loot[Random.Range(0, loot.Length)], transform.position + transform.up, Quaternion.identity);
				Instantiate(loot[Random.Range(0, particles.Length)], transform.position, Quaternion.identity);
			}
			Destroy(col.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D col){
		anim.SetBool("Open", false);
	}

	void OnTriggerEnter2D(Collider2D col){
		anim.SetBool("Open", true);
		GameManager.gm.PlaySound(sounds);
		Particles();
		if(col.tag == "Sword"){
			for(int i = 0; i < 10; i++){
				Instantiate(loot[Random.Range(0, loot.Length)], transform.position + transform.up, Quaternion.identity);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		anim.SetBool("Open", false);
	}

	void Particles(){
		Instantiate(particles[Random.Range(0, particles.Length)], new Vector3(transform.position.x, transform.position.y, 10f), Quaternion.identity);
	}
}
