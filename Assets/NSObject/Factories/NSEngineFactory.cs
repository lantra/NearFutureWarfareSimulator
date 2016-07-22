using UnityEngine;
using System.Collections.Generic;

public  class NSEngineFactory : MonoBehaviour
{
    public static NSCEngine createMKIIIGasEngines()
    {
        NSCEngine engine = new NSCEngine("MKIII Gas Engines", 24, 3, 40F, 1.852F, 4);
        return engine;
    }

    public static NSCEngine createMKIVGasEngines()
    {
        NSCEngine engine = new NSCEngine("MKIV Gas Engines", 24, 3, 56F, 1.852F, 4);
        return engine;
    }

    public static NSCEngine createHBONuclearEngine()
    {
        NSCEngine engine = new NSCEngine("HBO Battleship Nuclear Engines", 36, 4, 36F, 1.0F, 6);
        return engine;
    }

}

