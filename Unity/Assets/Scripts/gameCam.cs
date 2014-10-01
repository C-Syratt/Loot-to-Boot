using UnityEngine;
using System.Collections;

public class gameCam : MonoBehaviour {

	[SerializeField]float camSpeed;
	//[SerializeField]AudioClip music;
	public GameManager gm;

	Vector3 newPos;
	Vector3 gamePos = new Vector3(0,0,-10);
	Vector3 storePos = new Vector3(20,0,-10);
	Vector3 weaponPos = new Vector3(40,0,-10);
	Vector3 wUpgradesPos = new Vector3(80,0,-10);

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
		if (gm.gs == GameManager.GameState.WeaponStore) 
		{
			newPos = weaponPos;
		}
		if (gm.gs == GameManager.GameState.WUpgradeStore) 
		{
			newPos = wUpgradesPos;
		}
	}
	
	void moveCam(string buttonPressed)
	{
		switch (buttonPressed) 
		{
		case "Weapons":
			newPos = weaponPos;
			gm.gs = GameManager.GameState.WeaponStore;
			break;
		
		case "Upgrades":
			newPos = storePos;
			gm.gs = GameManager.GameState.Store;
			break;
			
		case "Back":
			newPos = gamePos;
			gm.gs = GameManager.GameState.Game;
			break;
			
		}
	}
}
