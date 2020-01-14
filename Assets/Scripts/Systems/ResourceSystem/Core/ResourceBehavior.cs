﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehavior : MonoBehaviour
{    
    

    [SerializeField] public ResourceComponent resourceComponent;

    
    [SerializeField] private List<BehaviorDelegate> activate = new List<BehaviorDelegate>();
    [SerializeField] private List<BehaviorDelegate> activeLoop = new List<BehaviorDelegate>();
    [SerializeField] private List<BehaviorDelegate> deActivate = new List<BehaviorDelegate>();
    [SerializeField] private List<BehaviorDelegate> deActivatedLoop = new List<BehaviorDelegate>();
    [SerializeField] private List<BehaviorDelegate> onStart = new List<BehaviorDelegate>();
    [SerializeField] private List<BehaviorDelegate> onDestroy = new List<BehaviorDelegate>();

    delegate bool BehaviorMultiDelegate(GameObject ownerObject, MonoBehaviour script); 


    private BehaviorMultiDelegate activateDeligate;
    private BehaviorMultiDelegate activeLoopDelegate;
    private BehaviorMultiDelegate deActivateDelegate;
    private BehaviorMultiDelegate deActivatedLoopDelegate;
    private BehaviorMultiDelegate onStartDelegate;
    private BehaviorMultiDelegate onDestroyDelegate;

    public bool isActive = false;


    private bool emptydelegate(GameObject ownerObject, MonoBehaviour script)
    {
        return true;
    }

    private void OnEnable()
    {
        //initalize the delegates
        InitalizeDelegates();
 
        resourceComponent.resourceController.resourceNodes.Add(this);
        
    }


    private void InitalizeDelegates()
    {
        
        if (activate.Count != 0)
        {
            foreach (BehaviorDelegate newDel in activate)
            {
                activateDeligate += newDel.runDelegate;
            }
        }
        else
        {
            activateDeligate +=emptydelegate;
        }


        if (activeLoop.Count != 0)
        {
            foreach (BehaviorDelegate newDel in activeLoop)
            {
                activeLoopDelegate += newDel.runDelegate;
            }
        }
        else
        {
            activeLoopDelegate +=emptydelegate;
        }


        if (deActivate.Count != 0)
        {
            foreach (BehaviorDelegate newDel in deActivate)
            {
                deActivateDelegate += newDel.runDelegate;
            }
        }
        else
        {
            deActivateDelegate +=emptydelegate;
        }



        if (deActivatedLoop.Count != 0)
        {
            foreach (BehaviorDelegate newDel in deActivatedLoop)
            {
                deActivatedLoopDelegate += newDel.runDelegate;
            }
        }
        else
        {
            deActivatedLoopDelegate +=emptydelegate;
        }


        if (onStart.Count != 0)
        {
            foreach (BehaviorDelegate newDel in onStart)
            {
                onStartDelegate += newDel.runDelegate;
            }
        }
        else
        {
            onStartDelegate +=emptydelegate;
        }


        if (onDestroy.Count != 0)
        {
            foreach (BehaviorDelegate newDel in onDestroy)
            {
                onDestroyDelegate += newDel.runDelegate;
            }
        }
        else
        {
            onDestroyDelegate +=emptydelegate;
        }


    }

    private void Start()
    {
        onStartDelegate(gameObject,this);
    }

    private void Update()
    {
        if (isActive)
        {
            activeLoopDelegate(gameObject, this);
        }
        else 
        {
            deActivatedLoopDelegate(gameObject, this);
        }
    }

    public void Activate()
    {
        if (isActive) return;
        activateDeligate(gameObject, this);
        isActive = true;
    }

    public void DeActivate()
    {
        if (!isActive) return;
        deActivateDelegate(gameObject, this);
        isActive = false;
    }


    private void OnDestroy()
    {
        onDestroyDelegate(gameObject, this);
    }


}
