using UnityEngine;
using System.Collections;

public class StoreTrigger : MonoBehaviour {

	[SerializeField] GameObject speechBubble;

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			speechBubble.SetActive(true);
			GameManager.gm.allowedStore = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player"){
			speechBubble.SetActive(false);
			GameManager.gm.allowedStore = false;
		}
	}
}
