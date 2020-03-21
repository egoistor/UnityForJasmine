using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourAnimation : MonoBehaviour
{
    public bool startToDetect = false;
    private Ray ray;
    private RaycastHit hitInfo;
    private Animation anim;
    void Start()
    {
        
    }

    void Update()
    {
        if(startToDetect && Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.gameObject.name.Contains("Basket"))
                {
                    anim =  hitInfo.collider.GetComponent<Animation>();
                    anim.Play();
                    startToDetect = false;
                }
            }
        }
        if(anim != null && anim.isPlaying == false)
        {
            startToDetect = true;
            anim = null;
        }
    }
}
