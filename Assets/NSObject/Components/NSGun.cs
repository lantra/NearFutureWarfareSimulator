using System.Collections.Generic;
using UnityEngine;


public class NSGun : NSWeaponC
{

    public int range; // in km
    public float payload; //in kg of explosives
    public int rOF; //in rounds per minute
    public float muzzleVel; //muzzle velocity in km/s
    public int barrelLength; //in meters
    public int accuarcy;
    public int shellsize; //in mm





    public NSGun(string CN, float CHP, float CA, int A, int R, float pl, int rate, float muzzle, int barrel, int acc, int shell)
    {
        ComponentName = CN;
        ComponentHP = CHP;
        ComponentMaxHP = CHP;
        ComponentArmor = CA;
        Ammo = A;
        payload = pl;
        rOF = rate;
        muzzleVel = muzzle;
        barrelLength = barrel;
        accuarcy = acc;
        shellsize = shell;
    }

    public void FireFullBurst (NSShip target)
    {
        if (Ammo > rOF)
        {
            int hits = 0;
            for (int i = 0; i < rOF; i++)
            {
                int roll = Random.Range(0, 100);
                if (roll > accuarcy + GameControllerText.ECM_FACTOR)
                {
                    hits += 1;
                    target.conventionalWeaponHit(this);
                }
            }
            Ammo -= rOF;
            GameControllerText.addMessage(ComponentName + " has hit " + hits.ToString() + "times!");
        }
        else { GameControllerText.addMessage(this.ComponentName + " is out of Ammo!"); }
    }

    public float getDamageValue()
    {
        return (float)((((Mathf.Pow((payload * (muzzleVel * 1000)), 2) / 2) / 100000000) + (payload * 4.184))*2);
    }
}
