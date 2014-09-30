using UnityEngine;
using System.Collections;

public class AIShoot : AIBehaviour {
	
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject weaponSpawnPoint;
	[SerializeField] GameObject bulletPre;
	[SerializeField] float bulletImpulse;

	//Re-align variables incase it gets moved for some reason
	float realignInteval = 3f;
	float realignCounter = 0f;

	//Shoot counters
	float shootCooldown = 0.2f;
	float shootCounter = 0f;

	Transform t;
	
	void Start () {
		type = AIType.SHOOT;
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").collider2D, collider2D);
		t = transform;
		Realign();
	}
	
	void Update () {
		realignCounter += Time.deltaTime;
		shootCounter += Time.deltaTime;
		if(realignCounter >= realignInteval){
			Realign();
			realignCounter = 0f;
		}

		if(shootCounter >= shootCooldown){
			shootCounter = 0; // reset counter
			BulletFired();
			GameObject newBul = Instantiate(bulletPre, weaponSpawnPoint.transform.position, weapon.transform.rotation) as GameObject;
			newBul.rigidbody2D.AddForce(new Vector2(newBul.transform.forward.x, newBul.transform.forward.y));
		}
	}

	void Realign(){
		Transform chest = GameObject.FindGameObjectWithTag("Chest").transform;
		Vector3 dir = chest.position - t.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void BulletFired(){

	}
}
