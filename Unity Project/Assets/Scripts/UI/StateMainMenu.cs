using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMainMenu : UiState
{
    private ViewMainMenu view;

    public override void Show()
    {
        base.Show();
        view = GameManager.Instance.InstantiateUi<ViewMainMenu>("MainMenu");
        view.buttonOptions.onClick.AddListener(ClickOptions);
        view.buttonPlay.onClick.AddListener(ClickPlay);
    }

    public override void Hide()
    {
        Object.Destroy(view.gameObject);
        base.Hide();
    }

    private void ClickOptions()
    {
        GameManager.Instance.PushState(new StateOptions(true));
    }

    private void ClickPlay()
    {
        GameManager.Instance.SetState(new StatePlay());
    }
}
