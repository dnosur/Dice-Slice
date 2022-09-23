using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FieldController fieldController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + transform.up, transform.TransformDirection(Vector3.right +transform.up * -.8f), Color.red);
        Debug.DrawRay(transform.position + transform.up, transform.TransformDirection(Vector3.forward + transform.up * -.8f), Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.blue);
    }

    GameObject GetGround()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),out RaycastHit hit))
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    public void Move(int steps)
    {
        for(int i = 1; i <= steps; i++)
        {
            if (Physics.Raycast(transform.position + transform.up, transform.TransformDirection(Vector3.forward + transform.up * -.8f), out RaycastHit hit))
            {

                Debug.Log(hit.collider.name + " Move " + " pos " + hit.collider.bounds.max);
                transform.position = Vector3.Slerp(transform.position, new Vector3(hit.collider.bounds.center.x, transform.position.y, hit.collider.bounds.center.z), 1);
            }
            else
            {
                transform.eulerAngles += new Vector3(0, 90, 0);
                i--;
            }
        }

        fieldController.GetFieldAction(Convert.ToInt32(GetGround().transform.GetChild(0).GetComponent<TextMeshPro>().text));
    }
}
