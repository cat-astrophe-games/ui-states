using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlay : UiState
{
    private ViewPlay view;
    private GameObject gameWorld;

    public override void Show()
    {
        base.Show();    
        view = GameManager.Instance.InstantiateUi<ViewPlay>("Play");

        string gameWorldPath = "Prefabs/PlayGameWorld";
        gameWorld = Resources.Load<GameObject>(gameWorldPath);
        if (gameWorld == null)
        { 
            throw new Exception("Missing play world: " + gameWorldPath);
        }
        UnityEngine.Object.Instantiate(gameWorld);
    }

    public override void Hide()
    {
        UnityEngine.Object.Destroy(view.gameObject);
        UnityEngine.Object.Destroy(gameWorld);
        base.Hide();
    }
}
