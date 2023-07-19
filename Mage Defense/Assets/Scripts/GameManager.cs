using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //for text
    public Text textElement;
    //
    public static GameManager gm;
    private int enemyCount;
    public float chestHealth=1000;
    public int round=1;
    public bool isSpawning = false;
    public bool damage = false;

    //Milos
    private Animator anim;
    public ParticleSystem fireballParticle;
     private AudioSource audioSource;

    //spawn manager
    public GameObject Goblin;
    public GameObject Orc;
    public GameObject Spider;
    public Vector3 spawnLocation = new Vector3(-233f, -23.4f, 28.42f);

    IEnumerator wait()
    {
        isSpawning = true;
        yield return new WaitForSeconds(3);
        isSpawning = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        spawnEnemies(round);
        chestHealth = 1000;

        //audio
        audioSource = GetComponent<AudioSource>();
    }
    public void attacking(float dmg)
    {
        if (damage)
        {
            chestHealth -= dmg;
            damage = false;
        }
    }
    public void spawnEnemies(int round)
    {
        if (!isSpawning)
        {
            if(round<=3)
            {
                for (int count = 0; count < round*3; count++)
                {
                    spawnMob("Goblin");
                    StartCoroutine(wait());
                }
            }
            else
            {
                textElement.text = "gameover!";
            }
            
        }
    }
    public void spawnMob(string mobName)
    {
        if (mobName.Equals("Goblin"))
        {
            Instantiate(Goblin, spawnLocation, Quaternion.identity);
        }
        if (mobName.Equals("Spider"))
        {
            Instantiate(Spider, spawnLocation, Quaternion.identity);
        }
        if (mobName.Equals("Orc"))
        {
            Instantiate(Orc, spawnLocation, Quaternion.identity);
        }
    }

    //VFX

    // Update is called once per frame
    void Update()
    {
        if(chestHealth<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount==0)
        {
            round++;
            spawnEnemies(round);
        }
        textElement.text = "Health: " + chestHealth+" Wave: "+round;
    }
}
