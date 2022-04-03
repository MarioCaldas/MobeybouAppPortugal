using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antagonisttoJump : MonoBehaviour
{
    public Antagonist Antagonistscript;
    public void OnTriggerEnter2D(Collider2D obstacle){
        print("Triggered: "+obstacle.gameObject.name);
        if(obstacle.gameObject.name.Equals("carro")){
            Antagonistscript.Jump(11f);
        }else{
            Antagonistscript.Jump(7f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
