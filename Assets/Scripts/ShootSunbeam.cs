using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSunbeam : MonoBehaviour
{
    public Material material;
    Sunbeam sunbeam;

    void Update()
    {
        Destroy(GameObject.Find("Sunbeam"));
        sunbeam = new Sunbeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}
