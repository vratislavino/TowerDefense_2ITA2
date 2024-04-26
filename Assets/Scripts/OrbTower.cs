using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTower : Tower
{
    public float Damage => damage;

    [SerializeField]
    private Transform rotatingPart;

    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotatingPart.Rotate(Vector3.forward, rotationSpeed);
    }
}
