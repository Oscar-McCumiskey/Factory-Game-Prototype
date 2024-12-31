using System;
using TMPro;
using UnityEngine;

public class BuildingOutput : MonoBehaviour
{
    public RESOURCE resource;
    public int quantity = 0;
    public int maxResources = 100;
    
    private RESOURCE _lastFrameResource = RESOURCE.EMPTY;
    
    [SerializeField] private TextMeshPro numberText;
    [SerializeField] private TextMeshPro resourceText;

    public bool isPiped = false;

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        if (_lastFrameResource != resource)
        {
            quantity = 0;
        }
        
        _lastFrameResource = resource;
        
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
            PipeManager.Instance.UpdatePipeOutput(GetComponent<BuildingOutput>());
            Debug.Log("Output Assigned");
            
            isPiped = true;
        }
    }
}
