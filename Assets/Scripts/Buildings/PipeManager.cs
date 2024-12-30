using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PipeManager : MonoBehaviour
{
    public static PipeManager Instance { get; private set; }

    public GameObject pipePrefab;
    public GameObject pipeObject;
    public bool piping;

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

    public void UpdatePipeInput(BuildingInput buildingInput)
    {
        // create pipe
        if (!piping)
        {
            if (PipeManager.Instance.pipeObject) Destroy(pipeObject);
            pipeObject = Instantiate(pipePrefab);
            piping = true;
            
            // set pipe input
            pipeObject.GetComponent<Pipe>().PipeInput = buildingInput;
        }
        else
        {
            // set pipe input
            pipeObject.GetComponent<Pipe>().PipeInput = buildingInput;
            
            pipeObject = null;
            piping = false;
        }
    }
    
    public void UpdatePipeOutput(BuildingOutput buildingOutput)
    {
        // create pipe
        if (!piping)
        {
            if (PipeManager.Instance.pipeObject) Destroy(pipeObject);
            pipeObject = Instantiate(pipePrefab);
            piping = true;
            
            // set pipe input
            pipeObject.GetComponent<Pipe>().PipeOutput = buildingOutput;
        }
        else
        {
            // set pipe input
            pipeObject.GetComponent<Pipe>().PipeOutput = buildingOutput;
            
            pipeObject = null;
            piping = false;
        }
    }
}
