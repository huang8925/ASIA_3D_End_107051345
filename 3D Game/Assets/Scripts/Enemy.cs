﻿using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 3f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    public float cd = 2f;

    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        player = GameObject.Find("機器人").transform;
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        Track();
        Attack();
    }

    private void Attack()
    {
        if (nav.remainingDistance < stopDistance)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);

            if (timer >= cd)
            {
                ani.SetTrigger("Basic Attack");
                timer = 0; 
            }
         
        }
    }

    private void Track()
    {
        nav.SetDestination(player.position);

        print("剩餘的距離：" + nav.remainingDistance);
        ani.SetBool("跑", nav.remainingDistance > stopDistance);
    }
}
