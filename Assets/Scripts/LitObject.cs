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
        Material mat = meshRenderer.material;
        float currentState = mat.GetFloat("_StateProperty");
        float newState = currentState == 0 ? 1 : 0;
        mat.SetFloat("_StateProperty", newState);
    }


}
