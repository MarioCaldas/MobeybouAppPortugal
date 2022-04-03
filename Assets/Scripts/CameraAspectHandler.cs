using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectHandler : MonoBehaviour
{
    // https://gamedesigntheory.blogspot.com/2010/09/controlling-aspect-ratio-in-unity.html

    //private Camera cam = null;
    public bool touchToMouse = true;
    //public bool multiTouch = false;
    public bool allowSleep = true;
    public float ratio = 16.0f / 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        float targetAspect = ratio;
        float currentAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = currentAspect / targetAspect;

        Camera cam = this.GetComponent<Camera>(); //Camera.main;
        Rect rec = cam.rect;

        if (scaleHeight < 1.0f)
        {
            rec.width = 1.0f;
            rec.height = scaleHeight;
            rec.x = 0;
            rec.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rec.width = scaleWidth;
            rec.height = 1.0f;
            rec.x = (1.0f - scaleWidth) / 2.0f;
            rec.y = 0;
        }

        cam.rect = rec;
        
        if (Input.simulateMouseWithTouches != touchToMouse)
        {
            Input.simulateMouseWithTouches = touchToMouse;
        }

        //if (Input.multiTouchEnabled != multiTouch)
        //{
        //    Input.multiTouchEnabled = multiTouch;
        //}

        Screen.sleepTimeout = allowSleep ? SleepTimeout.NeverSleep : SleepTimeout.SystemSetting;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //cam = Camera.main;
    //    //if (cam.orthographic)
    //    //{
    //    //    cam.orthographicSize = Screen.height / 100;
    //    //}

    //    float targetAspect = 16f / 9f;
    //    //float currentAspect = Camera.main.scaledPixelWidth / Camera.main.scaledPixelHeight; // Screen.width / Screen.height;

    //    //float newScale = currentAspect / targetAspect;

    //    ////this.transform.localScale = new Vector3(newScale, newScale, 1f);
    //    //Debug.Log(newScale);
    //    Camera.main.aspect = targetAspect;
    //}
}
