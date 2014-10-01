using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

	bool grounded = false;
	[SerializeField] [Range(0, 10)] float maxHeight = 4f;
	[SerializeField] [Range(0, 10)] float minHeight = 2f;
	[SerializeField] [Range(0, 10)] float distanceX = 2f;

	Vector3 vel = new Vector3(2, 2, 0);
	Vector3 grav = new Vector3(0, -2, 0);
	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] LayerMask groundObjects;
	Transform groundCheck;

	LootColour.Colour colour;

	void Start(){
		if(GameManager.gm.CanSpawnLoot(gameObject)){
			vel = new Vector3(Random.Range(-distanceX, distanceX), Random.Range(minHeight, maxHeight), 0f);
			grav = new Vector3(0f, Random.Range(-minHeight, -maxHeight), 0f);

			//Add 1 to the lootcount in the GameMananger
			GameManager.gm.AddLoot(gameObject);

			colour = LootColour.Colour.BLACK;
		}
	}

	void Update()
	{
		transform.Rotate (new Vector3 (0f, Random.Range(90f, 360f) * Time.deltaTime, 0f));
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(transform.position, groundRadius, groundObjects);
		if(!grounded){
			transform.position = transform.position + vel * Time.deltaTime;
			vel = vel + grav * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" || col.tag == "Collector" || col.tag == "Fire")
			GameManager.gm.AddScore(gameObject, colour);
	}
}
