using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NightSceneController : MonoBehaviour
{
    public GameObject button_Begin;
    public GameObject text_Caption;
    public GameObject basketWithFlower;
    public GameObject basketWithTea;
    public GameObject mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Begin()
    {
        button_Begin.SetActive(false);
        text_Caption.SetActive(true);
        mainCamera.GetComponent<Animation>().Play();
        basketWithFlower.GetComponent<BoxCollider>().enabled = true;
        basketWithTea.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PourAnimation>().startToDetect = true;
    }
}
