using UnityEngine;
using System.Collections;

public class StoreButtonManager : MonoBehaviour {
	
	[SerializeField]GameObject cam;
	[SerializeField]GameObject text;
	string buttonName;

	[SerializeField]int cost;
	[SerializeField]float costMulti = 1f;

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
			// Once off Upgrades
		case "Buy Goblin":
			print(GameManager.gm.score);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				GameManager.gm.BoughtGoblin();
				gameObject.SetActive(false);
			}
			break;

		case "Buy GoblinShooter":
			print(GameManager.gm.score);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				GameManager.gm.BoughtGoblinShter();
				gameObject.SetActive(false);
			}
			break;

		case "Buy Speed":
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				pc.SendMessage("BoughtSpeed");
				gameObject.SetActive(false);
			}
			break;

		case "Buy Bow":
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				pc.SendMessage("BoughtBow");
				gameObject.SetActive(false);
			}
			break;
		
			// Stacking Upgrades
		case "Buy Max Loot":
			cost = (int) (cost * costMulti);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				GameManager.gm.SendMessage("IncreseMaxLoot");
				costMulti++;
			}
			break;
					
		case "Buy CoolDown":
			cost = (int) (cost * costMulti);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				pc.BoughtSpeed;
				costMulti++;
			}
			break;
			// !name correctly!
		case "Buy SwordSpeed":
			cost = (int) (cost * costMulti);
			if(GameManager.gm.score >= cost)
			{
				GameManager.gm.BuyUpgrade(cost);
				GameManager.gm.IncreaseSwingSpeed();
				costMulti++;
			}
			break;
		

			// Navigation buttons
		case "Weapons":
			cam.SendMessage("moveCam", buttonName);
			break;

		case "Upgrades":
			cam.SendMessage("moveCam", buttonName);
			break;

		case "Back":
			cam.SendMessage("moveCam", buttonName);
			break;
		}
	}
}
