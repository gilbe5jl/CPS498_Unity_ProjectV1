/*@author Jalen Gilbert 
 * CPS498
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //added this namespace 


public class InventoryInterface : MonoBehaviour
{

    //field for bolt text
    private TextMeshProUGUI boltText;

    // Start is called before the first frame update
    void Start()
    {
        //get text component assign to field
        boltText = GetComponent<TextMeshProUGUI>();

    }//end start

    //public method to update bolt text param player inventory...
   public void UpdateBoltText(BoltInventory boltItem)
    {

        //set text to number of bolts in inventory
        boltText.text = boltItem.NumberOfBoltsCollected.ToString();
    
        //call this method whenever a bolt is collected, using unity events 
    }//end updateBoltText
}//end class
