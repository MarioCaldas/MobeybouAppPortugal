using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCamScaler : MonoBehaviour
{
    public float horizontalFoV = 0.0f;
    private void Start()
    {
        horizontalFoV = GetComponent<Camera>().fieldOfView;
    }
    // ...

    void Update()
    {
        float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

        float halfHeight = halfWidth * Screen.height / Screen.width;

        float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

        GetComponent<Camera>().fieldOfView = verticalFoV;
    }
}
