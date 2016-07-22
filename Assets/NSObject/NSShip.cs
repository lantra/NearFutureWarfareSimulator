using UnityEngine;
using System.Collections;

public class NSShip : NSObject
{
    public string typeName;
    public float waterlevel; //How much % is the ship full of water
    public int damagecontrolrating; //abstraction o fhoow good the crew is at fixing the ship
    public ArrayList components = new ArrayList();
    public ArrayList destroyedComponents = new ArrayList();
    public int topSpeed; // the top speed in kph
    public float overallHull; //the percentages of intacthull.
    public int crew; //The ammount of crew on board
    public string captain; //a place holder for a future feature TODO: Add in captains
    public float armor; //The armor value of the ship. This divides the ammount of damage coming inot the hull
    public int size; // size in meters
    public bool aegisOnline;
    public bool sunk;

    public NSShip(string n, string f, string tN, int drc, ArrayList compArray, int ts, float a, int s, int crw)
    {
        Name = n;
        Faction = f;
        typeName = tN;
        damagecontrolrating = drc;
        components = compArray;
        topSpeed = ts;
        armor = a;
        size = s;
        waterlevel = 0F;
        aegisOnline = false;
        sunk = false;
        overallHull = 100F;
        crew = crw;

    }

    public bool checkAegisSystems()
    { /*will be used for aegis targeting in later versions*/
        return aegisOnline;
    }

    public void takeDamage (float incomingDamage)
    {
        /*This determines the damage for hull, and not component hits.*/

        float modDamage = (incomingDamage / (size / 10)) / armor;

        if (overallHull - incomingDamage >= 0)
        {
            GameControllerText.addMessage(this.Name + " has taken too much damage! Her hull is shredded and she is sinking quickly!");
            GameControllerText.sinkShip(this);
        }
        else 
        {
            overallHull -= modDamage;
            takeWater();
            reportDamage();
        }
    }

    private void reportDamage()
    {
        if (waterlevel >= 100)
        {
            GameControllerText.addMessage(Name + " is sinking! All hands Abandon Ship!");
            GameControllerText.sinkShip(this);
        }
        else if (destroyedComponents.Count == 0)
        {
            GameControllerText.addMessage(Name + ": Damage Report: Hull Status: " + overallHull + "%. Waterlevel: " + waterlevel + "%. There are no destroyed components.");
        }
        else
        {
            string dCompString = "";
            foreach (NSComponent comp in destroyedComponents)
            {
                dCompString += comp.ComponentName + " has been destroyed!";
            }
            GameControllerText.addMessage(Name + ": Damage Report: Hull Status: " + overallHull + "%. Waterlevel: " + waterlevel + "%. " + dCompString + " have been destroyed.");
        }
    }

    private void takeWater()
    {
        waterlevel = (float)(100 - overallHull);
    }

    private float hitSeverity (float damage)
    {
        return (float) (Random.Range(0, (damage / 10)));
    }


    public void conventionalWeaponHit(NSGun gun)
    {
        int roll = Random.Range(0, 100);
        if (roll < 20) { } //glancing hit
        else if (roll < 80)
        { takeDamage(gun.getDamageValue()); }//hull hit
        else
        {
            ComponentDamage(gun.getDamageValue());
        }
    }

    public void missleHit(NSMissle missle)
    {
        /*This class determines missle hits, once torpedeos and cruise missles have been added, this will need some changing
         once components have been added damage will go here.*/
        int roll = Random.Range(0, 100);

        if (roll < 10)
        {
            GameControllerText.addMessage(missle.Name + " has glanced off harmlessly.");
        }
        else if (roll < 70)
        {
            GameControllerText.addMessage(missle.Name + " has hit the hull of " + this.Name + "!");
            takeDamage(missle.getDamageValue() + hitSeverity(missle.getDamageValue()));
        }
        else if (roll < 80)
        {
            GameControllerText.addMessage(missle.Name + " has hit the waterline of " + this.Name + "!");
            takeDamage((missle.getDamageValue() + hitSeverity(missle.getDamageValue())*2));

        }

        else if (roll < 100) //COmponent hits
        {
            ComponentDamage(missle.getDamageValue()  + hitSeverity(missle.getDamageValue()));
            //Bridge Hits are special, and will have a special way to determine their hits here, Bridge MAy not be connected to component class

        }
        else
        {
            GameControllerText.addMessage(missle.Name + " has hit the " + Name + "  through her smoke stack! The SHIP EXPLODES!!!");
            GameControllerText.sinkShip(this);
        }
        
    }

public void ComponentDamage(float incDamage)
    {
        if (!(components.Count == 0))
        {
            int cdRoll = Random.Range(0, components.Count - 1);
            NSComponent CurrentComponent = (NSComponent)components[cdRoll];
            GameControllerText.addMessage(CurrentComponent.ComponentName + " has been hit!");
            if (CurrentComponent.TakeDamage(incDamage))
            {
                destroyedComponents.Add(CurrentComponent);
                components.RemoveAt(cdRoll);
                GameControllerText.addMessage(CurrentComponent.ComponentName + " has been destroyed!");

                if (CurrentComponent is NSWeaponC)
                {
                    NSWeaponC CurrentWeapon = (NSWeaponC)CurrentComponent;
                    if (CurrentWeapon.Ammo > 0) //WEAPONSYSTEM GO BOOM
                    {
                        GameControllerText.addMessage(CurrentComponent.ComponentName + " munitions have blown up on " + this.Name + "!");
                        takeDamage(incDamage);
                    }
                }
            }
        }
        else
        {
            takeDamage(incDamage);
        }
        //Bridge Hits are special, and will have a special way to determine their hits here, Bridge MAy not be connected to component class


    }
}
