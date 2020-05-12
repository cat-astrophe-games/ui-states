using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Base class for UI states. */
public class UiState
{
    // Called by GameManager when the state becomes visible
    public virtual void Show()
    {

    }

    // Called by GameManager when the state stops being visible
    public virtual void Hide()
    {

    }

    // TODO: Pause(), Resume() methods, 
    // useful when state remains on state stack, but is no longer top-most,
    // when you use GameManager.PushState / PopState
}
