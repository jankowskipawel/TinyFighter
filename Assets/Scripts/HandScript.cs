using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public Transform target;

    public GameObject bulletStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint (targetPos);
        targetScreenPos.z = 0;
        Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;
 
        Vector3 targetToMe = transform.position - targetPos;
        targetToMe.z = 0;
 
        Vector3 newTargetToMe = Vector3.RotateTowards(targetToMe, targetToMouseDir,10, 0f);
 
        transform.position = targetPos + 0.8f * newTargetToMe.normalized;
        bulletStart.transform.position = targetPos + 0.8f * newTargetToMe.normalized;
    }
}
