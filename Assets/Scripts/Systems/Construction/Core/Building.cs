﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BuildingSystem/Create New Building")]
public class Building : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    public GameObject Prefab{get => prefab;}
    
    [SerializeField] private GameObject previewprefab;
    public GameObject Preview{get => previewprefab;}

    [SerializeField] private List<PlacementCondition> placementConditions= new List<PlacementCondition>();

    private ConstructionModule constructionManager; 


    private List<GameObject> instances = new List<GameObject>();

    [SerializeField]
    private float buildingRadiusMultiplier = 1f;


    private float checkRadius;
    public float Radius{get=>checkRadius;}


    private void OnEnable()
    {
        checkRadius = buildingRadiusMultiplier*previewprefab.GetComponent<SphereCollider>().radius;
    }

    public GameObject CreateInstance()
    {
        GameObject temp = GameObject.Instantiate(prefab);
        instances.Add(temp);
        return temp;
    }

    public void DestroyInstance(GameObject instance)
    {
        GameObject temp = instances.Find( x => x==instance);
        instances.Remove(instance);
        Destroy(temp);
    }

    public bool CheckPlacement(GameObject preview)
    {
        bool canPlace = true;
        foreach (var condition in placementConditions)
        {

            
            canPlace = canPlace &  condition.ConditionCheck(preview,this);
        }
        return canPlace;
    }
}
