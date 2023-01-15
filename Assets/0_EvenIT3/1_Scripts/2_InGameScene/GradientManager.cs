using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientManager : MonoBehaviour
{
    public Gradient gradient;

    [Range(0, 1)] public float t;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        img.color = gradient.Evaluate(t);

        if (Input.GetKey(KeyCode.K))
        {
            t += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            t -= Time.deltaTime;
        }
    }
}
