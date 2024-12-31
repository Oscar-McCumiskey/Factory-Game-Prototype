using System;
using System.Collections.Generic;
using UnityEngine;

public struct Recipe
{
    public RESOURCE OutputResource;
    public RESOURCE[] InputResources;
}

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set; }
    
    private List<Recipe> _recipes;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _recipes = new List<Recipe>();
        
        // create recipes
        // steel
        Recipe steel = new Recipe();
        steel.InputResources = new[] {RESOURCE.COAL, RESOURCE.IRON};
        steel.OutputResource = RESOURCE.STEEL;
        
        _recipes.Add(steel);
        
        // diamond
        Recipe diamond = new Recipe();
        diamond.InputResources = new[] {RESOURCE.COAL, RESOURCE.COAL};
        diamond.OutputResource = RESOURCE.DIAMOND;
        
        _recipes.Add(diamond);
        
        // ring
        Recipe ring = new Recipe();
        ring.InputResources = new[] {RESOURCE.DIAMOND, RESOURCE.GOLD, RESOURCE.STEEL};
        ring.OutputResource = RESOURCE.RING;
        
        _recipes.Add(ring);
    }

    public RESOURCE GetRecipe(RESOURCE[] inputResources)
    {
        string iD = "";
        string revID = "";
        
        RESOURCE outputResource = RESOURCE.EMPTY;
        
        // calc ID of inputs
        for (int i = 0; i < inputResources.Length; i++)
        {
            iD = iD + inputResources[i];
            revID = inputResources[i] + revID;
        }
        
        Debug.Log("ID: " + iD);
        
        for (int i = 0; i < _recipes.Count; i++)
        {
            string recipeID = "";
            
            // calc ID of recipe
            for (int j = 0; j < _recipes[i].InputResources.Length; j++)
            {
                Debug.Log("Recipe: " + recipeID);
                recipeID = recipeID + _recipes[i].InputResources[j];
            }
            
            // if found recipe
            if (iD == recipeID || revID == recipeID)
            {
                outputResource = _recipes[i].OutputResource;
            }
        }
        
        // return recipe output
        return outputResource;
    }
}
