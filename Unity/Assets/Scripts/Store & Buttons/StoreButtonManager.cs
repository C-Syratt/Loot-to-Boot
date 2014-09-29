using UnityEngine;
using System.Collections;

public class StoreButtonManager : MonoBehaviour {
	
	[SerializeField]GameObject cam;
	[SerializeField]GameObject buyGob;
	[SerializeField]GameObject buySpd;
	string buttonName;

	public GameManager gm;
	public PlayerController pc;

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
			// Store buttons
		case "Buy Goblin":
			if(gm.score >= 20)
			{
				gm.SendMessage("BuyUpgrade", 20);
				gm.SendMessage("BoughtGoblin");
				buyGob.SetActive(false);
			}
			break;

		case "Buy Speed":
			if(gm.score >= 10)
			{
				gm.SendMessage("BuyUpgrade", 10);
				pc.SendMessage("BoughtSpeed");
				buySpd.SetActive(false);
			}
			break;

		case "Back":
			cam.SendMessage("moveCam", buttonName);
			break;
		}
	}
}
