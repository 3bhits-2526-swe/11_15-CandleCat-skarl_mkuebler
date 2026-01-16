using UnityEngine;
using TMPro;

public class RoomLogic : MonoBehaviour
{
    public float currentTemp = 25f;
    public bool isCandleLit = false;
    public float tempDropRate; 
    public float tempHeatRate = 1.2f;

    public TextMeshProUGUI tempDisplay;

    [Header("Visuals")]
    public GameObject unlightedVisual; 
    public GameObject lightedVisual;

    void Start()
    {
        tempDropRate = DifficultySettings.CurrentDropRate;
        
        UpdateVisuals(); 
    }

    void Update()
    {
        if (isCandleLit)
            currentTemp += (tempHeatRate - tempDropRate) * Time.deltaTime;
        else
            currentTemp -= tempDropRate * Time.deltaTime;

        currentTemp = Mathf.Clamp(currentTemp, 0, 40);
        if(tempDisplay != null) tempDisplay.text = currentTemp.ToString("F0") + "°C";

        if (currentTemp <= 0) {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }

    public void ToggleCandle()
    {
        CandleManager.Instance.TryToggleCandle(this);
    }

    private void OnMouseDown()
    {
        ToggleCandle();
    }

    public void SetCandleState(bool state)
    {
        Debug.Log($"SetCandleState wurde aufgerufen! Neuer Status: {state}");
        isCandleLit = state;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (lightedVisual != null) 
            lightedVisual.SetActive(isCandleLit);
            
        if (unlightedVisual != null) 
            unlightedVisual.SetActive(!isCandleLit);
    }
}