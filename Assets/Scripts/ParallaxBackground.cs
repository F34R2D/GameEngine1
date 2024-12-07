using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public static ParallaxBackground instance;
    private Transform theCam;

    public Transform sky;
    public Transform treeline;

    [Range(0f, 1f)]
    public float parallaxSpeed;

    private void Awake()
    {
       instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
  
    public void MoveBackground()
    {
        sky.position = new Vector3(theCam.position.x, theCam.position.y, sky.position.z);

        treeline.position = new Vector3(
            theCam.position.x * parallaxSpeed,
            theCam.position.y * parallaxSpeed,
            treeline.position.z * parallaxSpeed);
    }
}
