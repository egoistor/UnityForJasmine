using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightSceneController : MonoBehaviour
{
    public GameObject button_Begin;
    public Text text_Caption;
    public GameObject basketWithFlower;
    public GameObject basketWithTea;
    public GameObject mainCamera;
    public GameObject ImageGroup;
    public GameObject mix;
    public GameObject next;
    public Image[] image = new Image[7];
    public Sprite moli_cha;
    public GameObject Rake;
    public GameObject ChooseTime;
    public GameObject downTemp;
    public GameObject clickDowmTemp;
    public GameObject Temp;
    public GameObject tips;
    public Text title;
    public Text tips_text;
    public Material flowerWithTea;
    public GameObject flower_tea;
    public Slider Mslider;
    public GameObject finish;
    private bool isCuring = false;
    private int count = 0;
    private Animation anim;
    private int chooseTips = 0;
    void Start()
    {
        mix.SetActive(false);
        ChooseTime.SetActive(false);
        downTemp.SetActive(false);
        ImageGroup.SetActive(false);
        clickDowmTemp.SetActive(false);
        next.SetActive(false);
        Temp.SetActive(false);
        finish.SetActive(false);
        text_Caption.text = "";
    }

    void Update()
    {
        if (count <= 4)
        {
            if (isCuring)
            {
                Mslider.value += (Time.deltaTime * 2);
                if (Mslider.value > 45)
                {
                    changeUI();
                    Invoke("Pause", 2);
                }
            }
        }
        if (count == 5)
        {
            Mslider.value = 36;
            finish.SetActive(true);
            Destroy(clickDowmTemp);
            count++;
        }
    }

    private void changeUI()
    {
        text_Caption.text = "警告!!!请注意温度，及时降温.否则会影响分数";
    }

    private void Pause()
    {
        Mslider.value = 30;
        text_Caption.text = "请使用耙子给花堆降温，与晾晒相似";
    }

    public void ClickDownTemp()
    {
        Mslider.value = 30;
        anim.Play(); // 播放动画
        count++;
    }

    public void Begin()
    {
        button_Begin.SetActive(false);
        text_Caption.text = "点击相应箩筐倾倒茉莉花和茶叶";
        mainCamera.GetComponent<Animation>().Play();
        basketWithFlower.GetComponent<BoxCollider>().enabled = true;
        basketWithTea.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PourAnimation>().startToDetect = true;
        ImageGroup.SetActive(true);
    }

    public void PlayMix()
    {
        Destroy(basketWithFlower);
        Destroy(basketWithTea);
        anim = Rake.GetComponent<Animation>();
        anim.Play();
        for (int i = 0; i < 7; i++)
        {
            image[i].sprite = moli_cha;
        }
        Destroy(mix);
        MeshRenderer renderer = flower_tea.GetComponent<MeshRenderer>();
        renderer.material = flowerWithTea;
        next.SetActive(true);
    }

    public void toMotionless()
    {
        Destroy(ImageGroup);
        Destroy(next);
        title.text = "静置";
        text_Caption.text = "请选择静置时间";
        chooseTips = 1;
        ChooseTime.SetActive(true);
        downTemp.SetActive(true);
    }

    public void toDownTemp()
    {
        title.text = "通花";
        text_Caption.text = "请使用耙子给花堆降温，与晾晒相似";
        chooseTips = 2;
        Temp.SetActive(true);
        clickDowmTemp.SetActive(true);
        Destroy(downTemp);
        Destroy(ChooseTime);
        isCuring = true;
    }

    public void MouseEnter()
    {
        tips_text.text = "点击tips即可获得提示，但是会扣除相应分数，如果需要查看细节，请查看课程介绍";
    }

    public void MouseExit()
    {
        tips_text.text = "";
    }

    public void MouseClick()
    {
        if (chooseTips == 0)
        {
            tips_text.text = "将茉莉花和茶叶隔层加入最为适宜";
        }
        if (chooseTips == 1)
        {
            tips_text.text = "静制4-5个小时，给花香和茶香充足的融合时间";
        }
        if (chooseTips == 2)
        {
            tips_text.text = "温度为30-35度最为适宜";
        }
       
    }
}
