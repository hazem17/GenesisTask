using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---- interface for every scripts that updates when the player sleeps
public interface iDay
{
    void NewDayStarted();
}

 
public class DayController : Singleton<DayController> , iDay
{

    private List<iDay> dayObjects;
    [SerializeField] private GameObject newDayPanel;
    // Start is called before the first frame update

    void Awake()
    {
        base.Awake();
        dayObjects = new List<iDay>();
    }
    public void Sleep()
    {
        for (int i = 0; i < dayObjects.Count; i++)
        {
            dayObjects[i].NewDayStarted();
        }
        newDayPanel.SetActive(true);
    }

    public void AddObjectToDayList(iDay day)
    {
        dayObjects.Add(day);
    }

    public void NewDayStarted()
    {
        print("New Day Started");
    }
}
