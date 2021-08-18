using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void HalfD()
    {
        if (Dturn)
        {
            DSpressed = true;
            if (EdCoin >= 3)
            {
                EdCoin -= 3;
                EdCoinT.text = "Ed Coin: " + (EdCoin) + "";
                HP -= damage/2;
                HPT.text = "HP: " + HP;
                DSBomb = true;
                enoughEdCoin = true;
                Dpressed = true;
            }
            else
            {
                Console.text = "You don't have enough Ed Coin! Please Select Another Defensive Move!";
                DSBomb = false;
                enoughEdCoin = false;
            }
            //PlayerControl.SetInteger ("State", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
