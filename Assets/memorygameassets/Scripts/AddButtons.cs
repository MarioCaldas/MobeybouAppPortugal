using System.Collections;
using UnityEngine;

public class AddButtons : MonoBehaviour{

[SerializeField]
private Transform puzzleField;

[SerializeField]
private GameObject btn;

void Awake() {
    for(int i = 0; i < 12; i++) {
        GameObject button = Instantiate(btn);
        button.name = "" + i;
        button.transform.SetParent(puzzleField, false); 
        }
    }
} //Add buttons
