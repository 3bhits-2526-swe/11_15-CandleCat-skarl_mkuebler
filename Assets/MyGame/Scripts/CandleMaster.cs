using UnityEngine;
using System.Collections.Generic;

public class CandleManager : MonoBehaviour
{
    public static CandleManager Instance;
    
    [Header("Einstellungen")]
    public int maxActiveCandles = 3;
    
    private List<RoomLogic> activeCandles = new List<RoomLogic>();

    void Awake()
    {
        Instance = this;
    }

    public void TryToggleCandle(RoomLogic room)
    {
        if (room.isCandleLit)
        {
            RemoveCandle(room);
        }
        else
        {
            if (activeCandles.Count >= maxActiveCandles)
            {
                RemoveCandle(activeCandles[0]);
            }
            
            room.SetCandleState(true);
            activeCandles.Add(room);
        }
    }

    public void RemoveCandle(RoomLogic room)
    {
        if (activeCandles.Contains(room))
        {
            room.SetCandleState(false);
            activeCandles.Remove(room);
        }
    }
}