using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StatePlay : UiState
{
    private ViewPlay view;
    private GameObject gameWorldInstance;
    private ViewPlayGameWorld viewGameWorld;
    private bool mouseLook = false;

    public override void Show()
    {
        base.Show();    
        view = GameManager.Instance.InstantiateUi<ViewPlay>("Play");

        string gameWorldPath = "Prefabs/PlayGameWorld";
        GameObject gameWorld = Resources.Load<GameObject>(gameWorldPath);
        if (gameWorld == null)
        { 
            throw new Exception("Missing play world: " + gameWorldPath);
        }
        gameWorldInstance = UnityEngine.Object.Instantiate(gameWorld);

        viewGameWorld = gameWorldInstance.GetComponent<ViewPlayGameWorld>();

        // use PlayBehaviour to listen to Unity events (updates, keypresses etc.)
        PlayBehaviour playBehaviour = gameWorldInstance.AddComponent<PlayBehaviour>();
        playBehaviour.state = this;
    }

    public override void Hide()
    {
        UnityEngine.Object.Destroy(view.gameObject);
        UnityEngine.Object.Destroy(gameWorldInstance);
        base.Hide();
    }

    public void UpdateFps(float thisFrameFps)
    {
        // TODO: we could average last 1 second or such measurements
        view.textFps.text = "FPS: " + thisFrameFps;
    }

    public void ToggleMouseLook()
    {
        mouseLook = !mouseLook;
        viewGameWorld.fpsController.SetMouseLook(mouseLook);
    }
}
