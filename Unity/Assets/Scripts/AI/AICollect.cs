using UnityEngine;
using System.Collections;

public class AICollect : AIBehaviour {

	[SerializeField] float moveSpeed = 4f;

	void Start () {
		type = AIType.COLLECT;
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").collider2D, collider2D);
	}

	void Update () {
		if(GameManager.gm.lootGameObjects.Count > 0)
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(GameManager.gm.lootGameObjects[0].transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
	}
}
