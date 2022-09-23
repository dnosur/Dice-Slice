using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorsInfoController : MonoBehaviour
{
    [Header("Backgrounds")]
    [SerializeField] GameObject FirtsWarriorBackground;
    [SerializeField] GameObject SecondWarriorBackground;

    [Header("Background Controllers")]
    [SerializeField] WarriorInfoBackground FirstWarriorInfoBackground;
    [SerializeField] WarriorInfoBackground SecondWarriorInfoBackground;

    [Header("FieldControllers")]
    [SerializeField] WarriorFieldController warriorFieldController;

    // Start is called before the first frame update
    void Start()
    {
        FirstWarriorInfoBackground.clearHandler = Clear;
        SecondWarriorInfoBackground.clearHandler = Clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {
        FirstWarriorInfoBackground.InactiveAllButtons();

        UnSelectAll();
    }

    public void OnWarriorClick(IWarrior warrior)
    {
        if (!warrior.GetSelect() && FirtsWarriorBackground.activeInHierarchy && SecondWarriorBackground.activeInHierarchy)
        {
            FirstWarriorInfoBackground.InactiveChangeButton();
            UnSelect(ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
        }

        if (!warriorFieldController.IsGameStarted())
        {
            if (!warrior.GetSelect())
            {
                if (!FirtsWarriorBackground.activeInHierarchy)
                {
                    ShowInfo(warrior, ref FirstWarriorInfoBackground, ref FirtsWarriorBackground);
                }
                else
                {
                    ShowInfo(warrior, ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
                }
            }
            else
            {
                if (FirstWarriorInfoBackground.GetWarrior() == warrior)
                {
                    UnSelectAll();
                }
                else
                {
                    FirstWarriorInfoBackground.InactiveChangeButton();
                    UnSelect(ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
                }
            }
        }
        else
        {
            Debug.Log("Game Started");
            if (!warrior.GetSelect())
            {
                if (!FirtsWarriorBackground.activeInHierarchy && !SecondWarriorBackground.activeInHierarchy)
                {
                    if (!warrior.GetEnemyStatus())
                    {
                        ShowInfo(warrior, ref FirstWarriorInfoBackground, ref FirtsWarriorBackground);
                    }
                    else
                    {
                        ShowInfo(warrior, ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
                    }
                }
                else if (FirtsWarriorBackground.activeInHierarchy && !SecondWarriorBackground.activeInHierarchy)
                {
                    if (!FirstWarriorInfoBackground.GetWarrior().GetEnemyStatus() && warrior.GetEnemyStatus())
                    {
                        FirstWarriorInfoBackground.InactiveAllButtons();
                        ShowInfo(warrior, ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
                    }
                    else if (!warrior.GetEnemyStatus())
                    {
                        ShowInfo(warrior, ref FirstWarriorInfoBackground, ref FirtsWarriorBackground);
                    }
                }
                else if (!FirtsWarriorBackground.activeInHierarchy && SecondWarriorBackground.activeInHierarchy)
                {
                    if (SecondWarriorInfoBackground.GetWarrior().GetEnemyStatus() && !warrior.GetEnemyStatus())
                    {
                        ShowInfo(warrior, ref FirstWarriorInfoBackground, ref FirtsWarriorBackground);
                    }
                    else if (warrior.GetEnemyStatus())
                    {
                        ShowInfo(warrior, ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
                    }
                }
            }
            else
            {
                if(FirtsWarriorBackground.activeInHierarchy && SecondWarriorBackground.activeInHierarchy)
                {
                    FirstWarriorInfoBackground.InactiveAllButtons();
                }

                if (FirtsWarriorBackground.activeInHierarchy && FirstWarriorInfoBackground.GetWarrior() == warrior)
                {
                    UnSelect(ref FirstWarriorInfoBackground, ref FirtsWarriorBackground);
                }
                else UnSelect(ref SecondWarriorInfoBackground, ref SecondWarriorBackground);
            }
        }
    }

    void ShowInfo(IWarrior warrior, ref WarriorInfoBackground warriorInfoBackground, ref GameObject Background)
    {
        warriorInfoBackground.SetAvatar(warrior.GetAvatar());
        warriorInfoBackground.SetWarriorName(warrior.GetWarriorName());
        warriorInfoBackground.SetHpCount(warrior.GetHpCount());
        warriorInfoBackground.SetDamageCount(warrior.GetDamageCount());
        warriorInfoBackground.SetSaText(warrior.GetSaText());
        warriorInfoBackground.SetUaText(warrior.GetUaText());

        warriorInfoBackground.SetWarrior(warrior);
        Background.SetActive(true);

        warrior.Select();

        if(FirtsWarriorBackground.activeInHierarchy && SecondWarriorBackground.activeInHierarchy)
        {
            if (!warriorFieldController.IsGameStarted())
            {
                FirstWarriorInfoBackground.SetChangeButtonActive(warriorFieldController.ChangePos, 
                                                                FirstWarriorInfoBackground.GetWarrior(), 
                                                                SecondWarriorInfoBackground.GetWarrior());
            }
            else
            {
                FirstWarriorInfoBackground.SetHitButtonActive(FirstWarriorInfoBackground.GetWarrior().MakeHit, warriorFieldController.ChangeMovementSide, SecondWarriorInfoBackground.GetWarrior());
                FirstWarriorInfoBackground.SetSaButtonActive(FirstWarriorInfoBackground.GetWarrior().MakeSa, warriorFieldController.ChangeMovementSide, SecondWarriorInfoBackground.GetWarrior());
                FirstWarriorInfoBackground.SetUaButtonActive(FirstWarriorInfoBackground.GetWarrior().MakeUa, warriorFieldController.ChangeMovementSide, SecondWarriorInfoBackground.GetWarrior());
            }

            Comparison();

            Debug.Log(warrior.GetWarriorName());
        }
    }

    void UnSelect(ref WarriorInfoBackground warriorInfoBackground, ref GameObject Background)
    {
        warriorInfoBackground.GetWarrior().UnSelect();
        Background.SetActive(false);
        ResetComparison();
    }

    void UnSelectAll()
    {
        Debug.Log("UnselectAll");

        if (FirtsWarriorBackground.activeInHierarchy)
        {
            FirstWarriorInfoBackground.InactiveAllButtons();

            FirstWarriorInfoBackground.GetWarrior().UnSelect();
            FirtsWarriorBackground.SetActive(false);
        }

        if (SecondWarriorBackground.activeInHierarchy)
        {
            SecondWarriorInfoBackground.GetWarrior().UnSelect();
            SecondWarriorBackground.SetActive(false);
        }

        ResetComparison();
    }

    void Comparison()
    {
        if(FirstWarriorInfoBackground.GetHpCount() > SecondWarriorInfoBackground.GetHpCount())
        {
            FirstWarriorInfoBackground.SetHpCountColor(Color.green);
            SecondWarriorInfoBackground.SetHpCountColor(Color.red);
        }
        else if (FirstWarriorInfoBackground.GetHpCount() < SecondWarriorInfoBackground.GetHpCount())
        {
            FirstWarriorInfoBackground.SetHpCountColor(Color.red);
            SecondWarriorInfoBackground.SetHpCountColor(Color.green);
        }

        if (FirstWarriorInfoBackground.GetDamageCount() > SecondWarriorInfoBackground.GetDamageCount())
        {
            FirstWarriorInfoBackground.SetDamageCountColor(Color.green);
            SecondWarriorInfoBackground.SetDamageCountColor(Color.red);
        }
        else if (FirstWarriorInfoBackground.GetDamageCount() < SecondWarriorInfoBackground.GetDamageCount())
        {
            FirstWarriorInfoBackground.SetDamageCountColor(Color.red);
            SecondWarriorInfoBackground.SetDamageCountColor(Color.green);
        }
    }

    void ResetComparison()
    {
        FirstWarriorInfoBackground.SetHpCountColor(Color.black);
        SecondWarriorInfoBackground.SetHpCountColor(Color.black);

        FirstWarriorInfoBackground.SetDamageCountColor(Color.black);
        SecondWarriorInfoBackground.SetDamageCountColor(Color.black);
    }
}
