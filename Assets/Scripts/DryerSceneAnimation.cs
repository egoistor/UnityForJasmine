using System.Net.Mime;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DryerSceneAnimation : MonoBehaviour
{
    public Canvas canvas;
    public Text text_title;
    public Button button_begin;
    public Button button_then;
    public Button button_room;
    public Button button_dry;
    public GameObject image_room;
    public GameObject mix;
    public GameObject flower;
    public GameObject tea;
    public GameObject basket_flower;
    public GameObject basket_tea;
    public Animation mainCamera;
    public Transform secondTransform;
    public Animation door_left;
    public Animation door_right;
    public GameObject dryerLight;

    public void Saperate_1()
    {
        mix.SetActive(false);
        flower.SetActive(true);
        tea.SetActive(true);
        button_begin.gameObject.SetActive(false);
        button_then.gameObject.SetActive(true);
    }

    public void Saperate_2()
    {
        flower.SetActive(false);
        tea.SetActive(false);
        basket_flower.SetActive(true);
        basket_tea.SetActive(true);
        button_then.gameObject.SetActive(false);
        button_room.gameObject.SetActive(true);
    }

    public void SwitchToRoom()
    {
        text_title.text = "烘焙";
        button_room.gameObject.SetActive(false);
        canvas.GetComponent<Animation>().Play();
        StartCoroutine(Switch_Room());
    }
    IEnumerator Switch_Room()
    {
        yield return new WaitForSeconds(1f);
        Camera.main.transform.SetPositionAndRotation(secondTransform.position, secondTransform.rotation);
        image_room.SetActive(false);
        Camera.main.GetComponent<Animation>().Play();
        mainCamera.Play();
        door_left.Play();
        door_right.Play();
        yield return new WaitForSeconds(1.5f);
        button_dry.gameObject.SetActive(true);
    }

    public void Dry()
    {
        button_dry.gameObject.SetActive(false);
        dryerLight.SetActive(true);
    }
}
