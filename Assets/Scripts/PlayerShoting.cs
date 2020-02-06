using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoting : MonoBehaviour {

    public GameObject whiteBullet;
    public GameObject rainbowBullet;

    public GameObject whiteBulletSprite;
    public GameObject rainbowBulletSprite;

    private PlayerStats playerStats;
    [HideInInspector]
    public bool shoot = false;
    [HideInInspector]
    public bool shootRainbow = false;

    public Animator animator;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update ()
    {
        if (isShooting())
        {
            Shoot();
        }
    }

    bool isShooting()
    {
        //check if user want to shoot
        return (Input.GetMouseButtonUp(0));
    }

    private void Shoot()
    {
        //if white bullet is selected
        if (whiteBulletSprite.activeSelf)
        {
            //instantiate white bullet
            if(playerStats.whiteBullets > 0)
            {
                Instantiate(whiteBullet, transform.position, Quaternion.identity);
                playerStats.whiteBullets--;
                shoot = true;
                //play sound
                float pitch = Random.Range(0.8f, 1.3f);
                FindObjectOfType<AudioManager>().PlaySound("Shoot1", pitch);
            }
            else
            {
                //do the "no bullets" animation
                animator.SetTrigger("NoAmmo");
                //play sound
                float pitch = Random.Range(2.20f, 2.40f);
                FindObjectOfType<AudioManager>().PlaySound("NoAmmo", pitch);
            }
        }
        else
        {
            //instantiate raimbow bullet
            if (playerStats.rainbowBullet > 0)
            {
                //Instantiate raimbow bullet
                Instantiate(rainbowBullet, transform.position, Quaternion.identity);
                //decrease raimbow bullet quantity 
                playerStats.rainbowBullet--;
                shootRainbow = true;

            }
            else
            {
                //do the "no bullets" animation
                animator.SetTrigger("NoAmmo");
                //play sound
                float pitch = Random.Range(2.20f, 2.40f);
                FindObjectOfType<AudioManager>().PlaySound("NoAmmo", pitch);
            }
        }
    }

}
