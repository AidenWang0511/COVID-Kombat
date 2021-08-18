using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allW1W3 : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void check()
    {
        if (canPress && !Pressed)
        {
            W3pressed = true;
            Pressed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
