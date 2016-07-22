using UnityEngine;
using System.Collections;

public class NSObject : Object
{


    public string Name;
    public string Faction;

    public NSObject()
    {}

    public NSObject(string n, string f)
    {
        Name = n;
        Faction = f;

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void LaunchMissle (NSObject target, NSMissle missle)
   {
     GameControllerText.addMessage(this.Name + " has launched a " + missle.Name + " at " + target.Name);
     if (target is NSShip)
     {
         NSShip ship = (NSShip) target; //we have to cast the target object as ship so we can blow it up

         if (Random.Range(0,100) > GameControllerText.ECM_FACTOR)
         {
             if (Random.Range(0,100) < missle.guidance)
             {
                 if (! ship.checkAegisSystems())
                 {
                     ship.missleHit(missle);
                 }
             }
             else { GameControllerText.addMessage(missle.Name + " missed it's Target!"); }
         }
         else { GameControllerText.addMessage(missle.Name + " was scrambled by ECM!"); }
     }

   }

    public void FireWeapon (NSShip Target, NSGun gun)
    {
        Target.conventionalWeaponHit(gun);
    }

    public void LaunchMissleBay (NSObject target, NSMissle missle, int num)
    {
        for (int n = 0; n < num; n++  )
        {
            LaunchMissle(target, missle);
        }
    }
}
