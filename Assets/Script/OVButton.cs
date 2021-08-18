using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void FullD()
    {
        if (Oturn)
        {
            OVpressed = true;
            if (EdCoin >= 5)
            {
                EdCoin -= 5;
                EdCoinT.text = "Ed Coin: " + (EdCoin) + "";
                HPE -= 20;
                HPET.text = "HP: " + HPE;
                enoughEdCoin = true;
            }
            else
            {
                Console.text = "You don't have enough Ed Coin! Please Select Another Ofensive Move!";
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
