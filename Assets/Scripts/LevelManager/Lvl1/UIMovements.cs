using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovements : MonoBehaviour {

    public GameObject healthBar;
    public Vector3 healthBarNewPos;
    [Space]
    public GameObject bulletBar;
    public Vector3 bulletBarNewPos;
    [Space]
    public GameObject keyBar;
    public Vector3 keyBarNewPos;

    public void MoveUIComponents()
    {
        //HEALTH BAR
        if (healthBar != null)
            healthBar.transform.localPosition = healthBarNewPos;
        //BULLET BAR
        if (bulletBar != null)
            bulletBar.transform.localPosition = bulletBarNewPos;
        //KEY BAR
        if (keyBar != null)
            keyBar.transform.localPosition = keyBarNewPos;
    }

}
