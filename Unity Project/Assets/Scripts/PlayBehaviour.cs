using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBehaviour : MonoBehaviour
{
    public StatePlay state;

    void Update()
    {
        // escape key invokes options
        if (Input.GetKeyDown(KeyCode.Escape) && 
            !(GameManager.Instance.TopMostState is StateOptions))
        {
            GameManager.Instance.PushState(new StateOptions(false));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.SetState(new StateMainMenu());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            state.ToggleMouseLook();
        }

        state.UpdateFps(1f / Time.unscaledDeltaTime);
    }
}
