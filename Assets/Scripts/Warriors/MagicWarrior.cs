using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWarrior : MonoBehaviour, IWarrior
{
    [Header("Prefabs")]
    [SerializeField] GameObject ModelPrefab;

    [Header("Characteristics")]
    [SerializeField] Sprite Avatar;
    [SerializeField] string Name;
    [SerializeField] float HP;
    [SerializeField] float damage;
    [SerializeField] string Sa;
    [SerializeField] string Ua;

    [Header("Controllers")]
    [SerializeField] HealthController healthController;
    [SerializeField] AbilitiesController abilitiesController;

    Animator animator;

    WarriorFieldController warriorFieldController;
    WarriorsInfoController warriorsInfoController;

    GameObject PositionField;

    bool isEnemy = false;
    bool isSelected = false;

    public GameObject GetPrefab() { return ModelPrefab; }

    public GameObject GetGameObject() { return gameObject; }

    public void SetEnemyStatus(bool isEnemy = true) { this.isEnemy = isEnemy; }
    public bool GetEnemyStatus() { return isEnemy; }

    public Sprite GetAvatar() { return Avatar; }
    public void SetAvatar(Sprite sprite) { Avatar = sprite; }

    public string GetWarriorName() { return Name; }
    public void SetWarriorName(string name) { Name = name; }

    public float GetHpCount() { return HP; }
    public void SetHpCount(float hp) { HP = hp; }

    public float GetDamageCount() { return damage; }
    public void SetDamageCount(float damage) { this.damage = damage; }

    public string GetSaText() { return Sa; }
    public void SetSaText(string text) { Sa = text; }

    public string GetUaText() { return Ua; }
    public void SetUaText(string text) { Ua = text; }

    public void SetWarriorFieldController(WarriorFieldController warriorFieldController)
    {
        this.warriorFieldController = warriorFieldController;
    }

    public void Select() { isSelected = true; }
    public void UnSelect() { isSelected = false; }
    public bool GetSelect() { return isSelected; }

    public void SetPositionField(GameObject PositionField)
    {
        gameObject.transform.SetParent(null);
        gameObject.transform.SetParent(PositionField.transform);

        this.PositionField = PositionField;
    }
    public GameObject GetPositionField() { return PositionField; }

    public void SetWarriorsInfoController(WarriorsInfoController warriorsInfoController) { this.warriorsInfoController = warriorsInfoController; }
    public WarriorsInfoController GetWarriorsInfoController() { return warriorsInfoController; }

    public AbilitiesController GetAbilityController() { return abilitiesController; }

    public void PlayAnimation(string name)
    {
        animator.Play(name);
    }

    private void OnMouseDown()
    {
        warriorsInfoController.OnWarriorClick(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeHit(IWarrior warrior)
    {
        warrior.TakeDamage(damage);
        abilitiesController.UpCounter();
    }

    public void MakeSa(IWarrior warrior)
    {
        warrior.TakeDamage(damage + 10);
        abilitiesController.TakeAwayAbilityPoint(abilitiesController.GetMaxAbilityPoints() / 2);
    }

    public void MakeUa(IWarrior warrior)
    {
        warrior.TakeDamage(damage + 50);
        abilitiesController.Reload();
    }

    public void TakeDamage(float damage)
    {
        healthController.Damage(damage);
        PlayAnimation("DamageVisual");
    }

    public void TakeEffect(IEffect effect)
    {

    }

    public void Die()
    {
        warriorFieldController.RemoveWarrior(this);
        warriorsInfoController.Clear();
    }
}
