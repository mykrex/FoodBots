using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    [SerializeField] GameObject boxVisual;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Robot robot))
        {
            if (robot.boxVisual.activeSelf)
            {
                StopAllCoroutines();
                StartCoroutine(WaitToHide());
                robot.DropPayload();
            }
        }
    }

    IEnumerator WaitToHide()
    {
        boxVisual.SetActive(true);
        yield return new WaitForSeconds(2f);
        boxVisual.SetActive(false);
    }
}
