using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] backImageTransform;
    [SerializeField] private float [] coeffX;
    [SerializeField] private float[] coeffY;
    private int imageCount;

    private void Start()
    {
        imageCount = backImageTransform.Length;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < imageCount; i++)
        {
            backImageTransform[i].position = new Vector2(transform.position.x * coeffX[i], transform.position.y * coeffY[i]);
        }
    }
}
