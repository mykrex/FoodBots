using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountManager : MonoBehaviour
{
    public static CountManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI boxCountText;
    private int boxesCollected = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementBoxCount()
    {
        boxesCollected++;
        UpdateBoxCountDisplay();
    }

    private void UpdateBoxCountDisplay()
    {
        boxCountText.text = $"Cajas recogidas: {boxesCollected}";
    }
}