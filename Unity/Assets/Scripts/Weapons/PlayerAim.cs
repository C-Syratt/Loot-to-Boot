using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour {
	
	public Vector2 mousePos = Vector2.zero;
	public Vector2 turretPos = Vector2.zero;
	
	//public GMDirector gameDirector;
	
	//public AudioClip bulletFired;		// Audio
	public float aimSpeed = 0.1f;
	public GameObject bulletPre;		// Bullet Prefab
	public float bullImpulse;			// speed of bullet
	public float fireCounter = 0;		// counter for fireCool
	public float fireCool;				// Cooldown between shots
	public Transform bulletSpawnLoc;	// empty game object on end of tank barrel
	
	// Update is called once per frame
	void Update () 
	{
		// Finding the where the mouse is on the screen and pointing towards it
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);		// finding where the mouse is in the world
		turretPos = new Vector2 (mousePos.x - transform.position.x, mousePos.y - transform.position.y);	// Finding the magnitude
		transform.rotation = Quaternion.FromToRotation(Vector2.up, turretPos);	// rotating the turret to face mouse
	}
	
	void FixedUpdate()
	{
		float mult = 1;
		if(GameManager.gm.playerStats.hasWeaponPowerup[0])
			mult = 2;
		fireCounter += Time.deltaTime * mult;
		// Shoot if shooting cooldown allows
		if(Input.GetKey(KeyCode.Mouse0) && fireCounter >= fireCool)
		{
			fireCounter = 0; // reset counter
			BulletFired();	// run func for audio and shot count
			// spawn bullet at end of barrel(empty object)
			GameObject newBul = (GameObject)Instantiate(bulletPre, bulletSpawnLoc.position, transform.rotation);
			// Make the bullet move in direction it is facing
			newBul.rigidbody2D.AddRelativeForce(Vector2.up * bullImpulse, ForceMode2D.Impulse);
		}
	}

	public void ReduceCoolDown()
	{
		fireCool -= 0.2f;
	}
	
	void BulletFired()
	{
		//AudioSource.PlayClipAtPoint(bulletFired, gameObject.transform.position);
	}

}
