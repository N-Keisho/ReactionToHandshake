using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    Animator anim;
    int current = 0;
    Slider slider;
    SerialReceive serialReceive;
    Image fill;
    void Start()
    {
        anim = GetComponent<Animator> ();
        anim.SetLayerWeight (1, 1);
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        serialReceive = GameObject.Find("SerialReceive").GetComponent<SerialReceive>();
        fill = GameObject.Find("Fill").GetComponent<Image>();
    }

    
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     if(current < 11) current++;
        //     anim.SetInteger("Heart", current);
        //     slider.value = current;
        // }
        // if(Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     if(current > 0) current--;
        //     anim.SetInteger("Heart", current);
        //     slider.value = current;
        // }
        anim.SetInteger("Heart", serialReceive.heart);
        slider.value = serialReceive.heart;
        Debug.Log(serialReceive.heart);
        ChangeFillColor();
    }

    void ChangeFillColor(){
        if(serialReceive.heart > 8){
            fill.color = Color.red;
        }else if(serialReceive.heart > 6){
            fill.color = Color.yellow;
        }else if(serialReceive.heart > 4){
            fill.color = Color.green;
        }else if(serialReceive.heart > 2){
            fill.color = Color.cyan;
        }
        else{
            fill.color = Color.blue;
        }
    }
}
