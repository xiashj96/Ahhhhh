using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    private AreaEffector2D ae;
    private Transform flag;

    private void Awake()
    {
        ae = GetComponent<AreaEffector2D>();
        flag = transform.GetChild(0);
    }


    public void SetWindDirection(float angle)
    {
        Debug.LogFormat("Wind angle:{0}", angle);
        ae.forceAngle = angle;
        flag.eulerAngles = new Vector3(0, 0, angle - 90);
    }
}
