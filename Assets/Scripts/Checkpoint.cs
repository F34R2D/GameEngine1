using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool isActive;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && isActive == false)
        {
            anim.SetBool("isFlagActive", true);
            isActive = true;

        }
    }
}
