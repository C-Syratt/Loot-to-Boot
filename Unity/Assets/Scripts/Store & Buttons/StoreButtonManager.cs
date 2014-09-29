using UnityEngine;
using System.Collections;

public class StoreButtonManager : MonoBehaviour {
	
	[SerializeField]GameObject cam;
	string buttonName;

	[SerializeField]int cost;
	[SerializeField]float coolCostMulti = 1f;

	PlayerController pc;

	void Start(){
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

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
			print(GameManager.gm.score);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				GameManager.gm.BoughtGoblin();
				gameObject.SetActive(false);
			}
			break;

		case "Buy Speed":
			cost  = 10;
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				pc.SendMessage("BoughtSpeed");
				gameObject.SetActive(false);
			}
			break;

		case "Buy Bow":
			cost = 70;
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				pc.SendMessage("BoughtBow");
				gameObject.SetActive(false);
			}
			break;

		case "Buy CoolDown":
			print ("Activate");
			cost = 20;
			cost = (int) (cost * coolCostMulti);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
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
