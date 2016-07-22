using UnityEngine;
using System.Collections;

public class NSMissle : NSObject
{

    public string typeName;
    public int range; //max range of missle in km
    public float velocity; //in kms
    public int payload; // in kg
    public int guidance; //the perceft of damage 
    public float mass;


    public NSMissle(string n, string f, string tn, int r ,float vel, int payl, int gdnce, float m)
    {
        Name = n;
        Faction = f;
        typeName = tn;
        range = r;
        velocity = vel;
        payload = payl;
        guidance = gdnce;
        mass = m;
    }

    public float getDamageValue()
    {
        return (float)(((Mathf.Pow((mass * (velocity * 1000)), 2) / 2) / 100000000) + (payload * 4.184));
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
