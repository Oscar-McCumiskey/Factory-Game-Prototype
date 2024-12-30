using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    [SerializeField] protected BuildingInput[] inputs;
    [SerializeField] protected BuildingOutput[] outputs;

    [SerializeField] private float processingTime = 1;
    private float _processingTimeCounter;
    protected bool IsProcessing = false;
    protected bool IsFinished = false;

    private void Start()
    {
        _processingTimeCounter = processingTime;
        
        InitBuilding();
    }

    private void Update()
    {
        UpdateProcess();
    }

    protected virtual void InitBuilding() {}
    
    protected virtual void UpdateProcess()
    {
        if (IsProcessing)
        {
            // continue crafting process
            _processingTimeCounter -= Time.deltaTime;

            if (_processingTimeCounter <= 0)
            {
                // finish crafting
                IsProcessing = false;
                IsFinished = true;
                
                _processingTimeCounter = processingTime;
            }
        }
        else
        {
            // reset process timer
            _processingTimeCounter = processingTime;
        }
    }
}
