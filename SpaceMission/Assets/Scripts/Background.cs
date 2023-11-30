﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Background : MonoBehaviour
{
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = 0.1f * Time.time;
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, y));
    }
}
