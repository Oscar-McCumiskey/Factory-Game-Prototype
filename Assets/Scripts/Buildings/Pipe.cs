using UnityEngine;

public class Pipe : MonoBehaviour
{
    public BuildingInput PipeInput { get; set; }
    public BuildingOutput PipeOutput { get; set; }

    [SerializeField] private float transferRatePerMinute = 60;
    private float _transferCounter;
    private float _transferTime = 0;
    
    private LineRenderer _lineRenderer;

    private bool _isPlaced = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
        _transferTime = transferRatePerMinute / 60.0f;
        _transferCounter = _transferTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (PipeInput && PipeOutput)
        {
            _isPlaced = true;
            
            // validate item transfer
            if (_transferCounter <= 0)
            {
                // reset counter
                _transferCounter = _transferTime;

                // transfer item
                if (PipeOutput.quantity > 0 && PipeInput.quantity < PipeOutput.maxResources)
                {
                    PipeOutput.quantity -= 1;
                    PipeInput.quantity += 1;

                    PipeInput.resource = PipeOutput.resource;
                    
                    // update text
                    PipeInput.UpdateText();
                    PipeOutput.UpdateText();
                }
            }
        }

        _transferCounter -= Time.deltaTime;
        
        // cancel pipe placement
        if (!PipeInput || !PipeOutput)
        {
            if (Input.GetMouseButtonDown(1))
            {
                PipeManager.Instance.piping = false;
                if (PipeInput) PipeInput.isPiped = false;
                if (PipeOutput) PipeOutput.isPiped = false;
                
                Destroy(gameObject);
            }
            
            // destroy on building delete
            if (_isPlaced)
            {
                PipeInput.isPiped = false;
                PipeOutput.isPiped = false;
                Destroy(gameObject);
            }
        }
        
        // update visuals
        if (PipeOutput && PipeInput)
        {
            _lineRenderer.SetPosition(0, PipeOutput.transform.position);
            _lineRenderer.SetPosition(1, PipeInput.transform.position); 
        }
        else
        {
            if (PipeInput && !PipeOutput)
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _lineRenderer.SetPosition(0, newPos);
                newPos = PipeInput.transform.position;
                _lineRenderer.SetPosition(1, newPos);
            }
            else if (!PipeInput && PipeOutput)
            {
                Vector2 newPos = PipeOutput.transform.position;
                _lineRenderer.SetPosition(0, newPos);
                newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _lineRenderer.SetPosition(1, newPos);
            }
        }
    }
}