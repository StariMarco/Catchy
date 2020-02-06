using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour {

    private EnemySettings enemy;

    private SceneManager sceneManager;

    private PlayerStats playerStats;

    public GameObject bloodStain;
    private BloodColor newBloodStain;
    public Material[] arrMaterials;

    //public Image healthBar;
    public Image dropCounterBar;

    public GameObject circleSpawner;

    public GameObject wallCollisionEffect;

    public GameObject flash;

    [Space]
    public GameObject[] hearts = new GameObject[3];

    [Space]
    public GameObject deathParticleEffect;
    public float timeBeforeRestart;

    public GameObject[] objectsToDeactivate;
    public GameObject groundCrack;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        //controll dropCounterBar
        dropCounterBar.fillAmount = playerStats.collectedDropNumber / playerStats.maxDropNumber;
    }

    //on collision event
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //find what color is the enemy for instantiate the rispective blood sprite
            if (other.GetComponent<EnemySettings>())
                enemy = other.GetComponent<EnemySettings>();
            else
                enemy = other.transform.parent.gameObject.GetComponent<EnemySettings>();

            InstantiateEnemyBlood(enemy);
            //Update player health
            TakeDamage();
            //flash effect
            Instantiate(flash);
            if(enemy.isFirst)
            {
                //respawn first enemy
                StartCoroutine(SpawnRedEnemyTutorial());
            }
            //destroy enemy (change to Enemy2Collisions)
            if(other.gameObject.GetComponent<Enemy2Collisions>() == null)
                other.gameObject.GetComponent<EnemyCollisions>().DestroyEnemy();
            else
                other.gameObject.GetComponent<Enemy2Collisions>().DestroyEnemy();
        }
    }

    IEnumerator SpawnRedEnemyTutorial()
    {
        yield return new WaitForEndOfFrame();
        circleSpawner.GetComponent<Spawner>().SpawnRedEnemy(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("SpawnerProtectorPillar"))
        {
            //instantiate collision effect
            Instantiate(wallCollisionEffect, transform.position, Quaternion.identity);
        }
    }


    void InstantiateEnemyBlood(EnemySettings enemy)
    {
        //Instantiate BloodStain
        newBloodStain = Instantiate(bloodStain, enemy.gameObject.transform.GetChild(0).transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))).GetComponent<BloodColor>();
        //change the color
        switch (enemy.color)
        {
            case "Red": //Red
                newBloodStain.SetColor(arrMaterials[0]);
                break;
            case "Green": //Green
                newBloodStain.SetColor(arrMaterials[1]);
                break;
            case "Yellow": //Yellow
                newBloodStain.SetColor(arrMaterials[2]);
                break;
            case "Rock": //Rock
                newBloodStain.SetColor(arrMaterials[3]);
                break;
            case "Iron": //Iron
                newBloodStain.SetColor(arrMaterials[4]);
                break;
        }
    }

    void TakeDamage()
    {
        playerStats.health--;
        //Update health bar
        //healthBar.fillAmount = playerStats.health / playerStats.startHealth;
        //update UI health
        hearts[(int)(playerStats.health)].gameObject.GetComponent<HeartAnimationManager>().DestroyHeart();

        if (playerStats.health <= 0)
            StartCoroutine(DeathAnimatons());
    }

    IEnumerator DeathAnimatons()
    {
        //death animation
        Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
        Instantiate(groundCrack, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        GameObject[] playerParts = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i<playerParts.Length; i++)
        {
            if(playerParts[i].GetComponent<SpriteRenderer>())
                playerParts[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        //destroy all enemy
        GameObject[] arrEnemyLeft = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i<arrEnemyLeft.Length; i++)
        {
            Destroy(arrEnemyLeft[i]);
        }
        //deactivate objects
        for(int i = 0; i<objectsToDeactivate.Length; i++)
        {
            objectsToDeactivate[i].SetActive(false);
        }

        yield return new WaitForSeconds(timeBeforeRestart);
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
