using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCamScaler : MonoBehaviour
{
    public float horizontalFoV = 0.0f;

    public bool isTablet;

    private float smallestScreenHeight = 828;
    private float biggestScreenHeight = 1536;

    [SerializeField] private Transform imageToScale;

    enum Exceptions { defaultPage, page3, page9 };
    [SerializeField] Exceptions exceptions;

    [SerializeField] RectTransform text;

    private void Start()
    {
        if (IsTablet())
        {
            print(imageToScale);
            float valueScale = biggestScreenHeight / smallestScreenHeight;
            print(valueScale);

            if(exceptions == Exceptions.page3)
            {
                text.anchoredPosition = new Vector2(0, -354f);
                imageToScale.transform.position = new Vector3(0, 1.22f, 0);
                //imageToScale.localScale = new Vector3(1.3f, 1.59f, 1);
            }
            else if (exceptions == Exceptions.page9)
            {
                if(imageToScale)
                imageToScale.transform.position = new Vector3(0, 1.67f, 0);

                //if(text)
                text.anchoredPosition = new Vector2(0, -354f);

            }
            else
            {
                isTablet = true;

                if (imageToScale)
                    imageToScale.localScale = new Vector3(valueScale, valueScale, 1);
            }
            print("is a tablet");
        }
        else
        {
            isTablet = false;
            print("not a tablet");
        }

        print("-----------------------------");
        print("Screen.width " + Screen.width);
        print("Screen.height " + Screen.height);
        horizontalFoV = GetComponent<Camera>().fieldOfView;
    }
    // ...

    void Update()
    {
        if(!isTablet)
        {
            float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

            float halfHeight = halfWidth * Screen.height / Screen.width;

            float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

            GetComponent<Camera>().fieldOfView = verticalFoV;

        }

    }


    public static bool IsTablet()
    {

        float ssw;
        if (Screen.width > Screen.height) { ssw = Screen.width; } else { ssw = Screen.height; }



        if (ssw < 800) return false;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            print("aqui ze");
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float size = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
            if (size >= 6.5f) return true;
        }

        return false;
    }
}
