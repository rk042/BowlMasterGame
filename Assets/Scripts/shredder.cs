﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shredder : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        GameObject thingLeft = col.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }
}
