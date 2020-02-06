using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour {

    public PlayerStats playerStats;

    public void Start()
    {
        //add 1 key to the player
        playerStats.collectedKey++;
        //if tha player collected all the keys open the next lvl gate
        if(playerStats.collectedKey >= playerStats.KeyAmount)
        {
            playerStats.openGate = true;
        }
    }

}
