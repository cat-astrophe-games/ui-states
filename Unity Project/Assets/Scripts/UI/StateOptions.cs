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
        view.buttonOption1.onClick.AddListener(ClickOption1);
        view.buttonOption2.onClick.AddListener(ClickOption2);
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

    private void ClickOption1()
    {
        Debug.Log("Option 1");
    }

    private void ClickOption2()
    {
        Debug.Log("Option 2");
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
