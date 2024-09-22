using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField] private MovementLoot[] _spawnLoot;
    [SerializeField] private SpawnPoint[] _positionSpawnLoot;

    private void Update()
    {
        SpawnBonus();
    }

    private void SpawnBonus()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _positionSpawnLoot.Length; i++)
                Instantiate(_spawnLoot[i]);
        }
    }
}