﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "GameFramework/Gamestate/MainMenu")]
public class MenuState : GameState
{
    [SerializeField]
    GameManager Game;

    [SerializeField] private GameState playState;


    [SerializeField] private ScriptedCamera menuCamData;

    [SerializeField] private CameraModule camModule;

    //private ScriptedCamera MenuCam;
    
    public override void OnActivate(GameState lastState)
    {
        if (lastState == playState)
        {
            SceneManager.UnloadSceneAsync(sceneName:"Main");
            SceneManager.LoadScene(sceneName:"MainMenu");
        }
        
        
        Game.Pause();

        //MenuCam = camModule.AddScriptedCameraInstance(menuCamData);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnDeactivate(GameState newState)
    {
        if (newState == playState)
        {
           SceneManager.LoadSceneAsync(sceneName:"Main");
          SceneManager.UnloadSceneAsync(sceneName:"MainMenu");
        }
        
        Game.UnPause();
    }
}
