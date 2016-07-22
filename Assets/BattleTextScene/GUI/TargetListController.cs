using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TargetListController : MonoBehaviour {

    private List<string> TargetList = new List<string> { };
    private ArrayList TargetListActual = new ArrayList();
    private NSObject target;
    
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeTargetList(NSObject obj)
    {
        TargetList.Clear(); //clear the list
        TargetListActual.Clear();
        foreach (NSObject targets in GameControllerText.ActiveShips)
        {
            if (!(obj.Faction == targets.Faction))
                { 
                    TargetList.Add(targets.Name);
                    TargetListActual.Add(targets);
                } //add the target to the component }
        }

        UnityEngine.UI.Dropdown dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(TargetList);
        OnValueChanged(0);


    }

    public void OnValueChanged (int index)
    { //TODO: Add try/Catch statements
        target = (NSObject) TargetListActual[index];
    }

    public NSObject getTarget()
    {
        return target;
    }
}
