using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class WeaponSelectorController : MonoBehaviour {

    private List<string> ComponentName = new List<string>{};
    private ArrayList WeaponSystems = new ArrayList();
    public NSWeaponC CurrentWeapon;
    public Text WeaponListDisplay;
    private int currentIndex;

	// Use this for initialization
	void Start () {
	
	}

    public void ChangeWeaponList(NSObject obj)
    {
        ComponentName.Clear(); //clear the list
        WeaponSystems.Clear();

        if (obj is NSShip)
        {
            NSShip Ship = (NSShip)obj;
            foreach (NSWeaponC weapon in Ship.components)
            {
                WeaponSystems.Add(weapon);
                ComponentName.Add(weapon.ComponentName);
            }
            UnityEngine.UI.Dropdown dropdown = GetComponent<Dropdown>();
            dropdown.ClearOptions();
            dropdown.AddOptions(ComponentName);
            OnValueChanged(0);
        }


    }



    public void OnValueChanged (int index)
    {
        //TODO: Add try/Catch statements
        currentIndex = index;
        CurrentWeapon = (NSWeaponC) WeaponSystems[index];
        if (CurrentWeapon is NSWMissleLauncher)
        {
            NSWMissleLauncher launcher = (NSWMissleLauncher) CurrentWeapon;
            string s1 = launcher.ComponentName + "\n";
            string s2 = "Ammo: " + launcher.Ammo.ToString() + "\n";
            string s3 = "Number Fired at once: " + launcher.numberfiredAtOnce.ToString() + "\n";
            string s4 = "Missle Fired: " + launcher.MissleFired.Name + "\n";
            string s5 = "Missle Range: " + launcher.MissleFired.range.ToString() + "km. Payload: " + launcher.MissleFired.payload.ToString() + " kg.";
            string final = s1 + s2 + s3 + s4 + s5;
            WeaponListDisplay.text = final;
        }

        else if (CurrentWeapon is NSGun)
        {
            NSGun gun = (NSGun)CurrentWeapon;
            string s1 = gun.ComponentName + "\n";
            string s2 = "Ammo: " + gun.Ammo.ToString() + "\n";
            string s3 = "Rate of Fire: " + gun.rOF.ToString() + "\n";
            string s4 = "Shellsize: " + gun.shellsize.ToString() + "\n";
            string s5 = "Range: " + gun.range.ToString() + "km. Payload: " + gun.payload.ToString() + " kg.";
            string final = s1 + s2 + s3 + s4 + s5;
            WeaponListDisplay.text = final;
        }
    }

    public int getCurrentIndex()
    {
        return currentIndex;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
