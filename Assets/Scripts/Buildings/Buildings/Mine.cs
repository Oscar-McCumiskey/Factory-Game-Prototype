using UnityEngine;

public class Mine : BuildingBase
{
    [SerializeField] private RESOURCE resource;
    
    protected override void InitBuilding()
    {
        base.InitBuilding();
        
        outputs[0]._resource = resource;
    }

    protected override void UpdateProcess()
    {
        IsProcessing = true;
        
        base.UpdateProcess();

        if (IsFinished)
        {
            if (outputs[0]._quantity < maxResources) outputs[0]._quantity += 1;
            
            IsFinished = false;
        }
    }
}
