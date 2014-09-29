using UnityEngine;
using System.Collections;

public class StoreButtonManager : MonoBehaviour {
	
	[SerializeField]GameObject cam;
	string buttonName;

	[SerializeField]float cost;
	[SerializeField]float coolCostMulti = 1f;

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
			cost = 20;
			if(gm.score >= cost)
			{
				gm.SendMessage("BuyUpgrade", cost);
				gm.SendMessage("BoughtGoblin");
				gameObject.SetActive(false);
			}
			break;

		case "Buy Speed":
			cost  = 10;
			if(gm.score >= cost)
			{
				gm.SendMessage("BuyUpgrade", cost);
				pc.SendMessage("BoughtSpeed");
				gameObject.SetActive(false);
			}
			break;

		case "Buy Bow":
			cost = 70;
			if(gm.score >= cost)
			{
				gm.SendMessage("BuyUpgrade", cost);
				pc.SendMessage("BoughtBow");
				gameObject.SetActive(false);
			}
			break;

		case "Buy CoolDown":
			print ("Activate");
			cost = 20;
			cost = cost * coolCostMulti;
			if(gm.score >= cost)
			{
				gm.SendMessage("BuyUpgrade", cost);
				pc.BroadcastMessage("ReduceCoolDown");
				coolCostMulti += 1f;
			}
			break;

		case "Back":
			cam.SendMessage("moveCam", buttonName);
			break;
		}
	}
}
