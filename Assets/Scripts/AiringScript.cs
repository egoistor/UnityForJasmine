﻿using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AiringScript: MonoBehaviour
{
    public GameObject Basket;
    public GameObject Rake_1;
    public GameObject Rake_2;
    public GameObject Temperate;
    public GameObject begin;
    public GameObject then;
    public GameObject curing;
    public GameObject Down;
    public GameObject finish;
    public GameObject mix;
    public GameObject NextScene;
    public GameObject FlowerGroup;
    public GameObject ConfirmChoose;
    public GameObject Basket_tall_with_flower;
    public GameObject Basket_tall_with_yulan;
    public GameObject Basket_flat_with_flower;
    public GameObject Basket_flat_with_tea;
    public GameObject flower;
    public Material mat_Flower;
    public Material mat_Transparent;
    public Material mat_Yulan;
    public Material mat_Mix;
    public Slider Mslider;
    public Text tips_text;
    public Text then_txt;
    public Text warning;
    public Text chooseFlowerText;
    public Text title;
    public Image flower1;
    public Image flower2;
    public Image flower3;
    public Image flower4;
    private bool isCuring=false;
    private bool isPause = false;
    private bool isChange = false;
    private bool flower1_isChoose = false;
    private bool flower2_isChoose = false;
    private bool flower3_isChoose = false;
    private bool flower4_isChoose = false;
    private int count=0;
    private int flowerCount = 0;
    private Animation anim;
    // public string animName = "Animations/RakeAnimation"; //将动画片段的名称用一个共有变量来表示

    void Start()
    {
        Basket_flat_with_tea.SetActive(false);
        Temperate.SetActive(false);
        then.SetActive(false);
        mix.SetActive(false);
        NextScene.SetActive(false);
        then_txt.text = "";
        warning.text = "";
        anim = Rake_1.GetComponent<Animation>();
        curing.SetActive(false);
        Down.SetActive(false);
        finish.SetActive(false);
        FlowerGroup.SetActive(false);
        ConfirmChoose.SetActive(false);
        chooseFlowerText.text="";
        Mslider.value = 30;
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
            Destroy(Down);
            count++;
        }
    }

    private void changeUI()
    {
        warning.text = "警告!!!请注意温度，及时降温.否则会影响分数";
    }

    private void Pause()
    {
        Mslider.value = 30;
        warning.text = "";
    }

    public void BeginGame()
    {
        Destroy(begin);
        StartCoroutine(Begin_Game());
    }

    IEnumerator Begin_Game()
    {
        Basket_tall_with_flower.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1.5f);
        Basket_flat_with_flower.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat_Flower;
        Basket_tall_with_flower.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat_Transparent;
        Temperate.SetActive(true);
        then.SetActive(true);
    }

    public void Finish()
    {
        FlowerGroup.SetActive(true);
        Rake_1.transform.position = new Vector3(12, -1, 13);
        isChange = true;
        title.text = "筛花";
        chooseFlowerText.text = "请选择四朵中的其中两朵，作为选择样例，其余花朵将被丢弃";
        ConfirmChoose.SetActive(true);
        Destroy(Temperate);
        Destroy(anim);
        Destroy(finish);
    }

    public void EndChoose()
    {
        if (flowerCount != 2)
        {

        }
        else
        {
            Destroy(flower1);
            Destroy(flower2);
            Destroy(flower3);
            Destroy(flower4);
            Destroy(ConfirmChoose);
            Basket_flat_with_flower.SetActive(false);
            Basket_flat_with_tea.SetActive(true);
            mix.SetActive(true);
            title.text = "调香";
            chooseFlowerText.text = "";
            Camera.main.GetComponent<Animation>().Play();
        } 
    }

    public void MixTeaAndYulan()
    {
        StartCoroutine(Mix());
        Destroy(mix);
        NextScene.SetActive(true);
    }

    public void Next()
    {
        SceneManager.LoadScene("Night");
    }

    IEnumerator Mix()
    {
        Basket_tall_with_yulan.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1.5f);
        flower.GetComponent<MeshRenderer>().material = mat_Yulan;
        Basket_tall_with_yulan.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat_Transparent;
        yield return new WaitForSeconds(1.5f);
        Rake_2.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(3f);
        flower.GetComponent<MeshRenderer>().material = mat_Transparent;
        Basket_flat_with_tea.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat_Mix;
    }

    public void Flower1_isChoosed()
    {
        Debug.Log("enter");
        Debug.Log(flower1_isChoose);
        Debug.Log(flowerCount);
        if (!flower1_isChoose)
        {
            if (flowerCount <= 1)
            {
                flower1_isChoose = true;
                flowerCount++;
                flower1.transform.localScale = 1.2f * Vector3.one;
            }
            else
            {
                chooseFlowerText.text = "请选择四朵中的其中两朵，不能选择过多！！！";
            }
        }
        else
        {
            flower1_isChoose = false;
            flowerCount--;
            flower1.transform.localScale = Vector3.one;
        }
    }

    public void Flower2_isChoosed()
    {
        if (!flower2_isChoose)
        {
            if (flowerCount <= 1)
            {
                flower2_isChoose = true;
                flowerCount++;
                flower2.transform.localScale = 1.2f * Vector3.one;
            }
            else
            {
                chooseFlowerText.text = "请选择四朵中的其中两朵，不能选择过多！！！";
            }
        }
        else
        {
            flower2_isChoose = false;
            flowerCount--;
            flower2.transform.localScale = Vector3.one;
        }
    }

    public void Flower3_isChoosed()
    {
        if (!flower3_isChoose)
        {
            if (flowerCount <= 1)
            {
                flower3_isChoose = true;
                flowerCount++;
                flower3.transform.localScale = 1.2f * Vector3.one;
            }
            else
            {
                chooseFlowerText.text = "请选择四朵中的其中两朵，不能选择过多！！！";
            }
        }
        else
        {
            flower3_isChoose = false;
            flowerCount--;
            flower3.transform.localScale = Vector3.one;
        }
    }

    public void Flower4_isChoosed()
    {
        if (!flower4_isChoose)
        {
            if (flowerCount <= 1)
            {
                flower4_isChoose = true;
                flowerCount++;
                flower4.transform.localScale = 1.2f * Vector3.one;
            }
            else
            {
                chooseFlowerText.text = "请选择四朵中的其中两朵，不能选择过多！！！";
            }
        }
        else
        {
            flower4_isChoose = false;
            flowerCount--;
            flower4.transform.localScale = Vector3.one;
        }
    }

    public void ThenGame()
    {
        then_txt.text= "请点击确认按钮开始养护，请注意养护过程中，请勿让花朵温度过高，否则将影响分数！！！（点击降温，可以使用耙子给茉莉花降温）";
        curing.SetActive(true);
        Destroy(then);
    }

    public void Curing()
    {
        then_txt.text = "";
        isCuring = true;
        Down.SetActive(true);
        Destroy(curing);
    }

    public void PlayGame()
    {
        Mslider.value = 30;
        anim.Play(); // 播放动画
        count++;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Airing");
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
        if (isChange == false)
        {
            tips_text.text = "摊晾后养护的温度以35度到37度最为适宜";
        }
        else
        {
            tips_text.text = "筛去未开花朵和青蒂花蕾";
        }
    }
}