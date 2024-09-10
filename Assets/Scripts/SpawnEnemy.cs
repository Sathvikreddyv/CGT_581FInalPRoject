using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject floor;
    public GameObject scroll;
    public int spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = Random.Range(0, 4);
        if(spawn == 1)
        {
            Instantiate(Enemy, new Vector3(floor.GetComponent<Collider>().bounds.center.x, floor.GetComponent<Collider>().bounds.center.y, floor.GetComponent<Collider>().bounds.center.z), Quaternion.identity);
        }
        if(spawn == 0)
        {
            Instantiate(scroll, new Vector3(floor.GetComponent<Collider>().bounds.center.x, floor.GetComponent<Collider>().bounds.center.y, floor.GetComponent<Collider>().bounds.center.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
