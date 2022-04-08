/*@author Jalen Gilbert 
 * CPS498 Team_4
 * Robot Builder
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added this namespace

/// <summary>
/// 
/// </summary>
public class BoltInventory : MonoBehaviour
{
    
    //create public integer property for the number of bolts collected, set to have a private setter
    //any other script can read the value but only this script can set the value 
    public int NumberOfBoltsCollected { get; private set; }

    //create public unity event takes arg of type playerInventory
    public UnityEvent<BoltInventory> BoltCollectionEvent;

    //Bolt collection method

    public void BoltCollection()
    {
        //increment number of bolts collected by player
        NumberOfBoltsCollected++;
        //invoke event passing in 'this' to pass the playerInventory through to the subscribers 
        BoltCollectionEvent.Invoke(this);
    }


}
