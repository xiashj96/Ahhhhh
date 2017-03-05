using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    [SerializeField]
    private float destroyAfterSeconds;
    private void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
