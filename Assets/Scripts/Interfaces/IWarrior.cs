using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IWarrior
{
    public GameObject GetPrefab();

    public GameObject GetGameObject();

    public void SetEnemyStatus(bool isEnemy = true);
    public bool GetEnemyStatus();

    public Sprite GetAvatar();
    public void SetAvatar(Sprite sprite);

    public string GetWarriorName();
    public void SetWarriorName(string name);

    public float GetHpCount();
    public void SetHpCount(float hp);

    public float GetDamageCount();
    public void SetDamageCount(float damage);

    public string GetSaText();
    public void SetSaText(string text);

    public string GetUaText();
    public void SetUaText(string text);

    public void SetWarriorFieldController(WarriorFieldController warriorFieldController);

    public void SetPositionField(GameObject PositionField);
    public GameObject GetPositionField();

    public void SetWarriorsInfoController(WarriorsInfoController warriorsInfoController);
    public WarriorsInfoController GetWarriorsInfoController();

    public AbilitiesController GetAbilityController();

    public void Select();
    public void UnSelect();
    public bool GetSelect();

    public void PlayAnimation(string name);

    public void MakeHit(IWarrior warrior);

    public void MakeSa(IWarrior warrior);

    public void MakeUa(IWarrior warrior);

    public void TakeDamage(float damage);

    public void TakeEffect(IEffect effect);

    public void Die();
}
