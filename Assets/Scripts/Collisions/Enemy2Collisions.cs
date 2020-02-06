using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Enemy2Collisions : MonoBehaviour {

    public EnemySettings enemy;

    public Material[] materials; //color of the enemy

    public GameObject[] arrBloodStains;
    private BloodColor newBloodStain;

    public GameObject[] arrEnemyDrops;

    public float shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime;

    [Space]
    public SpriteRenderer[] bodyParts;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    [Space]
    public bool hasMoreParts = false;
    public GameObject objToDestroy;

    public bool spawnAllDrops = false;

    public GameObject hitParticleEffect;
    public string hittedSound;
    public string deathSound;

    private void Start()
    {
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        //damage the enemy and if lives = 0 destroy it
        enemy.health--;
        //Play sound
        if (!hittedSound.Equals(""))
            FindObjectOfType<AudioManager>().PlaySound(hittedSound);

        if (enemy.health <= 0)
        {
            //instantiate particle effets
            Instantiate(hitParticleEffect, transform.position, Quaternion.identity);
            //Instantiate enemy blood stain
            InstantiateBloodStain();
            //Collect drop tutorial if is the first enemy
            if (enemy.isFirst)
            {
                //Cursor animation for make the player learn ho to collect a drop
                GameObject d = Instantiate(arrEnemyDrops[Random.Range(0, arrEnemyDrops.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                //camera shake
                CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
                d.GetComponent<DropMouseAnimations>().isFirst = true;
            }
            else
            {
                //Instantiate drop
                if(!spawnAllDrops)
                    Instantiate(arrEnemyDrops[Random.Range(0, arrEnemyDrops.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                else
                {
                    Instantiate(arrEnemyDrops[0], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                    Instantiate(arrEnemyDrops[1], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                }
                //camera shake
                CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
            }
            //Play sound
            if (!deathSound.Equals(""))
                FindObjectOfType<AudioManager>().PlaySound(deathSound);

            //destroy enemy
            DestroyEnemy();
        }
        else
        {
            //hurt animation effect
            StartCoroutine(Flash());
        }
    }

    public void InstantiateBloodStain()
    {
        //Instantiate random BloodStain from the array and set the right color
        for (int i = 0; i < 5; i++)
        {
            newBloodStain = Instantiate(arrBloodStains[Random.Range(0, arrBloodStains.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))).GetComponent<BloodColor>();
            newBloodStain.SetColor(materials[0]);
        }
        for(int i = 0; i<2; i++)
        {
            newBloodStain = Instantiate(arrBloodStains[Random.Range(0, arrBloodStains.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))).GetComponent<BloodColor>();
            newBloodStain.SetColor(materials[1]);
            newBloodStain.GetComponent<SpriteRenderer>().sortingOrder = -18;
        }
    }

    IEnumerator Flash()
    {
        //flash animation
        WhiteSprite();
        yield return new WaitForSeconds(0.05f);
        NormalSprite();
    }

    void WhiteSprite()
    {
        for(int i = 0; i<bodyParts.Length; i++)
        {
            bodyParts[i].material.shader = shaderGUItext;
            bodyParts[i].color = Color.white;
        }
    }
    void NormalSprite()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].material.shader = shaderSpritesDefault;
            bodyParts[i].color = Color.white;
        }
    }

    public void DestroyEnemy()
    {
        //to avoid bugs
        if (enemy.isFirst)
        {
            GameObject[] arrEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < arrEnemy.Length; i++)
            {
                if (arrEnemy[i] != null)
                    Destroy(arrEnemy[i]);
            }
        }
        else
            Destroy(objToDestroy);
    }

}
