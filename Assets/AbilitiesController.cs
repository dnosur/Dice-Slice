using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesController : MonoBehaviour
{
    [Header("Abilities Settings")]
    [SerializeField] Slider AbBarSlider;
    [SerializeField] Image AbBarColor;

    [Header("Character Abbilities Settings")]
    [SerializeField] int UpPerMove = 10;

    bool isSpecialAbility;
    bool isUltimateAbility;

    public void UpCounter()
    {
        AbBarSlider.value += UpPerMove;

        if (AbBarSlider.maxValue / 2 <= AbBarSlider.value)
        {
            isSpecialAbility = true;
            AbBarColor.color = new Color(0.01415092f, 0.6327229f, 1, 1);
        }
        else isSpecialAbility = false;

        if (AbBarSlider.maxValue <= AbBarSlider.value)
        {
            isUltimateAbility = true;
            AbBarColor.color = new Color(1, 0.4184997f, 0, 1);
        }
        else isUltimateAbility = false;
    }

    public void TakeAwayAbilityPoint(float point)
    {
        AbBarSlider.value -= point;

        if (AbBarSlider.maxValue / 2 <= AbBarSlider.value)
        {
            isSpecialAbility = true;
            AbBarColor.color = new Color(0.01415092f, 0.6327229f, 1, 1);
        }
        else
        {
            isSpecialAbility = false;
            AbBarColor.color = new Color(1, 0.8732988f, 0, 1);
        }

        if (AbBarSlider.maxValue <= AbBarSlider.value)
        {
            isUltimateAbility = true;
            AbBarColor.color = new Color(1, 0.4184997f, 0, 1);
        }
        else
        {
            isUltimateAbility = false;
            AbBarColor.color = new Color(1, 0.8732988f, 0, 1);
        }
    }

    public void Reload()
    {
        AbBarSlider.value = 0;
        AbBarColor.color = new Color(1, 0.8732988f, 0, 1);

        isSpecialAbility = false;
        isUltimateAbility = false;
    }

    public bool IsSpecialAbility() { return isSpecialAbility; }
    public bool IsUltimateAbility() { return isUltimateAbility; }
    public float GetMaxAbilityPoints() { return AbBarSlider.maxValue; }
}
