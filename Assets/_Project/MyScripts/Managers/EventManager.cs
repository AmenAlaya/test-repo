using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Events
    [HideInInspector]
    public GameManagerEvents gameManagerEvents = new GameManagerEvents();
    [HideInInspector]
    public GameUIMangerEvents GameUIMangerEvents = new GameUIMangerEvents();
    #endregion
    #region Singleton
    public static EventManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion
}
