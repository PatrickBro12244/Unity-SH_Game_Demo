using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Character;
    public NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Character.position);
    }
}
