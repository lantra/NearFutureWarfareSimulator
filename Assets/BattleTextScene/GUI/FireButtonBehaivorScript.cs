using UnityEngine;
using System.Collections;

public class FireButtonBehaivorScript : MonoBehaviour {

    public GameObject WeaponSelector;
    public GameObject TargetSelector;

    public void onClick()
    {
        NSWeaponC CurrentWeapon = WeaponSelector.GetComponent<WeaponSelectorController>().CurrentWeapon;
        if (CurrentWeapon is NSWMissleLauncher)
        {
            NSWMissleLauncher MissleLauncher = (NSWMissleLauncher) CurrentWeapon;
            MissleLauncher.FireMissle(GameControllerText.CurrentSelected, TargetSelector.GetComponent<TargetListController>().getTarget());
            WeaponSelector.GetComponent<WeaponSelectorController>().OnValueChanged(WeaponSelector.GetComponent<WeaponSelectorController>().getCurrentIndex());
        }

        else if (CurrentWeapon is NSGun)
        {
            NSGun gun = (NSGun)CurrentWeapon;
            gun.FireFullBurst((NSShip)TargetSelector.GetComponent<TargetListController>().getTarget()); //TODO: THIS SHIT IS FUCKED, FIX QUICKLY
            WeaponSelector.GetComponent<WeaponSelectorController>().OnValueChanged(WeaponSelector.GetComponent<WeaponSelectorController>().getCurrentIndex());
        }
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
