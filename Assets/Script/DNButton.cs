using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void DoNothing()
    {
        if (Dturn)
        {
            DNpressed = true;
            Dpressed = true;
            HP -= damage;
            HPT.text = "HP: " + HP;
            //PlayerControl.SetInteger ("State", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
