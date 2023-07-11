using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text countdown , gameOver;
    public GameObject message;
    float current = 0f, starting = 180f;

    public CoinsCollector cc;
    public Movement move;

    void Start()
    {
        message.SetActive(false);
        current = starting; //Setting the timer
    }

    //Starting countdown timer
    void Update()
    {
        current -= 1 * Time.deltaTime;
        countdown.text = current.ToString("0") + " Seconds";
        if (current <= 0f)//Checking if timer is 0 and displaying the message.
        {
            current = 0f;
            message.SetActive(true);
            gameOver.text = "You Lose";
            
        }
        if (cc.count == 5) //Checking if all coins are collected to end the game.
        {
            gameOver.text = "You Win";
            move.rb.constraints = RigidbodyConstraints.FreezeAll; 
            message.SetActive(true);
        }
    }
}
