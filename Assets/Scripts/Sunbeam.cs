using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sunbeam
{
    Vector3 pos, dir;

    GameObject sunbeamObj;
    LineRenderer sunbeam;
    List<Vector3> sunbeamPoints = new List<Vector3>();
    public Sunbeam(Vector3 pos, Vector3 dir, Material mat) 
    { 
        this.sunbeam = new LineRenderer();
        this.sunbeamObj = new GameObject();
        this.sunbeamObj.name = "Sunbeam";
        this.pos = pos;
        this.dir = dir;

        this.sunbeam = this.sunbeamObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.sunbeam.startWidth = 0.1f;
        this.sunbeam.endWidth = 0.1f;
        this.sunbeam.material = mat;    
        this.sunbeam.startColor = Color.yellow;
        this.sunbeam.endColor = Color.white;

        CastRay(pos, dir, sunbeam);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer sunbeam)
    {
        sunbeamPoints.Add(pos);
        
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 30))
        {
            CheckHit(hit, dir, sunbeam);
        }
        else
        {
            sunbeamPoints.Add(ray.GetPoint(30));
            UpdateSunbeam();
        }
    }

    void UpdateSunbeam()
    {
        int count = 0;
        sunbeam.positionCount = sunbeamPoints.Count;

        foreach(Vector3 pts in sunbeamPoints) 
        {
            sunbeam.SetPosition(count, pts);
            count++;
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer sunbeam)
    {
        if (hitInfo.collider.gameObject.CompareTag("Mirror"))
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, sunbeam);
        }
        if (hitInfo.collider.gameObject.CompareTag("Enemy"))
        {
            Object.Destroy(hitInfo.collider.gameObject);
        }
        else
        {
            sunbeamPoints.Add(hitInfo.point);
            UpdateSunbeam();
        }
    }
}
