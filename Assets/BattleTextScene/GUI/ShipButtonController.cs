using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipButtonController : MonoBehaviour
{

    public Text name, shipclass, faction;
    private NSObject objStorage;

    public void setObjStorage(NSObject o)
    {
        objStorage = o;
    }

    public NSObject getStorage()
    {
        return objStorage;
    }
 
}
