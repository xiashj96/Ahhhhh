using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player { Left, Right }

public class Throw : MonoBehaviour {

    public GameObject stuffPrefab;
    public Transform thrower1;
    public Transform thrower2;
    public Vector2 direction = new Vector2(1f, 1f);
    private Vector2 direction_inverted;
    public float forceMultiplier;

    void Start()
    {
        direction = direction.normalized;
        direction_inverted = new Vector2(-direction.x, direction.y);
    }

    public void ThrowStuff(float force, Player player)
    {
        if (player == Player.Left)
        {
            Instantiate<GameObject>(stuffPrefab, thrower1.transform.position, Quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        else
        {
            Instantiate<GameObject>(stuffPrefab, thrower2.transform.position, Quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(direction_inverted * force);
        }
    }
}
