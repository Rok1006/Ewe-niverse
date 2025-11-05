using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject Shepherd;
    Animator sheperd_anim;
    int index = 0;
    void Start()
    {
        sheperd_anim = Shepherd.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            index = 0;
        }else if(Input.GetKeyDown(KeyCode.Alpha1)){
            index = 1;
        }else if(Input.GetKeyDown(KeyCode.Alpha2)){
            index = 2;
        }else if(Input.GetKeyDown(KeyCode.Alpha3)){
            index = 3;
        }
        Debug.Log(index);
        
        switch(index){
            case 0:
                sheperd_anim.SetInteger("UseTool", 0);
            break;
            case 1:
                sheperd_anim.SetInteger("UseTool", 1);
            break;
            case 2:
                sheperd_anim.SetInteger("UseTool", 2);
            break;
            case 3:
                sheperd_anim.SetInteger("UseTool", 3);
            break;

        }
    }
}
