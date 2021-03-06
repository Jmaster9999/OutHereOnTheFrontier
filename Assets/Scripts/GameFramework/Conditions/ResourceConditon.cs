﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameFramework/Conditions/Resource Condition")]
public class ResourceConditon : ConditionScript
{
    [SerializeField] private Resource resourceToCheck;
    [SerializeField] private float amount;
    [SerializeField] private bool RoundToLower = true;
    [SerializeField] public ResourceModule resourceModule;
    
    public override bool ConditionCheck(ScriptableObject callingObject)
    {
        float returnvalue = resourceModule.GetResourceStorage(resourceToCheck);

        if (RoundToLower) return Mathf.Floor(returnvalue) >= amount;
        return returnvalue >= amount;
    }
}
