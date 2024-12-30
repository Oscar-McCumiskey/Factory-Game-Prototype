using System;
using TMPro;
using UnityEngine;

public class BuildingInput : MonoBehaviour
{
    public RESOURCE resource;
    public int quantity = 0;
    public int maxQuantity = 100;
    
    [SerializeField] private TextMeshPro numberText;
    [SerializeField] private TextMeshPro resourceText;

    public bool isPiped;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        numberText.text = quantity.ToString();
        resourceText.text = resource.ToString();
    }

    private void OnMouseDown()
    {
        if (!isPiped)
        {
            PipeManager.Instance.UpdatePipeInput(GetComponent<BuildingInput>());
            Debug.Log("Input Assigned");
            
            isPiped = true;
        }
    }
}
