using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy,Soap,Protection,Spray,Vacc,Canva1, Canva2, www1, www2, wrw, rwr;


    public static int HP, HPE;
    public static int EdCoin, state, damage; // state 0 for enemy attack, 1 for defense, 2 for attack
    public static bool DSBomb = true, Bomb = false, Dpressed = false, Dturn = false, DNpressed = false, DSpressed = false, DPpressed = false,
        Oturn = false, OApressed = false, OVpressed = false, Opressed = true, EdCpressed = false,
        W1pressed = false, W2pressed = false, W3pressed = false, R1pressed = false, canPress = false, Pressed = false, runned = false;
    public static bool enoughEdCoin = false, Qturn = false;
    public Animator enemyControl, playerControl;

    public static Text Console, EdCoinT, HPT, HPET, Question, W1,W2,W3,R1;
    public float a;

    void Start()
    {
        Enemy.SetActive(true);
        //Canva2.SetActive(false);
        Console = GameObject.Find("console").GetComponent<Text>();
        HPT = GameObject.Find("HP").GetComponent<Text>();
        HPET = GameObject.Find("HPE").GetComponent<Text>();
        EdCoinT = GameObject.Find("EdCoin").GetComponent<Text>();
        Question = GameObject.Find("Questions").GetComponent<Text>();
        W1 = GameObject.Find("midW").GetComponent<Text>();
        W2 = GameObject.Find("midR").GetComponent<Text>();
        W3 = GameObject.Find("allW1").GetComponent<Text>();
        R1 = GameObject.Find("allW2").GetComponent<Text>();

        W1pressed = false;
        W2pressed = false;
        W3pressed = false;
        R1pressed = false;

        invis();

        state = 0;
        HP = 100; HPE = 275;
        EdCoin = 5;
        EdCoinT.text = "Ed Coin: " + EdCoin + "";
        HPT.text = "HP: " + HP + "";
        HPET.text = "HP: " + HPE + "";
        Console.text = "Watch Out! A Corona Monster just appeared!";
        //enemyControl = Enemy.GetComponent<Animator>();
    }

    void invis()
    {
        www1.SetActive(false);
        www2.SetActive(false);
        wrw.SetActive(false);
        rwr.SetActive(false);
        
    }

    void vis()
    {
        www1.SetActive(true);
        www2.SetActive(true);
        wrw.SetActive(true);
        rwr.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        

        EdCoinT.text = "Ed Coin: " + EdCoin;
        if (state == 0)
        {
            if (UnityEngine.Random.value < 0.6f)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Qturn = false;
                    Question.text = "";
                    playerControl.SetInteger("Pstate", 0);
                    enemyControl.SetInteger("State", 0);
                    Vacc.SetActive(false);
                    Spray.SetActive(false);
                    Console.text = "The Monster Used Infection!\n Please Select a Defensive Move";
                    enemyControl.SetInteger("State", 2);
                    state++;
                    damage = 4;
                    EdCpressed = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Qturn = false;
                    Question.text = "";
                    playerControl.SetInteger("Pstate", 0);
                    enemyControl.SetInteger("State", 0);
                    Vacc.SetActive(false);
                    Spray.SetActive(false);
                    Console.text = "The Monster Used COVID Bomb!\n Please Select a Defensive Move";
                    enemyControl.SetInteger("State", 2);
                    damage = 15;
                    Bomb = true;
                    state++;
                    EdCpressed = false;
                }
            }
            a = UnityEngine.Random.value;
        }
        if(state == 1)
        {
            Dturn = true;
            if (DNpressed)
            {
                enemyControl.SetInteger("State", 0);
                DSBomb = true;
                Dpressed = true;
                playerControl.SetInteger("Pstate", 1);
                Console.text = "You Took Full Damage! :( \n Please Select an Ofensive Move";
                DNpressed = false;
                state++;
                
                
            }else if (DSpressed)
            {
                if (enoughEdCoin)
                {
                    enoughEdCoin = false;
                    enemyControl.SetInteger("State", 0);
                    Soap.SetActive(true);
                    Dpressed = true;
                    playerControl.SetInteger("Pstate", 1);
                    Console.text = "<--This Sanitizer Blocked Some Damage For You! \n Please Select an Ofensive Move";
                    DSpressed = false;
                    state++;
                    
                }
                
            }else if (DPpressed)
            {
                if (enoughEdCoin)
                {
                    enoughEdCoin = false;
                    enemyControl.SetInteger("State", 0);
                    Protection.SetActive(true);
                    Dpressed = true;
                    Console.text = "You Can't Be Touched! Zero Damage Taken \n Please Select an Ofensive Move";
                    DSpressed = false;
                    state++;
                    
                }
                
            }
        }
        

        if(state == 2)
        {
            Dturn = false;
            Oturn = true;
            if (OApressed)
            {
                Dpressed = false;
                Soap.SetActive(false);
                Protection.SetActive(false);
                
                Spray.SetActive(true);
                enemyControl.SetInteger("State", 1);
                Opressed = true;
                Console.text = "Nice Damage With the Alcohol Spray! \n Click the bottom right button to earn more Ed Coin!";
                OApressed = false;
                state++;
                canPress = true;
                Pressed = false;
            }
            else if (OVpressed)
            {
                Dpressed = false;
                Soap.SetActive(false);
                Protection.SetActive(false);
                if (enoughEdCoin)
                {
                    playerControl.SetInteger("Pstate", 2);
                    Vacc.SetActive(true);
                    enemyControl.SetInteger("State", 1);
                    Opressed = true;
                    Console.text = "Critical Damage With The COVID Vaccine! \n Click the bottom right button to earn more Ed Coin!";
                    OVpressed = false;
                    state++;
                }
                canPress = true;
                Pressed = false;
            }
            
            
        }
        

        if(state == 3)
        {
            Qturn = true;
            Oturn = false;
            if (EdCpressed)
            {
                Canva1.SetActive(false);
                
                vis();

                
                if (a < 0.2f)
                {
                    Question.text = "How long can the corona virus survive outside the body?";
                    W1.text = "A week in the air and surfaces";
                    W2.text = "A month on human skin";
                    W3.text = "Two and a half weeks";
                    R1.text = "Several hours to days";
                }
                else if (a < 0.4f)
                {
                    Question.text = "What’s a safe distance to stay apart from someone who’s sick?";
                    W1.text = "At least one foot(30cm)";
                    W2.text = "A least a meter";
                    W3.text = "2 meters";
                    R1.text = "Try not to sit beside people";
                }
                else if (a < 0.6f)
                {
                    Question.text = "Stock markets reacted to the outbreak with a huge increase in volatility. What was the recorded sell-off in March for U.S. stocks?";
                    W1.text = "50%";
                    W2.text = "Record low level";
                    W3.text = "100%";
                    R1.text = "20%";
                }
                else if (a < 0.8f)
                {
                    Question.text = "How much money have the world’s governments and central banks used to counter the economic shock of the virus?";
                    W1.text = "less than 1 dollar";
                    W2.text = "around 1 billion";
                    W3.text = "around 1 trillion";
                    R1.text = "around 3 trillion";
                }
                else if(a<=1.0f)
                {
                    Question.text = "Trump claims that the virus may slow in warmer weathers. Should we believe him? Why?";
                    W1.text = "Yes. Since Trump helped the world stop the spread of corona virus.";
                    W2.text = "Yes. Since Trump is a funny person.";
                    W3.text = "No, because he is more professional wall builders.";
                    R1.text = "No. Since Trump has no evidence.";
                }
                
                if (Pressed)
                {
                    if (R1pressed)
                    {
                        Pressed = false;
                        canPress = false;
                        EdCoin += 3;
                        Console.text = "";
                        Question.text = "Correct! Every correct answer is 3 Ed Coins! \n Press space to continue";
                        state++;
                        runned = true;
                    }
                    else
                    {
                        canPress = false;
                        Pressed = false;
                        Console.text = "";
                        Question.text = "Incorrect! No Ed Coins are awarded! \n Press space to continue";
                        state++;
                        runned = true;
                    }
                }
                    
            }
        }
        if (runned)
        {
            invis();
            Canva1.SetActive(true);
            runned = false;
        }


        if (HP <= 0)
        {
            Console.text = "You Just Got Infected By COVID-19 and Died!";
        }
        else if (HPE <= 0)
        {
            Console.text = "Congrats On Defeating COVID-19!";
        }
        state = state % 4;

    }
}
