using UnityEngine;

public class Mine : BuildingBase
{
    [SerializeField] private RESOURCE resource;
    
    protected override void InitBuilding()
    {
        base.InitBuilding();
        
        outputs[0].resource = resource;
    }

    protected override void UpdateProcess()
    {
        IsProcessing = true;
        
        base.UpdateProcess();

        if (IsFinished)
        {
            // add resource
            if (outputs[0].quantity < outputs[0].maxResources) outputs[0].quantity += 1;
            
            IsFinished = false;
            
            // update text
            outputs[0].UpdateText();
        }
    }
}
