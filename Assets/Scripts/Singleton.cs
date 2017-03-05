using UnityEngine;
using System.Collections;

/// <summary>
/// Generic Singleton
/// To use it, simply derive it and attach it to its own game object
/// Note: you must call base.Awake() in Awake()
/// </summary>
/// <typeparam name="T"></typeparam>

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                if (Debug.isDebugBuild)
                {
                    Debug.LogError("There is no " + typeof(T).Name + " in the scene!");
                }
                return null;
            }
            else return _instance;
        }
    }
    private static T _instance;

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            //DontDestroyOnLoad(this);
        }
        else
        {
            if (Debug.isDebugBuild)
            {
                Debug.LogWarning("There are more than one " + typeof(T).Name + " in the scene!");
            }
            Destroy(gameObject);
        }
    }
}
