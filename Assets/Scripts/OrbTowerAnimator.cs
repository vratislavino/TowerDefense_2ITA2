using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTowerAnimator : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DoSecondAnimation());
    }

    IEnumerator DoSecondAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f,8f));
            animator.SetTrigger("dosth");
        }
    }
}
