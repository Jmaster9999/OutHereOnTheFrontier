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

    private ConstructionModule constructionManager; 

}
