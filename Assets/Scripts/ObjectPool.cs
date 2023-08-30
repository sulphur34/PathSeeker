using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected Camera _camera;
    private System.Random _random;
    private List<GameObject> _pool;

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
            item.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        _pool = new List<GameObject>();
        _camera = Camera.main;
        _random = new System.Random();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = GetRandomContainer(prefabs);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        Initialize(new GameObject[] { prefab });
    }

    public void SetContainer(GameObject container)
    {
        container = _container;
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector2 disablePoint = _camera.ViewportToWorldPoint(new Vector2(-0.01f, -0.01f));
        foreach (GameObject item in _pool)
        {
            if (item.activeSelf)
            {
                if(item.transform.position.x < disablePoint.x ||
                    item.transform.position.y < disablePoint.y)
                    item.SetActive(false);
            }
        }
    }

    private GameObject GetRandomContainer(GameObject[] prefabs)
    {
        int containerIndex = _random.Next(prefabs.Length);
        GameObject gameObject = Instantiate(prefabs[containerIndex], _container.transform);
        return gameObject;
    }
}
