using UnityEngine;

public class Manufacturer : BuildingBase
{
    protected override void InitBuilding()
    {
        base.InitBuilding();
    }

    protected override void UpdateProcess()
    {
        // check recipe output
        RESOURCE[] inputResources = {inputs[0].resource, inputs[1].resource, inputs[2].resource};
        outputs[0].resource = RecipeManager.Instance.GetRecipe(inputResources);
        
        // check valid resources
        if (outputs[0].resource != RESOURCE.EMPTY)
        {
            // check valid quantity
            if (inputs[0].quantity > 0 && inputs[1].quantity > 0 && inputs[2].quantity > 0)
            {
                IsProcessing = true;
            }
        }
        else
        {
            IsProcessing = false;
        }
        
        base.UpdateProcess();

        if (IsFinished)
        {

            // adjust input and output values
            inputs[0].quantity -= 1;
            inputs[1].quantity -= 1;
            inputs[2].quantity -= 1;
            
            if (outputs[0].quantity < outputs[0].maxResources) outputs[0].quantity += 1;
            
            IsFinished = false;
            
            // update resources
            outputs[0].UpdateText();
        }
    }
}