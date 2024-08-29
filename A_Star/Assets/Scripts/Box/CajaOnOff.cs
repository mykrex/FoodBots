using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaOnOff : MonoBehaviour
{
    [SerializeField] GameObject boxVisual;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Robot robot))
        {
            if(boxVisual.activeSelf && !robot.boxVisual.activeSelf)
            {
                boxVisual.SetActive(false);
                robot.GrabPayload();
            }
            if (!boxVisual.activeSelf && robot.boxVisual.activeSelf)
            {
                boxVisual.SetActive(true);
                robot.DropPayload();
            }
        }
    }

}
