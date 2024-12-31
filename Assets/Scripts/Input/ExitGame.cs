using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private bool canExit = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canExit)
        {
            Application.Quit();
        }
    }
}
