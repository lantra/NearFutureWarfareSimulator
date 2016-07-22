using UnityEngine;
using System.Collections;

public class NSMissleFactory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public static NSMissle createVenomSTSM (string faction)
    {

        NSMissle missle = new NSMissle("Venom STS Missle", faction, "Venom STSM", 70, .24F, 221, 75, 661);
        return missle;

    }

    public static NSMissle createBallistaCM(string faction)
    {
        NSMissle missle = new NSMissle("Ballista CM", faction, "Balista CM", 200, .24F, 455, 60, 1300);
        return missle;
    }

    public static NSMissle createBoltCM(string faction)
    {
        NSMissle missle = new NSMissle("Bolt CM", faction, "Bolt CM", 65, 2.0F, 150, 30, 400);
        return missle;
    }

}
