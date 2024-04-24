using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTower : MonoBehaviour
{
    [SerializeField]
    protected int damage;

    public float Damage => damage;

    [SerializeField]
    private Transform rotatingPart;

    [SerializeField]
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotatingPart.Rotate(Vector3.forward, rotationSpeed);
    }
}
