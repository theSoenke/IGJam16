﻿using UnityEngine;
using System.Collections;

public class Dragable : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void OnDrag()
    {
        transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
