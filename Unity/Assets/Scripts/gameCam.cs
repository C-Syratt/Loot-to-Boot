using UnityEngine;
using System.Collections;

public class gameCam : MonoBehaviour {

	[SerializeField]float camSpeed;
	//[SerializeField]AudioClip music;
	public GameManager gm;

	Vector3 newPos;
	Vector3 gamePos = new Vector3(0,0,-10);
	Vector3 storePos = new Vector3(20,0,-10);

	void Start () 
	{
		// so the camera does not move to (0,0,0) before a button is pressed
		newPos = gamePos;
		// play music bitch
		//AudioSource.PlayClipAtPoint (music, transform.position);
	}
	
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, newPos, camSpeed * Time.deltaTime);

		if (gm.gs == GameManager.GameState.Store) 
		{
			newPos = storePos;
		}
	}
	
	void moveCam(string buttonPressed)
	{
		switch (buttonPressed) 
		{
		case "Buy":
			break;
			
		case "Back":
			newPos = gamePos;
			gm.gs = GameManager.GameState.Game;
			break;
			
		}
	}
}
