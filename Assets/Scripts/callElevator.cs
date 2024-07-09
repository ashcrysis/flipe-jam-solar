using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callElevator : MonoBehaviour
{
    [SerializeField] private float minDistance;
    public GameObject elevator;
    public bool canInteract;
    private Transform elevatorStartPosition;
    private Transform elevatorEndPosition;



    void Start()
    {
        elevatorStartPosition = elevator.GetComponent<Elevator>().starterPosition;
        elevatorEndPosition = elevator.GetComponent<Elevator>().endPosition;
    }

    void LateUpdate()
    {
        canInteract = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < minDistance;

        if (Input.GetButtonDown("Fire3") && canInteract )
        {   
            float threshold = 1f;
            if (Vector2.Distance(elevator.transform.position, elevatorStartPosition.position) < threshold)
            {
                StartCoroutine(elevatorChange(1f,elevatorEndPosition));
                return;
            }
            if (Vector2.Distance(elevator.transform.position, elevatorEndPosition.position) < threshold)
            {
                StartCoroutine(elevatorChange(1f,elevatorStartPosition));
                return;
            }
        }
        
    }
    private IEnumerator elevatorChange(float delay, Transform destiny){
        Elevator elevatorComponent = elevator.GetComponent<Elevator>();
        yield return new WaitForSeconds(delay);
        elevatorComponent.destiny = destiny;
    }


}
