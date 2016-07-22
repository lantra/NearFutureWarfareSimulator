using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipButtonBehavior : MonoBehaviour, IPointerClickHandler
{

    private GameObject Shipvc;
    private GameObject WeaponSelectorDropDownMenu;
    private GameObject TargetSelectorDropDownMenu;


     public void OnPointerClick(PointerEventData eventData)
     {
         //passes data to your button controller (or whater you need to know about the
         //button that was pressed), informing that this game object was pressed.
         Shipvc = GameObject.Find("ShipView");
         WeaponSelectorDropDownMenu = GameObject.Find("WeaponSelector");
         TargetSelectorDropDownMenu = GameObject.Find("TargetSelector");
         GameObject Button = eventData.pointerPress;

         NSObject selectedObj = Button.GetComponentInChildren<ShipButtonController>().getStorage();

         TargetSelectorDropDownMenu.GetComponent<TargetListController>().ChangeTargetList(selectedObj);
         WeaponSelectorDropDownMenu.GetComponent<WeaponSelectorController>().ChangeWeaponList(selectedObj);

         Shipvc.GetComponent<ShipViewController>().changeShipDisplay(eventData, selectedObj.Name);
         GameControllerText.CurrentSelected = selectedObj;
     }
 }
    
