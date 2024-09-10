using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavious : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;

    //public bool[] testStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoom(bool[] status)
    {
        for(int i = 0; i< status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}
