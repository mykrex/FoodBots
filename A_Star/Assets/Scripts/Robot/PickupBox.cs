using UnityEngine;

public class PickupBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Robot robot))
        {
            robot.GrabPayload();
            CountManager.Instance.IncrementBoxCount();
            Destroy(gameObject);
        }
    }
}