using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	//Score Variables
	private int score = 0;
	[SerializeField] private TextMesh scoreText;

	//Loot Variables
	[SerializeField] int maxAmountOfLoot = 50;
	int amountOfLoot = 0;
	[SerializeField] private TextMesh lootText;
	//Keep them in a gameObject for AI
	public List<GameObject> lootGameObjects;

	void Start(){
		gm = this;
	}

	// Uses the colour of the loot to determine how many points are given
	// Then update the test, removes 1 from the loot count and 
	// destroys the loot
	public void AddScore(GameObject go, LootColour.Colour colour){
		score += GetColourScore(colour);
		scoreText.text = "Score: " + score;
		RemoveLoot(go);
		Destroy(go);
	}

	public void AddLoot(GameObject go){ 
		amountOfLoot++; 
		lootText.text = "Loot: " + amountOfLoot + " / " + maxAmountOfLoot;
		lootGameObjects.Add(go);
	}
	
	public void RemoveLoot(GameObject go){ 
		amountOfLoot--; 
		lootText.text = "Loot: " + amountOfLoot + " / " + maxAmountOfLoot;
		lootGameObjects.Remove(go);
	}

	// Returns the score for different colour loot
	public int GetColourScore(LootColour.Colour colour){
		int amount = 0;
		switch(colour){
		case LootColour.Colour.BLACK:
			amount = 1;
			break;
		case LootColour.Colour.BLUE:
			amount = 2;
			break;
		case LootColour.Colour.GREEN:
			amount = 3;
			break;
		case LootColour.Colour.PURPLE:
			amount = 4;
			break;
		case LootColour.Colour.RED:
			amount = 5;
			break;
		default:
			amount = 0;
			break;
		}

		return amount;
	}

	//Checks if can spawn the loot, if not, instantly destroys it
	public bool CanSpawnLoot(GameObject go){
		if(amountOfLoot < maxAmountOfLoot)
			return true;
		else
			Destroy(go);

		return false;
	}

}
