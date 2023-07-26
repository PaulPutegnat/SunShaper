using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSunbeam : MonoBehaviour
{
    public float shotDuration = 1.0f;
    public float shotIntervalDuration = 2.0f;
    public Material material;

    Sunbeam sunbeam;
    bool isShooting = false;
    void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(shootSunbeam());
        }
    }

    IEnumerator shootSunbeam()
    {
        sunbeam = new Sunbeam(gameObject.transform.position, gameObject.transform.right, material);
        isShooting = true;
        yield return new WaitForSeconds(shotDuration);
        Destroy(GameObject.Find("Sunbeam"));
        yield return new WaitForSeconds(shotIntervalDuration);
        isShooting = false;
    }
}
