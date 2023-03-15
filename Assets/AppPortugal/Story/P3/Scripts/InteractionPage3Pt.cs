using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage3Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private UI ui;

    private int totalFruits = 7;

    public int currentFruits;

    [SerializeField] private Animator animator;

    [SerializeField] public bool isDragging;

    [SerializeField] private List<GameObject> dragables;

    [Header("Audio")]
    [SerializeField] private AudioClip fruit, finalFruit;
    [SerializeField] private AudioSource aS;

    public void DragablesDisabler(GameObject currentDrag, bool value)
    {
        print("disable");
        foreach (var item in dragables)
        {
            if(item != currentDrag && !item.GetComponent<Drag>().inPlace)
            {
                item.SetActive(value);
            }
        }
    }

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();

        aS.volume = 0.8f;

        StartCoroutine(Sequence());

    }
    private IEnumerator Sequence()
    {
        SetCharacter();

        //animator.SetBool("glow", true);


        /*while (!clickable.clicked)
        {
            yield return null;
        }*/


        while (!FullBasket())
        {
            yield return null;
        }

        aS.PlayOneShot(finalFruit);

        animator.SetBool("glow", false);

        StartCoroutine(ui.Glow(1f));

    }

    public bool FullBasket()
    {
        if(currentFruits >= totalFruits)
        {
            return true;
        }
        return false;
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

    public void PlayFruitSound()
    {
        aS.PlayOneShot(fruit);
    }
}
