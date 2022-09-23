using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPrefabCollection : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] List<GameObject> WarriorPrefabs;

    public GameObject GetPrefabByClass(ref IWarrior warrior)
    {
        foreach(GameObject obj in WarriorPrefabs)
        {
            if (obj.name == warrior.GetType().ToString())
            {
                return obj;
            }
        }

        return null;
    }

    public IWarrior LoadWarrior(IWarrior warrior, GameObject position, bool isEnemy = false)
    {
        warrior = Instantiate(GetPrefabByClass(ref warrior)).GetComponent<IWarrior>();
        warrior.SetPositionField(position);
        warrior.SetEnemyStatus(isEnemy);

        return warrior;
    }

    public IWarrior LoadWarrior(IWarrior warrior, GameObject position, WarriorFieldController warriorFieldController,WarriorsInfoController warriorsInfoController, bool isEnemy = false)
    {
        warrior = Instantiate(GetPrefabByClass(ref warrior)).GetComponent<IWarrior>();
        warrior.SetPositionField(position.gameObject);

        warrior.SetWarriorFieldController(warriorFieldController);
        warrior.SetWarriorsInfoController(warriorsInfoController);
        warrior.SetEnemyStatus(isEnemy);

        return warrior;
    }

    public List<IWarrior> LoadWarriors(List<IWarrior> warriors, ref List<GameObject> Positions,
                                         WarriorFieldController warriorFieldController, WarriorsInfoController warriorsInfoController, bool isEnemy = false)
    {
        for(int i = 0; i < Positions.Count; i++)
        {
            warriors[i] = LoadWarrior(warriors[i], Positions[i], warriorFieldController, warriorsInfoController);
            warriors[i].SetEnemyStatus(isEnemy);
        }

        return warriors;
    }
}
