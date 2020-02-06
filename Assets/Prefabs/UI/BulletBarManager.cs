using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBarManager : MonoBehaviour {

    public UIBulletManager[] whiteBulletUI;
    public UIBulletManager[] rainbowBulletUI;
    [Space]
    public PlayerStats playerStats;
    public PlayerShoting playerShooting;

    public int whitePosIndex = 0;
    public int rainbowPosIndex = 0;

    private void Update()
    {
        //Update bullet bars
        whiteBulletbarUpdate();
        rainbowBulletbarUpdate();
    }

    private void whiteBulletbarUpdate()
    {
        //if 1 bullet is added
        if (playerStats.add)
        {
            //Animate the next bullet to spawn
            whiteBulletUI[whitePosIndex].ActivateBulletUI();
            if(whitePosIndex < 8)
                whitePosIndex++;
            playerStats.add = false;
        }

        //if player shoots
        if (playerShooting.shoot)
        {
            //Animate the next bullet to exit
            whitePosIndex--;
            whiteBulletUI[whitePosIndex].DeactivateBulletUI();
            playerShooting.shoot = false;
        }
    }

    private void rainbowBulletbarUpdate()
    {
        //if 1 bullet is added
        if (playerStats.addRainbow)
        {
            //Animate the next bullet to spawn
            rainbowBulletUI[rainbowPosIndex].ActivateBulletUI();
            rainbowPosIndex++;
            playerStats.addRainbow = false;
        }

        //if player shoots
        if (playerShooting.shootRainbow)
        {
            //Animate the next bullet to exit
            rainbowPosIndex--;
            rainbowBulletUI[rainbowPosIndex].DeactivateBulletUI();
            playerShooting.shootRainbow = false;
        }
    }

}
