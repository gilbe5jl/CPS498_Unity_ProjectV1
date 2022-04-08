using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added this namespace


public class RobotPartInventory : MonoBehaviour
{
  public int NumberOfRoboPartsCollected { get; private set; }

    public UnityEvent<RobotPartInventory> PartCollectionEvent;
    public void partCollection()
    {
        NumberOfRoboPartsCollected++;
        PartCollectionEvent.Invoke(this);
    }
}
