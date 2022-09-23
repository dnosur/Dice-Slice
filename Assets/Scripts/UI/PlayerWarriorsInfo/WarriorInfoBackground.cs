using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorInfoBackground : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] Image Avatar;

    [Header("Texts")]
    [SerializeField] Text WarriorName;
    [SerializeField] Text HpCount;
    [SerializeField] Text DamageCount;
    [SerializeField] Text SaText;
    [SerializeField] Text UaText;

    [Header("Buttons")]
    [SerializeField] Button ChangeHandleButton;
    [SerializeField] Button HitButton;
    [SerializeField] Button SaButton;
    [SerializeField] Button UaButton;

    IWarrior warrior;

    public delegate void ChangeHandle(IWarrior firstWarrior, IWarrior secondWarrior);
    public delegate void HitHandle(IWarrior warrior);
    public delegate void ChangeMovementSideHandle();

    void Update()
    {
        if (HitButton != null && SaButton != null && UaButton != null)
        {
            if (HitButton.gameObject.activeInHierarchy)
            {
                if (warrior.GetAbilityController().IsSpecialAbility()) SaButton.gameObject.SetActive(true);
                if (warrior.GetAbilityController().IsUltimateAbility()) UaButton.gameObject.SetActive(true);
            }
        }
    }

    public delegate void ClearHandler();
    public ClearHandler clearHandler { get; set; }

    public Image GetAvatar() { return Avatar; }
    public void SetAvatar(Sprite sprite) { Avatar.sprite = sprite; }

    public string GetWarriorName() { return WarriorName.text; }
    public void SetWarriorName(string name) { WarriorName.text = name; }

    public float GetHpCount() { return float.Parse(HpCount.text); }
    public void SetHpCount(float hp) { HpCount.text = hp.ToString(); }
    public void SetHpCountColor(Color color) { HpCount.color = color; }

    public float GetDamageCount() { return float.Parse(DamageCount.text); }
    public void SetDamageCount(float damage) { DamageCount.text = damage.ToString(); }
    public void SetDamageCountColor(Color color) { DamageCount.color = color; }

    public string GetSaText() { return SaText.text; }
    public void SetSaText(string text) { SaText.text = text; }

    public string GetUaText() { return UaText.text; }
    public void SetUaText(string text) { UaText.text = text; }

    public IWarrior GetWarrior() { return warrior; }
    public void SetWarrior(IWarrior warrior) { this.warrior = warrior; }

    public void SetChangeButtonActive(ChangeHandle change, IWarrior firstWarrior, IWarrior secondWarrior)
    {
        ChangeHandleButton.gameObject.SetActive(true);
        ChangeHandleButton.onClick.AddListener(() => { change.Invoke(firstWarrior, secondWarrior); });
    }
    public void InactiveChangeButton()
    {
        ChangeHandleButton.gameObject.SetActive(false);
        ChangeHandleButton.onClick.RemoveAllListeners();
    }

    public void SetHitButtonActive(HitHandle hitHandle, ChangeMovementSideHandle movementSideHandle, IWarrior warrior)
    {
        HitButton.gameObject.SetActive(true);
        HitButton.onClick.AddListener(() => 
        { 
            hitHandle.Invoke(warrior);
            movementSideHandle.Invoke();
            clearHandler.Invoke();
        });
    }
    public void InactiveHitButton()
    {
        HitButton.gameObject.SetActive(false);
        HitButton.onClick.RemoveAllListeners();
    }

    public void SetSaButtonActive(HitHandle hitHandle, ChangeMovementSideHandle movementSideHandle, IWarrior warrior)
    {
        SaButton.onClick.AddListener(() => 
        { 
            hitHandle.Invoke(warrior);
            movementSideHandle.Invoke();
            clearHandler.Invoke();

            InactiveSaButton();
        });
    }
    public void InactiveSaButton()
    {
        SaButton.gameObject.SetActive(false);
        SaButton.onClick.RemoveAllListeners();
    }

    public void SetUaButtonActive(HitHandle hitHandle, ChangeMovementSideHandle movementSideHandle, IWarrior warrior)
    {
        UaButton.onClick.AddListener(() => 
        { 
            hitHandle.Invoke(warrior);
            movementSideHandle.Invoke();
            clearHandler.Invoke();

            InactiveUaButton();
        });
    }
    public void InactiveUaButton()
    {
        UaButton.gameObject.SetActive(false);
        UaButton.onClick.RemoveAllListeners();
    }

    public void InactiveAllButtons()
    {
        ChangeHandleButton.gameObject.SetActive(false);
        ChangeHandleButton.onClick.RemoveAllListeners();

        HitButton.gameObject.SetActive(false);
        HitButton.onClick.RemoveAllListeners();

        SaButton.gameObject.SetActive(false);
        SaButton.onClick.RemoveAllListeners();

        UaButton.gameObject.SetActive(false);
        UaButton.onClick.RemoveAllListeners();
    }
}
