using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour {
    private class Tuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public Tuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override bool Equals(object obj)
        {
            Tuple<T1, T2> t = (Tuple<T1, T2>)obj;
            return ((t.Item1.Equals(Item1)) && (t.Item2.Equals(Item2)));
        }
    }

    List<Tuple<int, int>> position = new List<Tuple<int, int>>();
    GameObject[] players;
    Vector3 spawnPoint;
    Vector3 rayPoint;
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
                
                rayPoint = new Vector3((float)x_index - 7.5f, 0.01f, (float)z_index - 7.5f);
                ray = new Ray(rayPoint, Vector3.up);
                if((((x_index == 7) || (x_index == 8)) && ((z_index == 7) || (z_index == 8)))
                    || (Physics.Raycast(ray)))
                {
                    position.Add(new Tuple<int, int>(x_index, z_index));
                }
            }
            while (position.Contains(new Tuple<int, int>(x_index, z_index)));

            spawnPoint = new Vector3((float)x_index - 7.5f, 0.3f, (float)z_index - 7.5f);
            player.transform.position = spawnPoint;
            position.Add(new Tuple<int, int>(x_index, z_index));
            Debug.Log(position.Count);
        }

        position = null;
    }
}
