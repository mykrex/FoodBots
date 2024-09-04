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
            Debug.Log($"Caja: {boxVisual.activeSelf}, Robot: {robot.boxVisual.activeSelf}");

            if (boxVisual.activeSelf && !robot.boxVisual.activeSelf)
            {
                boxVisual.SetActive(false);
                robot.GrabPayload();
                Debug.Log("Caja desactivada y robot ha agarrado la caja");
            }
            else if (!boxVisual.activeSelf && robot.boxVisual.activeSelf)
            {
                boxVisual.SetActive(true);
                robot.DropPayload();
                Debug.Log("Caja activada y robot ha soltado la caja");
            }
        }
    }


}
