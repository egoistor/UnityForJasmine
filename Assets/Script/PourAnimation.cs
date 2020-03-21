using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourAnimation : MonoBehaviour
{
    public bool startToDetect = false;
    public GameObject flower_tea;
    public Material flower;
    public Material tea;
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
                    StartCoroutine(ChangeMaterial());
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

    IEnumerator ChangeMaterial()
    {
        yield return new WaitForSeconds(1.5f);
        MeshRenderer renderer = flower_tea.GetComponent<MeshRenderer>();
        if(hitInfo.collider.gameObject.name.Contains("flower"))
        {
            renderer.material = flower;
        }
        else
        {
            renderer.material = tea;
        }
        yield return null;
    }
}
