using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }        
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

             transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }            
        }

        DeactivateEnemy();
    }

    void ReturnToStart()
    {        
        transform.position = path[0].transform.position;
    }

    void DeactivateEnemy()
    {
        Debug.Log($"You have failed to kill the enemy attacker!");
        gameObject.SetActive(false);
        if (enemy == null)
        {
            Debug.Log($"ERROR: Enemy Not Found.");
            return;
        }
        if (enemy.StealGold())
        {
            Debug.Log($"ERROR: Bank Problem.");
        }
    }
}
