using System;
using TMPro;
using UnityEngine;

public class BuildingOutput : MonoBehaviour
{
    public RESOURCE resource;
    public int quantity = 0;
    public int maxResources = 100;
    
    [SerializeField] private TextMeshPro numberText;
    [SerializeField] private TextMeshPro resourceText;

    public bool isPiped = false;

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
            PipeManager.Instance.UpdatePipeOutput(GetComponent<BuildingOutput>());
            Debug.Log("Output Assigned");
            
            isPiped = true;
        }
    }
}
