﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdCButton : GameMechanics
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void check()
    {
        if (Qturn)
        {
            EdCpressed = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
