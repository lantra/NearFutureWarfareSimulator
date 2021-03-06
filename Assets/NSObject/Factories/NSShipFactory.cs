﻿using UnityEngine;
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
        componentlist.Add(WeaponFactory.CreateMKIV127()); 
        componentlist.Add(WeaponFactory.CreateBallistaCMLauncher(4,1,faction));
        componentlist.Add(WeaponFactory.CreateVenomSTSLauncher(36, 2, faction));
        componentlist.Add(WeaponFactory.CreateVenomSTSLauncher(36, 2, faction));
        componentlist.Add(NSEngineFactory.createMKIIIGasEngines());
        NSShip ship = new NSShip(name, faction, "Venom LMC", 5, componentlist, 2.5F, 173, 523);
        
        return ship;
    }

    public static NSShip createSeagullDestroyer(string name, string faction)
    {
        ArrayList componentlist = new ArrayList();
        componentlist.Add(WeaponFactory.CreateMKIV127());
        componentlist.Add(WeaponFactory.CreateMKIV127());
        componentlist.Add(WeaponFactory.CreateBoltCruiseMissleLauncher(2,2, faction));
        componentlist.Add(NSEngineFactory.createMKIVGasEngines());

        NSShip ship = new NSShip(name, faction, "Seagull Destroyer", 5, componentlist, 1.5F, 155, 303);

        return ship;
    }

    public static NSShip createCarrierKillerBattleship(string name, string faction)
    {
        ArrayList componentList = new ArrayList();
        componentList.Add(WeaponFactory.CreateMKV407mm());
        componentList.Add(WeaponFactory.CreateMKV407mm());
        componentList.Add(WeaponFactory.CreateMKV407mm());
        componentList.Add(WeaponFactory.CreateBallistaCMLauncher(4, 1, faction));
        componentList.Add(WeaponFactory.CreateBallistaCMLauncher(4, 1, faction));
        componentList.Add(NSEngineFactory.createHBONuclearEngine());


        NSShip ship = new NSShip(name, faction, "Carrier Killer Battleship", 10, componentList, 8, 220, 893);

        return ship;
    }
}
