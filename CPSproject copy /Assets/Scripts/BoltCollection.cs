/*@author Jalen Gilbert
 * If player collides with bolt game object 
 * Increment number of bolts in the inventory
 * then deactivte bolt game object.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCollection : MonoBehaviour
{
    //detect collisions between bolt and player using OnTrigger method
    //called whenever the player collides with the bolt game object 
    private void OnTriggerEnter(Collider other)
    {
        //Check that the colllision is with the player
        //get the playerInventory component from the object that has been collided with
        BoltInventory boltItem = other.GetComponent<BoltInventory>();

        //if the playerInventory component is not null the collision is with the player
        if(boltItem != null)
        {
            //use the playerInventory component to call the BoltCollection method
            boltItem.BoltCollection();
            //set the bolt game object to inactive after collection
            gameObject.SetActive(false);


        }//end if
    }//end method 




}//end class
