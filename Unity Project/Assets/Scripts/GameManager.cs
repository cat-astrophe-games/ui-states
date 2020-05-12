using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private List<UiState> stateStack = new List<UiState>();

    public Canvas MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            throw new Exception("Multiple instances of GameManager not allowed");
        }
        instance = this;

        // initial state
        SetState(new StateMainMenu());
    }

    public T InstantiateUi<T>(string prefabName)
    {
        string resourcePath = "Prefabs/UI/" + prefabName;
        GameObject template = Resources.Load<GameObject>(resourcePath);
        if (template == null)
        {
            throw new Exception("Missing resource: " + resourcePath);
        }

        GameObject viewGameObject = Instantiate(template, MainCanvas.transform);
        T view = viewGameObject.GetComponent<T>();
        if (view == null)
        {
            throw new Exception("Missing component in view");
        }

        RectTransform viewTransform = viewGameObject.transform as RectTransform;
        viewTransform.offsetMin = Vector2.zero;
        viewTransform.offsetMax = Vector2.zero;

        return view;
    }

    /* Make the newState the *only* visible UI state. */
    public void SetState(UiState newState)
    {
        for (int i = stateStack.Count - 1; i >= 0; i--)
        {
            stateStack[i].Hide();
        }
        stateStack.Clear();
        stateStack.Add(newState);
        newState.Show();
    }

    /* Make the newState the new top-most state, on top of current states. */
    public void PushState(UiState newState)
    {
        stateStack.Add(newState);
        newState.Show();
    }

    /* Pop the top-most state, making sure it is previousState. */
    public void PopState(UiState previousState)
    {
        if (stateStack.Count == 0)
        {
            throw new Exception("Cannot call PopState when no states are currently visible");
        }
        if (stateStack.Last() != previousState)
        { 
            throw new Exception("PopState called but top-most state has unexpected value: " + previousState.GetType());
        }
        stateStack.RemoveAt(stateStack.Count - 1);
        previousState.Hide();
    }
}
