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


    //Milos
      private Animator anim;
    public ParticleSystem fireballParticle;
     private AudioSource audioSource;

    //spawn manager
    public GameObject Goblin;
    public GameObject Porky;
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

        //audio
        audioSource = GetComponent<AudioSource>();
    }
    public void attacking(float dmg)
    {
        chestHealth -= dmg;
    }
    public void spawnEnemies(int round)
    {
        if (!isSpawning)
        {
            for (int count = 0; count < round + 2; count++)
            {
                spawnMob("Goblin");
                StartCoroutine(wait());
                spawnMob("Porky");
                StartCoroutine(wait());
                spawnMob("Spider");
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
        if (mobName.Equals("Porky"))
        {
            Instantiate(Porky, spawnLocation, Quaternion.identity);
        }
    }
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
        textElement.text = "Health: " + chestHealth;
    }
}
