using UnityEngine;
using System.Collections;

public class NSCEngine : NSComponent
{
    float topSpeed, Acceleration; //in kph
    int maxNumberEngines, numberEngines;

    public NSCEngine (string CN, float CHP, float CA, float tS, float acc, int Engines)
    {
        ComponentName = CN;
        ComponentHP = CHP;
        ComponentMaxHP = CHP;
        ComponentArmor = CA;
        topSpeed = tS;
        Acceleration = acc;
        maxNumberEngines = Engines;
        numberEngines = Engines;
    }

    public float getSpeed()
    {
        if (ComponentMaxHP != ComponentHP)
        {
            topSpeed = topSpeed / (numberEngines/maxNumberEngines);
        }
        return topSpeed;
    }

}
