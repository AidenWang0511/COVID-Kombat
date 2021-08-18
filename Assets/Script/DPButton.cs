using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void FullD()
    {
        if (Dturn)
        {
            DPpressed = true;
            if (EdCoin >= 5)
            {
                EdCoin -= 5;
                EdCoinT.text = "Ed Coin: " + (EdCoin) + "";
                HPT.text = "HP: " + HP;
                enoughEdCoin = true;
            }
            else
            {
                Console.text = "You don't have enough Ed Coin! Please Select Another Defensive Move!";
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
