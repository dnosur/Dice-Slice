using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorFieldController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Animator CameraAnimator;

    [Header("Positions")]
    [SerializeField] List<GameObject> PlayerPosition;
    [SerializeField] List<GameObject> EnemysPosition;

    [Header("WarriorPrefabCollection")]
    [SerializeField] WarriorPrefabCollection warriorPrefabCollection;

    [Header("Warrior Info")]
    [SerializeField] WarriorsInfoController warriorsInfoController;

    [Header("Text")]
    [SerializeField] Text MoveText;
    [SerializeField] Text GameEndText;

    PlayerWarriorsCollection playerWarriorsCollection;

    bool isGameStarted = false;
    bool isPlayerMoves = true;
    bool isWin = false;

    List<IWarrior> Enemys = new List<IWarrior>
    {
        new StandartWarrior(),
        new StandartWarrior(),
        new LittleWarrior(),
        new LittleWarrior(),
        new StandartWarrior()
    };

    // Start is called before the first frame update
    void Start()
    {
        playerWarriorsCollection = new PlayerWarriorsCollection();
        playerWarriorsCollection.BaseInitialization();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted && !isPlayerMoves)
        {

        }
    }

    public IEnumerator StartEvent()
    {
        playerWarriorsCollection.PlayerWarriors = warriorPrefabCollection.LoadWarriors(playerWarriorsCollection.PlayerWarriors, ref PlayerPosition, this, warriorsInfoController);

        yield return new WaitForSeconds(2);
        CameraAnimator.Play("WarriorFieldLoad");
    }

    public IEnumerator LoadEnemys()
    {
        Enemys = warriorPrefabCollection.LoadWarriors(Enemys, ref EnemysPosition, this, warriorsInfoController, true);
        isGameStarted = true;
        Debug.Log("!!!");

        yield return true;
    }

    public void ChangePos(IWarrior firstWarrior, IWarrior secondWarrior)
    {
        GameObject firstWarriorPosTemp = firstWarrior.GetPositionField();

        firstWarrior.SetPositionField(secondWarrior.GetPositionField());
        secondWarrior.SetPositionField(firstWarriorPosTemp);

        IWarrior t_warrior = playerWarriorsCollection.PlayerWarriors[Convert.ToInt32(firstWarrior.GetPositionField().name) - 1];
        playerWarriorsCollection.PlayerWarriors[Convert.ToInt32(firstWarrior.GetPositionField().name) - 1] = playerWarriorsCollection.PlayerWarriors[Convert.ToInt32(secondWarrior.GetPositionField().name) - 1];
        playerWarriorsCollection.PlayerWarriors[Convert.ToInt32(secondWarrior.GetPositionField().name) - 1] = t_warrior;

        warriorsInfoController.Clear();
    }

    public void ChangeMovementSide()
    {
        if (isPlayerMoves)
        {
            MoveText.text = "Ход противника";
            MoveText.color = new Color(0.5943396f, 0.1146334f, 0.06448025f, 1);
            isPlayerMoves = false;
        }
        else
        {
            MoveText.text = "Ваш ход";
            MoveText.color = new Color(0.2052213f, 0.490566f, 0.1133856f, 1);
            isPlayerMoves = true;
        }
    }

    public void RemoveWarrior(IWarrior warrior)
    {
        if (!warrior.GetEnemyStatus())
        {
            playerWarriorsCollection.PlayerWarriors.Remove(warrior);
        }
        else Enemys.Remove(warrior);

        Destroy(warrior.GetGameObject());

        if(playerWarriorsCollection.PlayerWarriors.Count <= 0) 
        {

        }
        else if(Enemys.Count <= 0)
        {
            isWin = true;
            isGameStarted = false;
            isPlayerMoves = true;
        }
    }

    public bool IsGameStarted() { return isGameStarted; }
    public bool IsPlayerMove() { return isPlayerMoves; }
    public bool IsWin() { return isWin; }

    public Animator GetCameraAnimator() { return CameraAnimator; }

    public List<IWarrior> GetEnemys() { return Enemys; }
}
