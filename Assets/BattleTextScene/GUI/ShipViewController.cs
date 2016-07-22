using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShipViewController : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject ShipViewPrefab;
    private GameObject OldView;


	// Use this for initialization
	void Start () {
        OldView = GameObject.Find("ShipViewElement");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeShipDisplay(PointerEventData v, string s)
    {

        

        foreach (NSShip ship in GameControllerText.ActiveShips)
        {
            if (ship.Name == s)
            {
                Destroy(OldView); //remove old view



                // ShipHull, ShipName, ShipClass, ShipFaction, ShipWaterLevel, ShipArmor, ShipTopSpeed

                GameObject newView = Instantiate(ShipViewPrefab) as GameObject;
                ShipViewElementController controller = newView.GetComponent<ShipViewElementController>();
                controller.ShipArmor.text = "Armor: " + ship.armor.ToString();
                controller.ShipClass.text = ship.typeName;
                controller.ShipName.text = ship.Name;
                controller.ShipFaction.text = ship.Faction;
                controller.ShipHull.text = "HL: " + ((int)ship.overallHull).ToString() + "%";
                controller.ShipWaterLevel.text = "WL: " + ((int)ship.waterlevel).ToString() + "%";
                controller.ShipTopSpeed.text = "Top Speed: " + ship.topSpeed.ToString() + " KM/S";



                
                
                newView.transform.parent = ContentPanel.transform;
                newView.transform.localScale = Vector3.one;

                OldView = newView;
                break;
            }
        }

    }


}
