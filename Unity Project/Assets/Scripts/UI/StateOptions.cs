using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOptions : UiState
{
    private bool backgroundVisible;
    private ViewOptions view;

    public StateOptions(bool backgroundVisible)
    {
        this.backgroundVisible = backgroundVisible;
    }

    public override void Show()
    {
        base.Show();
        view = GameManager.Instance.InstantiateUi<ViewOptions>("Options");
        view.buttonMoveRight.onClick.AddListener(ClickMoveRight);
        view.buttonMoveLeft.onClick.AddListener(ClickMoveLeft);
        view.buttonBack.onClick.AddListener(ClickBack);
        view.sampleDropdown.onValueChanged.AddListener(DropdownValueChanged);
        view.background.SetActive(backgroundVisible);

        // use OptionsBehaviour to listen to Unity events (updates, keypresses etc.)
        OptionsBehaviour optionsBehaviour = view.gameObject.AddComponent<OptionsBehaviour>();
        optionsBehaviour.state = this;
    }

    public override void Hide()
    {
        Object.Destroy(view.gameObject);
        base.Hide();
    }

    private void ClickMoveRight()
    {
        view.moveController.SetTrigger("right");
    }

    private void ClickMoveLeft()
    {
        view.moveController.SetTrigger("left");
    }

    private void DropdownValueChanged(int newValue)
    {
        Debug.Log("Now selected: " + newValue);
    }

    public void ClickBack()
    {
        GameManager.Instance.PopState(this);
    }
}
