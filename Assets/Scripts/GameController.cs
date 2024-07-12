
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    private List<GameObject> players = new List<GameObject>();
    public Transform spawnpointp1;
    public Transform spawnpointp2;
    void Start()
    {
        int connectedControllers = GetConnectedControllers();

        for (int i = 1; i <= connectedControllers; i++)
        {   
            if (i == 1)
            {
                GameObject player = Instantiate(playerPrefab, spawnpointp1.transform.position, Quaternion.identity);
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.playerNumber = i;
                players.Add(player);
            }else
            {
                 GameObject player = Instantiate(playerPrefab, spawnpointp2.transform.position, Quaternion.identity);
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.playerNumber = i;
                players.Add(player);
            }
        }
    }

    int GetConnectedControllers()
    {
        int count = 0;
        for (int i = 1; i <= 4; i++)
        {
            if (Input.GetJoystickNames().Length >= i && !string.IsNullOrEmpty(Input.GetJoystickNames()[i - 1]))
            {
                count++;
            }
        }
        return count;
    }
}
