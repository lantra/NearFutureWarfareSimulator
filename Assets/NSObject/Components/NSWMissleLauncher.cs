using UnityEngine;
using System.Collections;

public class NSWMissleLauncher : NSWeaponC
{
    public int numberfiredAtOnce;
    public NSMissle MissleFired;



    public NSWMissleLauncher (string CN, float CHP, float CA, int A, NSMissle missle, int numberfired)
    {
        ComponentName = CN;
        ComponentHP = CHP;
        ComponentMaxHP = CHP;
        ComponentArmor = CA;
        Ammo = A;
        MissleFired = missle;
        numberfiredAtOnce = numberfired;          
    }

    public void FireMissle (NSObject Launcher, NSObject Target)
    {
        if (Ammo >= numberfiredAtOnce)
        {       
            Launcher.LaunchMissleBay(Target, MissleFired, numberfiredAtOnce);
            Ammo -= numberfiredAtOnce;
        }

        else { GameControllerText.addMessage(ComponentName + " is out of Ammo!"); }
    }

}
