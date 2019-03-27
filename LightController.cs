﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float dayAndNightCycleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dayAndNightCycleSpeed * Vector3.up * Time.deltaTime, Space.Self);
    }
}
