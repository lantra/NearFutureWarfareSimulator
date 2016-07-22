using UnityEngine;
using System.Collections;

public class NSWeaponC : NSComponent 

{

    public int Ammo;
    public bool outofAmmo;
    
    public NSWeaponC()
    {
        outofAmmo = false;
    }

    public NSWeaponC (string CN, float CHP, float CA, int A)
    {
        ComponentName = CN;
        ComponentHP = CHP;
        ComponentMaxHP = CHP;
        ComponentArmor = CA;
        Ammo = A;
        outofAmmo = false;
    }


	
}
