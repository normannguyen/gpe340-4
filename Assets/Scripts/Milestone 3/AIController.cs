using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    //Pawn Data
    public Pawn AIpawn;
    //Target on Player
    public Transform target;
    //NavMeshAgent
    public NavMeshAgent navMeshAgent;
    //Weapon Data for equipping and firing
    public Weapon weapon;
    //public AIStates currentState;
    private Vector3 desiredMovement;

    // Start is called before the first frame update
    public void Start()
    {
        navMeshAgent = AIpawn.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        AIpawn.EquipWeapon(weapon);
    }
    // Update is called once per frame
    public void Update()
    {
        AIMove();
        Attack();
    }
    //On Animator Move
    private void OnAnimatorMove()
    {
        navMeshAgent.velocity = AIpawn.anim.velocity;
    }
    //AI Movement to the player
    public void AIMove()
    {
        AIpawn.agent.SetDestination(target.position);
        desiredMovement = Vector3.MoveTowards(desiredMovement, AIpawn.agent.desiredVelocity, AIpawn.agent.acceleration * Time.deltaTime);
        Vector3 moveInput = transform.InverseTransformDirection(desiredMovement);
        AIpawn.Move(moveInput);
    }
    //Attack Function
    public void Attack()
    {
        AIpawn.OnTriggerPull.Invoke();
    }
}
