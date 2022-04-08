using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPartCollection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        RobotPartInventory robotPart = other.GetComponent<RobotPartInventory>();

        if(robotPart != null)
        {
            robotPart.partCollection();
            gameObject.SetActive(false);
        }
    }




}//end class
