/*@author Jalen Gilbert
 * CPS498 Team_04 Robot Builder
 * Script for player healthBar 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added this line

namespace HB{


    public class HealthBar : MonoBehaviour
    {

        //create slider
        public Slider slider;
        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void SetCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;


        }

        public void SetMaxHealth(int maxHealth)
        {
            //slider maximum value will be equal to the maximum health the player has
            slider.maxValue = maxHealth;
            //current value of the slider out of max value will be equal to the players current health, 
            slider.value = maxHealth;
            //is player health decreases use this to make the slider decrease
            //if player health is set to a certain max level use this to set the slider to a certain max level 

        }


        



    }//end class
}//end namespace 
