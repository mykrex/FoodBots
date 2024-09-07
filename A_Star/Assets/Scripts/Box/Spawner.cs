using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mercanciaPrefab;
    private GameObject currentMercancia;
    private bool isSpawning = false;
    void Update()
    {
        if (currentMercancia == null && !isSpawning)
        {
            StartCoroutine(SpawnWithDelay(1.5f));
        }
    }

    private IEnumerator SpawnWithDelay(float delay)
    {
        isSpawning = true;
        yield return new WaitForSeconds(delay);
        currentMercancia = Instantiate(mercanciaPrefab, transform.position, Quaternion.identity);
        isSpawning = false;
    }
}
