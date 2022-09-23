using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropCubeButton : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshPro GameCubeText;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => 
        {
            int steps = Random.Range(1, 6);
            GameCubeText.text = steps.ToString();

            player.Move(steps);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
