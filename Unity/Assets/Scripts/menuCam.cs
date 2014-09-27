using UnityEngine;
using System.Collections;

public class menuCam : MonoBehaviour {

	[SerializeField]float camSpeed;
	[SerializeField]AudioClip music;

	Vector3 newPos;
	Vector3 mainPos = new Vector3(0,0,-10);
	Vector3 creditPos = new Vector3(15,0,-10);


	void Start () 
	{
		// so the camera does not move to (0,0,0) before a button is pressed
		newPos = mainPos;
		// play music bitch
		AudioSource.PlayClipAtPoint (music, transform.position);
	}
	
	void Update () 
	{
		transform.position = Vector3.MoveTowards(transform.position, newPos, camSpeed * Time.deltaTime);
	}

	void moveCam(string buttonPressed)
	{
		switch (buttonPressed) 
		{
		case "Credits":
			newPos = creditPos;
			break;

		case "Back":
			newPos = mainPos;
			break;

		}
	}



}
