using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIBattleTextOutput : MonoBehaviour {

 

    public Text output;


    void Start ()
    {
     
    }

    public void Update()
    {
        if (!(GameControllerText.MsgLog.Count == 0))
        {
            for (int i = GameControllerText.MsgLog.Count-1; i >= 0; i--)
            {
                string s = GameControllerText.MsgLog[i].ToString();
                BattleTextUpdate(s);
                GameControllerText.MsgLog.RemoveAt(i);

            }
        }
    }


    public void ClearBattleText()
    {

    }
 
    public void BattleTextUpdate(string arg0)
    {
        
        string currentText = output.text; //maybe add ToString()?
        string newText = currentText + "\n" + arg0;
        output.text = newText;

    }
     
 
}


