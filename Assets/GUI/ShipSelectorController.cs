using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipSelectorController : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject ShipButtonPrefab;

    void Start()
    {

        foreach (NSShip ship in GameControllerText.ActiveShips)
        {
            GameObject newShip = Instantiate(ShipButtonPrefab) as GameObject;
            ShipButtonController controller = newShip.GetComponent<ShipButtonController>();
            controller.setObjStorage(ship);
            controller.name.text = ship.Name;
            controller.shipclass.text = ship.Faction;
            controller.faction.text = ship.typeName;
            newShip.transform.parent = ContentPanel.transform;
            newShip.transform.localScale = Vector3.one;
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
