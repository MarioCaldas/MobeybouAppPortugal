using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page6Controller : MonoBehaviour
{
    private GameManager gm;
    private UI ui;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<GameObject> narrationBox;
    [SerializeField] private GameObject page360;

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

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(12);

        StartCoroutine(ui.Glow(1f));

        foreach (var item in narrationBox)
        {
            item.SetActive(false);
        }
        page360.SetActive(false);

    }
}
