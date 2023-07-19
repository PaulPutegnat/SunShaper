using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject sunbeam;

    void Start()
    {
        sunbeam = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        templeOrientation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(shootSunbeam());
        }
    }

    public IEnumerator shootSunbeam()
    {
        sunbeam.SetActive(true);
        yield return new WaitForSeconds(1);
        sunbeam.SetActive(false);
    }

    public void templeOrientation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}
