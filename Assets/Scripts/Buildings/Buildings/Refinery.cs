using UnityEngine;

public class Refinery : BuildingBase
{
    protected override void InitBuilding()
    {
        base.InitBuilding();
    }

    protected override void UpdateProcess()
    {
        // check valid resources
        if (inputs[0]._resource == RESOURCE.COAL && inputs[1]._resource == RESOURCE.IRON)
        {
            // check valid quantity
            if (inputs[0]._quantity > 0 && inputs[1]._quantity > 0)
            {
                IsProcessing = true;
            }
        }
        
        base.UpdateProcess();

        if (IsFinished)
        {
            // adjust input and output values
            inputs[0]._quantity -= 1;
            inputs[1]._quantity -= 1;
            
            outputs[0]._resource = RESOURCE.STEEL;
            if (outputs[0]._quantity < maxResources) outputs[0]._quantity += 1;
            
            IsFinished = false;
        }
    }
}
