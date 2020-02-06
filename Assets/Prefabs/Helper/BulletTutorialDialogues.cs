using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTutorialDialogues : MonoBehaviour {

    private PlayerStats playerStats;
    public HelperManager helperManager;
    [Space]
    [TextArea(3, 10)]
    public List<string> dialogue1 = new List<string>();
    [TextArea(3, 10)]
    public List<string> dialogue2 = new List<string>();

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        helperManager.SetDialogue(dialogue1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playerStats.rainbowBullet < 1)
            {
                //rainbow bullet text
                helperManager.SetDialogue(dialogue2);
            }
            else
            {
                helperManager.SetDialogue(dialogue1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && helperManager.hasDialogued)
        {
            if(playerStats.rainbowBullet == 0)
            {
                //give 1 rainbow bullet at the player
                playerStats.rainbowBullet = 1;
                playerStats.addRainbow = true;
            }

            helperManager.hasDialogued = false;
        }
    }
}
