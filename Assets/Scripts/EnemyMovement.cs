using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform currentWaypoint;
    [SerializeField] private float speed;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentWaypoint = WaypointProvider.Instance.GetNextWaypoint();
    }

    void Update()
    {
        var direction = currentWaypoint.position - transform.position;
        var movement = direction.normalized * speed * Time.deltaTime;
        
        if(movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetInteger("State", 2);
        transform.Translate(movement);

        if(Vector3.Distance(currentWaypoint.position, transform.position) < 0.01f)
        {
            currentWaypoint = WaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
            if(currentWaypoint == null)
            {
                // TODO - odebrat hráèi HP?
                Destroy(gameObject);
            }
        }
    }
}
