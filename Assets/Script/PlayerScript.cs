using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    Animator anim;
    Slider slider;    
    SerialReceive serialReceive;
    Image fill;
    int currentLevel = 0;
    public AudioClip[] clips;
    private AudioSource audioSource;
    public TextMeshProUGUI text;
    private string[] texts = {
        "",
        "ふふん...",
        "やっほー！",
        "いったたた...",
        "むっかー！！"
    };
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1);
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        serialReceive = GameObject.Find("SerialReceive").GetComponent<SerialReceive>();
        fill = GameObject.Find("Fill").GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayVoice());
    }


    void Update()
    {
        anim.SetInteger("Heart", serialReceive.heart);
        slider.value = serialReceive.heart;
        ChangeFillColor();
        SetLevel();
    }

    void SetLevel()
    {
        if (serialReceive.heart < 2)
        {
            currentLevel = 0;
        }
        else if (serialReceive.heart < 4)
        {
            currentLevel = 1;
        }
        else if (serialReceive.heart < 6)
        {
            currentLevel = 2;
        }
        else if (serialReceive.heart < 8)
        {
            currentLevel = 3;
        }
        else
        {
            currentLevel = 4;
        }
    }

    void ChangeFillColor()
    {
        if (currentLevel == 0)
        {
            fill.color = Color.blue;
        }
        else if (currentLevel == 1)
        {
            fill.color = Color.cyan;
        }
        else if (currentLevel == 2)
        {
            fill.color = Color.green;
        }
        else if (currentLevel == 3)
        {
            fill.color = Color.yellow;
        }
        else
        {
            fill.color = Color.red;
        }
    }

    IEnumerator PlayVoice()
    {
        int preLevel = 0;
        while (true)
        {
            yield return new WaitUntil(() => currentLevel != preLevel);
            if (preLevel != currentLevel)
            {
                if (currentLevel != 0)
                {
                    audioSource.clip = clips[currentLevel];
                    audioSource.Play();
                }
                text.text = texts[currentLevel];
            }
            preLevel = currentLevel;
        }

    }
}
