using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField]
    private Tower towerPrefab;

    Camera cam;

    [SerializeField]
    private LayerMask constructionLayermask;
    [SerializeField]
    private LayerMask towerLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, 20, constructionLayermask);
            if (hit)
            {
                if(CheckPlace(hit.point))
                CreateTower(hit.point);
            }
        }
    }

    private bool CheckPlace(Vector2 point)
    {
        var towersInRange = Physics2D.OverlapCircleAll(point, 1.2f, towerLayerMask);
        return towersInRange.Length == 0;
        
    }

    private void CreateTower(Vector2 point)
    {
        Instantiate(towerPrefab, point, Quaternion.identity);
    }
}
