using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;


    private PlayerController thePlayer;
    public float respawnDelay = 2f;

    public int currentLives = 3;

    public GameObject respawnEffect;
    public GameObject deathEffect;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {

        thePlayer.gameObject.SetActive(false);
        thePlayer.theRB.velocity = Vector2.zero;

        currentLives--;

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
            
        }
        else
        {
            currentLives = 0;

            StartCoroutine(GameOverCo());
        }
        UpdateDisplay();
        
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);

        UIController.instance.UpdateLivesDisplay(currentLives);
        


    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnDelay);

        thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPosition;

        PlayerHealthController.instance.AddHealth(PlayerHealthController.instance.maxHealth);

        thePlayer.gameObject.SetActive(true);
        Instantiate(respawnEffect, thePlayer.transform.position, thePlayer.transform.rotation);
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(respawnDelay);

        if(UIController.instance != null)
        {
            UIController.instance.ShowGameOver();
        }
        
    }

    public void AddLife()
    {
        currentLives++;
        UpdateDisplay();
        
    }

    public void UpdateDisplay()
    {
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);

        }
    }
}
