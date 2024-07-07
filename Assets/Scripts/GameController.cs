
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;
    private List<GameObject> players = new List<GameObject>();

    void Start()
    {
        int connectedControllers = GetConnectedControllers();

        for (int i = 1; i <= connectedControllers; i++)
        {
            GameObject player = Instantiate(playerPrefab, new Vector3(i-0.5f * 2.0f, 0, 0), Quaternion.identity);
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.playerNumber = i;
            players.Add(player);
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
