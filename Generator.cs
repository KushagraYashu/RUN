using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform floor;
    [SerializeField] private Transform player;
    [SerializeField] private Transform endPoint;

    private void Awake()
    {
        if (Vector3.Distance(player.position, endPoint.position) < 25f)
        { Instantiate(floor, new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z), Quaternion.identity);
        }
    }

}
