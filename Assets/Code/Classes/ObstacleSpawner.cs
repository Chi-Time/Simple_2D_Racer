using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [Tooltip ("The min and max delays between each obstacle spawn.")]
    [SerializeField] private float _MinDelay = 0.0f, _MaxDelay = 0.0f;
    [Tooltip ("The various positions an obstacle can be spawned at random.")]
    [SerializeField] private Transform[] _SpawnPositions = null;
    [Tooltip ("The object pool of obstacles.")]
    [SerializeField] private Pool _Pool = new Pool ();

    private void Awake ()
    {
        AssignReferences ();
    }

    private void AssignReferences ()
    {
        _Pool.Intialise ("Obstacle Pool", "Obstacle");
    }

    private void Start ()
    {
        SetDefaults ();
        StartCoroutine ("Spawn");
    }

    private void SetDefaults ()
    {
        
    }

    private IEnumerator Spawn ()
    {
        var delay = Random.Range (_MinDelay, _MaxDelay);
        yield return new WaitForSeconds (delay);

        SpawnObstacle ();
        StopCoroutine ("Spawn");
        StartCoroutine ("Spawn");
    }

    private void SpawnObstacle ()
    {
        var o = _Pool.RetrieveFromPool ();
        o.transform.position = GetPosition ();
    }

    private Vector3 GetPosition ()
    {
        return _SpawnPositions[Random.Range (0, _SpawnPositions.Length)].position;
    }
}
