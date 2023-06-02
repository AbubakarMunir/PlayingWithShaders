using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LitObject : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] private ColorHolder ColorHolder;
    [SerializeField] private ScriptableEvent ColorChangeEvent;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ColorChangeEvent.AddListener(ChangeShader);
    }

    private void OnDisable()
    {
        ColorChangeEvent.RemoveListener(ChangeShader);
    }
    public void ChangeShader()
    {
        meshRenderer.material = ColorHolder.IsEnabled ? ColorHolder.OffMaterial : ColorHolder.OnMaterial;
        ColorHolder.IsEnabled = !ColorHolder.IsEnabled;
    }


}
