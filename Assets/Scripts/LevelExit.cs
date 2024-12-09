using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private bool isEnding;
    public string nextLevel;

    public float waitToEndLevel = 2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isEnding == false)
        {
            if (other.CompareTag("Player"))
            {
                isEnding = true;

                AudioManager.instance.PlayLevelMusic();

                StartCoroutine(EndLevelCo());
            }
        }
        
    }

    IEnumerator EndLevelCo()
    {

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(nextLevel);
    }

}
