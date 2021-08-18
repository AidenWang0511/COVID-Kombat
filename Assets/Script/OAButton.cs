using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OAButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void Alcohol()
    {
        if (Oturn)
        {
            OApressed = true;
            HPE -= 10;
            HPET.text = "HP: " + HPE;
            playerControl.SetInteger("Pstate", 2);
            //PlayerControl.SetInteger ("State", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
