using UnityEngine;
using System.Collections;

public class NSShipFactory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static NSShip createVenomLightCruiser(string name, string faction)
    {
        ArrayList componentlist = new ArrayList();
        componentlist.Add(new NSGun("Mark IV 54mm Gun", 10, 4, 800, 37, 31.75F, 20, .87F, 6, 35, 5));
        componentlist.Add(new NSWMissleLauncher("Venom STS Launcher", 10, 4, 32, NSMissleFactory.createVenomSTSM(faction), 2));
        componentlist.Add(new NSWMissleLauncher("Venom STS Launcher", 10, 4, 32, NSMissleFactory.createVenomSTSM(faction), 2));
        componentlist.Add(new NSWMissleLauncher("Ballista CM Launcher", 12, 4, 2, NSMissleFactory.createBallistaCM(faction), 1));
        NSShip ship = new NSShip(name, faction, "Venom LMC", 5, componentlist, 40, 2.5F, 173, 523);
        
        return ship;
    }

    public static NSShip createSeagullDestroyer(string name, string faction)
    {
        ArrayList componentlist = new ArrayList();
        componentlist.Add(new NSGun("Mark IV 54mm Gun Mod", 10, 4, 600, 37, 31.75F, 26, .87F, 6, 35, 5));
        componentlist.Add(new NSGun("Mark IV 54mm Gun Mod", 10, 4, 600, 37, 31.75F, 26, .87F, 6, 35, 5));
        componentlist.Add(new NSWMissleLauncher("Bolt Cruise Missle Launcher", 10, 2, 2, NSMissleFactory.createBoltCM(faction), 2));
        NSShip ship = new NSShip(name, faction, "Seagull Destroyer", 5, componentlist, 56, 1.5F, 155, 303);

        return ship;
    }
}
