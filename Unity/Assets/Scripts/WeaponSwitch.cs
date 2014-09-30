using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	[SerializeField] GameObject[] weapons;
	int currentWeapon = 1;

	void Update () {
		for(int i = 0; i < weapons.Length; i++){
			if(Input.GetKey("" + (i + 1)) && GameManager.gm.weaponStatus[i])
				SetActiveWeapon(i + 1);
		}
	}

	private void SetActiveWeapon(int weaponIndex){
		currentWeapon = weaponIndex;
		GameManager.gm.currentWeapon = (GameManager.WeaponType)(currentWeapon - 1);
		for(int i = 0; i < weapons.Length; i++){
			if(i == (weaponIndex - 1))
				weapons[i].SetActive(true);
			else
				weapons[i].SetActive(false);
		}
	}
}
