using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private PointEffector2D pointEffector;

    private void Awake()
    {
        pointEffector = GetComponent<PointEffector2D>();
    }

    void Start()
    {
        Destroy(pointEffector, 0.5f);
        Destroy(gameObject, 1);
    }
}
