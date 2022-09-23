using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private List<TextMeshPro> FieldsImpact;

    [Header("Materials")]
    [SerializeField] private List<Material> FieldMaterials;

    [Header("Field Controllers")]
    [SerializeField] WarriorFieldController warriorField;

    [Header("Buttons")]
    [SerializeField] Button DropCubeButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach(TextMeshPro textMesh in FieldsImpact)
        {
            int fieldId = (int)(Random.Range(1, 10));
            textMesh.text = (fieldId).ToString();

            SetField(ref fieldId, textMesh.transform.parent.gameObject);
        }

        GetFieldAction(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetField(ref int fieldId, GameObject fieldObj)
    {
        switch (fieldId)
        {
            case 6: //Поле боя
                {
                    fieldObj.GetComponent<Renderer>().material = FieldMaterials[0];
                };
                break;
        }
    }

    public void GetFieldAction(int fieldId)
    {
        switch (fieldId)
        {
            case 6:
                {
                    DropCubeButton.enabled = false;
                    StartCoroutine(warriorField.StartEvent());
                };
                break;
        }
    }
}
