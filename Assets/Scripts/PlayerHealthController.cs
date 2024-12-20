using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    private void Awake()
    {
        instance = this;
    }
    public int currentHealth;
    public int maxHealth;
    public float invincibilityLenght = 1f;
    private float invincibilityCounter;

    public SpriteRenderer theSR;
    public Color normalColor;
    public Color fadeColor;

    private PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GetComponent<PlayerController>();
        currentHealth = maxHealth;

        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            if (invincibilityCounter <= 0)
            {
                theSR.color = normalColor;
            }
        }
#if UNITY_EDITOR

        //devTool
        if(Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(1);
        }
#endif
    }

    public void DamagePlayer()
    {
        if(invincibilityCounter <= 0)
        {
            
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                LifeController.instance.Respawn();
            }
            else
            {
                invincibilityCounter = invincibilityLenght;
                theSR.color = fadeColor;
                thePlayer.Knockback();


            }

            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);
        }
        

    }
    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);

    }
}
