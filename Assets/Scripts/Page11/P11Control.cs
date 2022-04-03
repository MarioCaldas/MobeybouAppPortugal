using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P11Control : MonoBehaviour
{

    GameManager gm;
    public AudioSource aS;
    public AudioClip aC;
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(WaitForSound());
        gm = FindObjectOfType<GameManager>();

        if (gm.gender)
        {
            GetComponent<Animator>().SetTrigger("girl");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("boy");
        }

        if (gm.language == 1)
        {
            GetComponent<Animator>().SetBool("ln", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("ln", false);
        }
    }


    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(6f);
        GetComponent<Animator>().SetBool("can", true);
        yield return new WaitForSeconds(2f);
        aS.PlayOneShot(aC);
    }

}
