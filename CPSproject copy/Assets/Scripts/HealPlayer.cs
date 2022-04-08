/*@author Jalen Gilbert 
 * Script for controling player 
 * health when receiving a health potion game object 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HB
{
    public class HealPlayer : MonoBehaviour
    {
        public int healAmt = 10;


        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                //check if object that enters collider has a player stats script, then call TakeDamage on playerStats script, inflict 25 damage to player health 
                playerStats.HealPlayer(healAmt);
                //playerStats.ReactionAnimator(false);
                gameObject.SetActive(false);
            }
        }//end OnTriggerEnter 



    }//end class
}