using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;

    public void Spawn()
    {
        Instantiate(buildingPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
