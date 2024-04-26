using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField]
    private List<Tower> towerPrefabs;

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
        if (towersInRange.Length > 0)
        {
            Debug.Log(string.Join(", ", towersInRange.Select(t => t.gameObject.name)));
        }
        return towersInRange.Length == 0;
        
    }

    private void CreateTower(Vector2 point)
    {
        Instantiate(towerPrefabs[UnityEngine.Random.Range(0, towerPrefabs.Count)], point, Quaternion.identity);
    }
}
