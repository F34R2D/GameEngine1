using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicPlayer : MonoBehaviour
{

    public int trackToPlay;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioManager.instance != null)
        AudioManager.instance.PlayLevelMusic(trackToPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
