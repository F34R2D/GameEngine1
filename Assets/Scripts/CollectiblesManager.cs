using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{

    public static CollectiblesManager instance;

    public int extraLifeTreshold = 100;

    private void Awake()
    {
        instance = this;
    }
    public int collectibleCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCollectibles(int amount)
    {
        collectibleCount += amount;

        if(collectibleCount >= extraLifeTreshold)
        {
            collectibleCount -= extraLifeTreshold;

            if(LifeController.instance != null )
            {
                LifeController.instance.AddLife();
            }

        }

        if(UIController.instance != null )
        {
            UIController.instance.UpdateCollectibles(collectibleCount);

        }
    }
}
