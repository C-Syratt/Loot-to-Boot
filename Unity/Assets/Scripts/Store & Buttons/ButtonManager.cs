using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	[SerializeField]GameObject cam;
	string buttonName;
	
	void OnMouseDown()
	{
		// set the var buttonName to the name of the button click and run ButtonPressed func
		buttonName = gameObject.name;
		ButtonPressed (buttonName);
	}


	// rather than make an individual script for each button
	// I am running the names through a switch statement to easily see what each button does
	void ButtonPressed(string buttonName)
	{
		switch (buttonName) 
		{
		// Main Menu Screen buttons
		case "Play":
			Application.LoadLevel(1);
			break;

		case "Credits":
			cam.SendMessage("moveCam", buttonName);
			break;

		case "Exit":
			print ("Exit");
			Application.Quit();
			break;

		// Credits Screen buttons
		case "Back":
			cam.SendMessage("moveCam", buttonName);
			break;

		}

	}


}
