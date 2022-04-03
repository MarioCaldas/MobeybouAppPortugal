using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoading : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(0, 0, -90f*Time.deltaTime);
    }


}
