using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour {
    GameObject[] players;
    Vector3 spawnPoint;
    public int x_index = -1;
    public int z_index = -1;
    private Ray ray;

    // Use this for initialization
    void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            do
            {
                x_index = Random.Range(0, 15);
                z_index = Random.Range(0, 15);

                spawnPoint = new Vector3((float)x_index - 7.5f, 0.3f, (float)z_index - 7.5f);
                ray = new Ray(spawnPoint, Vector3.up);
            }
            while ((((x_index == 7) || (x_index == 8)) && ((z_index == 7) || (z_index == 8)))
            ||(Physics.Raycast(ray)));

            Debug.Log("spawn");
            Debug.Log("spawn x point is " + spawnPoint.x);
            Debug.Log("spawn z point is " + spawnPoint.z);
            player.transform.position = spawnPoint;
        }
    }
}
