using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] Slider HpBarSlider;
    [SerializeField] Image HpBarColor;
    [SerializeField] Text DamageVisual;

    [Header("Animations")]
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damge)
    {
        HpBarSlider.value -= damge;
        DamageVisual.text = damge.ToString();

        Color color = new Color(((damge * 100) / HpBarSlider.maxValue), HpBarColor.color.g, HpBarColor.color.b, 1);
        HpBarColor.color = color;

        if (HpBarSlider.value <= 0) Die();
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
    }
}
