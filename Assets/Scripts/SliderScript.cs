using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider hpBar;

    void Update()
    {
        hpBar.value = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().playerHp;
    }
}
