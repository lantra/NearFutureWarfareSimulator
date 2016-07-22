using UnityEngine;
using System.Collections;

public class NSComponent : ScriptableObject {

    public string ComponentName;
    public float ComponentHP, ComponentArmor, ComponentMaxHP;
    public bool destroyed;

    public NSComponent()
    {
        destroyed = false;
    }

    public NSComponent(string CN, float CHP, float CA)
    {
        ComponentName = CN;
        ComponentHP = CHP;
        ComponentMaxHP = CHP;
        ComponentArmor = CA;
        destroyed = false;

    }

    public  bool TakeDamage(float inc)
    {
        inc = inc / 100; //divide damage by 100
        inc = inc / ComponentArmor; //divide by component armor

        ComponentHP -= inc;

        if (ComponentHP < 0)
        {
            destroyed = true;
        }

        return destroyed;
        
    }

    public virtual void Repair(float DR)
    {
        if (ComponentHP < ComponentMaxHP && !destroyed)
        {
            ComponentHP += DR;
            if (ComponentHP > ComponentMaxHP) { ComponentHP = ComponentMaxHP; }
        }
    }

    
}
