using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Players { Left, Right }

public enum Stuffs { Shit, Fish, Sword, Ball }

public class Player : MonoBehaviour {


    private Animator anim;
    public int HP = 10;
    public GameObject shitPrefab;
    public GameObject fishPrefab;
    public GameObject swordPrefab;
    public GameObject ballPrefab;

    public Players who;

    public Transform thrower;

    public Vector2 direction = new Vector2(1f, 1f);
    public float forceMultiplier;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ThrowStuff(float force, Stuffs stuff)
    {
        // 扔东西
        Debug.LogFormat("Player {0} throws stuff with force {1}", (who == Players.Left) ? 1 : 2, force);
        GameObject stuffPrefab;
        switch (stuff)
        {
            case Stuffs.Ball: stuffPrefab = ballPrefab; break;
            case Stuffs.Fish: stuffPrefab = fishPrefab; break;
            case Stuffs.Sword: stuffPrefab = swordPrefab; break;
            case Stuffs.Shit: stuffPrefab = shitPrefab; break;
            default: stuffPrefab = null; break;
        }

        Instantiate<GameObject>(stuffPrefab, thrower.transform.position, Quaternion.identity)
            .GetComponent<Rigidbody2D>().AddForce(direction * ((force + 0.1f) / 1.1f * forceMultiplier));

        // 动画
        anim.SetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        UIManager.instance.UpdateHP(Mathf.Max(0, HP), who);
        if (HP <= 0)
        {
            anim.SetTrigger("Die");
        }
        else
            anim.SetTrigger("Hurt");
    }
}
