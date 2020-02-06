using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class EnemyCollisions : MonoBehaviour {

    public EnemySettings enemy;
    public Image healthBar;

    public Material material; //color of the enemy

    public GameObject[] arrBloodStains;
    private BloodColor newBloodStain;

    public GameObject[] arrEnemyDrops;

    public float shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime;

    [Space]
    public SpriteRenderer bodyPart;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    [Space]
    public bool hasMoreParts = false;
    public GameObject objToDestroy;

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
        //Update healthBar
        healthBar.fillAmount = enemy.health / enemy.startHealth;
        if (enemy.health <= 0)
        {
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
                Instantiate(arrEnemyDrops[Random.Range(0, arrEnemyDrops.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                //camera shake
                CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
            }
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
        for(int i = 0; i<5; i++)
        {
            newBloodStain = Instantiate(arrBloodStains[Random.Range(0, arrBloodStains.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))).GetComponent<BloodColor>();
            newBloodStain.SetColor(material);
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
        bodyPart.material.shader = shaderGUItext;
        bodyPart.color = Color.white;
    }
    void NormalSprite()
    {
        bodyPart.material.shader = shaderSpritesDefault;
        bodyPart.color = Color.white;
    }

    public void DestroyEnemy()
    {
        if (!hasMoreParts)
            Destroy(gameObject);
        else
            Destroy(objToDestroy);
    }


}
