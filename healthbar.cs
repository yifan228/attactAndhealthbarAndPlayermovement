using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public int health ;//目前生命值
    public int numOfHeart;//總生命值

    public Image[] Hearts ;
    public Sprite Poo;//目前生命值要放的圖
    public Sprite emptyPoo;//總生命值要放的圖

    
    public Image image;
    public Canvas canvas;

    //public healthbar(int health,int totalHealth,Sprite heartpic,Sprite emptypic,Image image,Canvas canvas)
    //{
    //    this.health = health;
    //    numOfHeart = totalHealth;
    //    emptyPoo = emptypic;
    //    Poo = heartpic;
    //    this.image = image;
    //    this.canvas = canvas;
    //}


    public void Start()
    {
        numOfHeart = playerMovement.instance.totalHp;
        Hearts = new Image[numOfHeart];

        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i] = Instantiate(image);
            Hearts[i].GetComponent<Transform>().parent = canvas.transform;
            Hearts[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(30f + i * 30f, -10f);
            //Hearts[i].GetComponent<RectTransform>().anchorMin = new Vector2(0.1f+i*0.1f, 0.8f);
            //Hearts[i].GetComponent<RectTransform>().position = new Vector2(10,-10);
            Hearts[i].GetComponent<RectTransform>().sizeDelta = new Vector2(30, 30);
            //Hearts[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -50);
            //Hearts[i].GetComponent<RectTransform>().sizeDelta = new Vector2(Hearts[i].GetComponent<RectTransform>().sizeDelta.x, 40);
        }
        Debug.Log(playerMovement.instance.totalHp);
    }
    public void FixedUpdate()
    {


        health = playerMovement.instance.Hp;
        if (health > numOfHeart)
        {
            health = numOfHeart;
        }
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < numOfHeart)
            {
                Hearts[i].enabled = true;

                if (i < health)
                {
                    Hearts[i].sprite = Poo;
                }
                else
                {
                    Hearts[i].sprite = emptyPoo;
                }
            }
            else
            {
                Hearts[i].enabled = false;
            }

        }
    }
}
