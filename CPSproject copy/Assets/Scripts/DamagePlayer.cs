/*@author Jalen Gilbert 
 * Player receives damage when walking into a fire
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HB
{
    public class DamagePlayer : MonoBehaviour
    {
        public int damage = 10;
        //when player enters trigger event is triggered 
        private void OnTriggerEnter(Collider other)
        {
           PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                //check if object that enters collider has a player stats script, then call TakeDamage on playerStats script, inflict 25 damage to player health 
                playerStats.TakeDamage(damage);
                //playerStats.ReactionAnimator(true);
            }
        }//end OnTriggerEnter 

        


    }//end class
}//end namespace