using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private ScriptableEvent ColorChangeEvent;
    [SerializeField] private Button ColorChangeBtn;

    private void OnEnable()
    {
        ColorChangeBtn.onClick.AddListener(ChangeColor);
    }

    private void OnDisable()
    {
        ColorChangeBtn.onClick.RemoveListener(ChangeColor);
    }
    public void ChangeColor()
    {
        ColorChangeEvent.InvokeEvent();
    }
}
