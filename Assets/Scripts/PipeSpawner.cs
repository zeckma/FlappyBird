using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin, yPosMax;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPipeCoroutine());
    }

    IEnumerator spawnPipeCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
		Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        StartCoroutine(spawnPipeCoroutine());
	}
}
