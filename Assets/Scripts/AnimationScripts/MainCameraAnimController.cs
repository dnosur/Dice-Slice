using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraAnimController : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject GameFieldCanvas;
    [SerializeField] GameObject FightPreparationCanvas;
    [SerializeField] GameObject MoveSideCanvas;

    void WarriorFieldLoadEnd()
    {
        GameFieldCanvas.SetActive(false);
        FightPreparationCanvas.SetActive(true);
    }

    void ShowSideCanvas() { MoveSideCanvas.gameObject.SetActive(true); }
}
