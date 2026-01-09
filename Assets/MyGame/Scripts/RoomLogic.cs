using UnityEngine;
using TMPro;

public class RoomLogic : MonoBehaviour
{
    [Header("Status")]
    public float currentTemp = 24f;
    public bool isCandleLit = false;

    [Header("Balancing (wird vom Schwierigkeitsgrad gesteuert)")]
    public float tempDropRate = 0.5f;
    public float tempHeatRate = 1.0f;

    [Header("Referenzen")]
    public TextMeshProUGUI tempDisplay;
    public GameObject candleVisual;

    void Update()
    {
        if (isCandleLit)
        {
            currentTemp += (tempHeatRate - tempDropRate) * Time.deltaTime;
        }
        else
        {
            currentTemp -= tempDropRate * Time.deltaTime;
        }

        currentTemp = Mathf.Clamp(currentTemp, 0, 40);
        if(tempDisplay != null) 
            tempDisplay.text = currentTemp.ToString("F1") + "°C";

        if (currentTemp <= 0)
        {
            Debug.Log("Katze erfroren! Spiel vorbei.");
        }
    }

    private void OnMouseDown() 
    {
        CandleManager.Instance.TryToggleCandle(this);
    }

    public void SetCandleState(bool state)
    {
        isCandleLit = state;
        if(candleVisual != null) candleVisual.SetActive(state);
    }
}