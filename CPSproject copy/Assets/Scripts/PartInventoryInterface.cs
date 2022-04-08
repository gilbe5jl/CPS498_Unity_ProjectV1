using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //added this namespace 

public class RobotPartsInventory : MonoBehaviour
{

    private TextMeshProUGUI partText;
    void Start()
    {
        //get text component assign to field
        partText = GetComponent<TextMeshProUGUI>();

    }//end start



    //public method to update bolt text param player inventory...
    public void UpdateBoltText(RobotPartInventory partItem)
    {

        //set text to number of robot parts in inventory
        partText.text = partItem.NumberOfRoboPartsCollected.ToString();

        //call this method whenever a robot part is collected, using unity events 
    }//end updateBoltText


}//end class
