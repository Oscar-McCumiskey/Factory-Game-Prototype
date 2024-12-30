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
        if (inputs[0].resource == RESOURCE.COAL && inputs[1].resource == RESOURCE.IRON)
        {
            // check valid quantity
            if (inputs[0].quantity > 0 && inputs[1].quantity > 0)
            {
                IsProcessing = true;
            }
        }
        
        base.UpdateProcess();

        if (IsFinished)
        {
            // adjust input and output values
            inputs[0].quantity -= 1;
            inputs[1].quantity -= 1;
            
            outputs[0].resource = RESOURCE.STEEL;
            if (outputs[0].quantity < outputs[0].maxResources) outputs[0].quantity += 1;
            
            IsFinished = false;
            
            // update resources
            outputs[0].UpdateText();
        }
    }
}
