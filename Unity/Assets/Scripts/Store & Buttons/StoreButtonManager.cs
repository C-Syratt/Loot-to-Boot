using UnityEngine;
using System.Collections;

public class StoreButtonManager : MonoBehaviour {
	
	[SerializeField]GameObject cam;
	[SerializeField]GameObject text;
	string buttonName;

	[SerializeField]int cost;

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
		// Holy fuck this code haha lucky it's a prototype

		if(GameManager.gm.score >= cost || cost == 0){
			switch (buttonName) 
			{

			// Goblins
			case "Buy Goblin":

				if(!GameManager.gm.playerStats.hasGoblin[0])
				{
					GameManager.gm.BuyUpgrade(cost);
					GameManager.gm.BoughtGoblin();
					gameObject.SetActive(false);
				}
				break;

			case "Buy GoblinShooter":

				if(!GameManager.gm.playerStats.hasGoblin[1])
				{
					GameManager.gm.BuyUpgrade(cost);
					GameManager.gm.BoughtGoblinShter();
					gameObject.SetActive(false);
				}
				break;

			case "Buy GoblinMelee":
				if(!GameManager.gm.playerStats.hasGoblin[2])
				{
					GameManager.gm.BuyUpgrade(cost);
					GameManager.gm.BoughtGoblinMelee();
					gameObject.SetActive(false);
				}
				break;
			
				// Loot Upgrades
			case "Buy Max Loot1":
				GameManager.gm.IncreseMaxLoot();
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
				break;

			case "Buy Max Loot2":
				GameManager.gm.IncreseMaxLoot();
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
				break;

			case "Buy Max Loot3":
				GameManager.gm.IncreseMaxLoot();
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
				break;
						
			// Weapons and upgrades
			case "Buy Bow":
				GameManager.gm.score -= cost;
				GameManager.gm.weaponStatus[0] = true;
				gameObject.SetActive(false);
				break;
				
			case "Buy Sword":
				GameManager.gm.score -= cost;
				GameManager.gm.weaponStatus[1] = true;
				gameObject.SetActive(false);
				break;
				
			case "Buy Magic":
				GameManager.gm.score -= cost;
				GameManager.gm.weaponStatus[2] = true;
				gameObject.SetActive(false);
				break;

			case "Buy BowUpgrade":
				GameManager.gm.playerStats.hasWeaponPowerup[0] = true;
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
				break;

			case "Buy SwordUpgrade":
				GameManager.gm.playerStats.hasWeaponPowerup[1] = true;
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
				break;

			case "Buy MagicUpgrade":
				GameManager.gm.playerStats.hasWeaponPowerup[2] = true;
				GameManager.gm.score -= cost;
				gameObject.SetActive(false);
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
}
