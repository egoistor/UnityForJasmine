using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ClickObject : MonoBehaviour
{
    public GameObject begin;
    public GameObject tips;
    public GameObject choose_m;
    public GameObject choose_e;
    public GameObject frame_empty;
    public GameObject frame_full;
    public GameObject end;
    public Text tips_text;
   

    void Start()
    {
        begin.SetActive(true);
        Button btn1 = (Button)begin.GetComponent<Button>();
        btn1.onClick.AddListener(BeginGame);

        end.SetActive(false);
        tips.SetActive(true);
        tips_text.text="";
        choose_m.SetActive(false);
        choose_e.SetActive(false);
        frame_empty.SetActive(false);
        frame_full.SetActive(false);
       
    }

    void BeginGame()
    {
        choose_m.SetActive(true);
        choose_e.SetActive(true);
        frame_empty.SetActive(true);
        Destroy(begin);
    }


    public void chooseMorning()
    {
        end.SetActive(true);
        frame_empty.SetActive(false);
        frame_full.SetActive(true);
        Destroy(choose_m);
        Destroy(choose_e);
    }

    public void chooseEvening()
    {
        end.SetActive(true);
        frame_empty.SetActive(false);
        frame_full.SetActive(true);
        Destroy(choose_m);
        Destroy(choose_e);
    }

    public void endGame()
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
        tips_text.text = "下午两点以后采出的茉莉花效果更好哟";
    }
}