using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage7Pt : MonoBehaviour
{
    [SerializeField] private GuitarPlayer clickablePtBoy;
    [SerializeField] private GuitarPlayer clickablePtGirl;
    [SerializeField] private GuitarPlayer clickablePtAngolaBoy;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private GameManager gm;
    private UI ui;

    [Header("Audio")]
    //[SerializeField] public AudioClip boyOnRight1, boyOnRight2, boyLaught1, boyLaught2, girlLaught1, girlLaught2;
    [SerializeField] public AudioSource aS;
    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();

        StartCoroutine(Sequence());

    }

    private IEnumerator Sequence()
    {

        while (!clickablePtBoy.clicked || !clickablePtGirl.clicked || !clickablePtAngolaBoy.clicked)
        {

            yield return null;
        }

       

        StartCoroutine(ui.Glow(1f));

    }
    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);

        }
    }
}
