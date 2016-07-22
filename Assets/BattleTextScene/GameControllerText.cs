using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerText : MonoBehaviour {

    public static int ECM_FACTOR = 15; // describes how difficult it is for guidance systems to land on target. 
    public static ArrayList MsgLog = new ArrayList();
    public static ArrayList ActiveShips = new ArrayList();
    public static ArrayList Graveyard = new ArrayList();
    public static string FAC1 = "Red Royal Navy";
    public static string FAC2 = "Blue Confedration Navy";
    public static NSObject CurrentSelected;




	// Use this for initialization
	void Awake () 
    {
        NSShip ship1 = NSShipFactory.createVenomLightCruiser("RRN Copernicus", FAC1);
        ActiveShips.Add(ship1);
        NSShip ship2 = NSShipFactory.createVenomLightCruiser("BCN Hornblower", FAC2);
        ActiveShips.Add(ship2);
        NSShip ship3 = NSShipFactory.createVenomLightCruiser("BCN Rock", FAC2);
        ActiveShips.Add(ship3);
        NSShip ship4 = NSShipFactory.createVenomLightCruiser("RRN Skylark", FAC1);
        ActiveShips.Add(ship4);
        NSShip ship5 = NSShipFactory.createSeagullDestroyer("BCN ANavalHero", FAC2);
        ActiveShips.Add(ship5);
        NSShip ship9 = NSShipFactory.createCarrierKillerBattleship("RRN Victory", FAC1);
        ActiveShips.Add(ship9);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void addMessage (string message)
    {
        Debug.Log(message);
        MsgLog.Add(message);
    }

    public static void sinkShip (NSShip ship)
    {
        addMessage(ship.Name + " has sunk!");
        ship.sunk = true;
        Graveyard.Add(ship);
    }

}
