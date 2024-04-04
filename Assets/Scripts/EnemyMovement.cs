using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform currentWaypoint;
    [SerializeField] private float speed;

    Animator animator;

    private EnemyStats stats;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        animator = GetComponentInChildren<Animator>();
        currentWaypoint = WaypointProvider.Instance.GetNextWaypoint();
    }

    IEnumerator RandomlyAttack() { 
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 8f));
            animator.SetInteger("State", 5);
        }
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
                Player.Instance.TakeDamage(stats.Damage);
                Destroy(gameObject);
            }
        }
    }
}
