using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightPreparationController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button ReadyButton;

    [Header("Controllers")]
    [SerializeField] WarriorFieldController warriorField;

    // Start is called before the first frame update
    void Start()
    {
        ReadyButton.onClick.AddListener(() =>
        {
            StartCoroutine(warriorField.LoadEnemys());
            warriorField.GetCameraAnimator().Play("StartFightCameraFlip");

            this.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
