using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage5Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    [SerializeField] public GameObject mask;

    [SerializeField] private GameObject cegonhas;

    private UI ui;

    [Header("Audio")]
    [SerializeField] private AudioClip cegonha, click;
    [SerializeField] private AudioSource aS;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();

        SetCharacter();

        StartCoroutine(Sequence());

    }
    private IEnumerator Sequence()
    {
        SetCharacter();


        while (!clickable.clicked)
        {
            yield return null;
        }
        girlGO.GetComponentInChildren<Animator>().SetTrigger("BinoclesUse");
        boyGO.GetComponentInChildren<Animator>().SetTrigger("BinoclesUse");

        yield return new WaitForSeconds(1);

        cegonhas.SetActive(false);
        aS.PlayOneShot(click);

        mask.SetActive(true);

        aS.PlayOneShot(cegonha);

        StartCoroutine(ui.Glow(1f));
    }

    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);
            girlGO.GetComponentInChildren<Animator>().SetTrigger("Binocles");
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);
            boyGO.GetComponentInChildren<Animator>().SetTrigger("Binocles");
        }
    }
}
