using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
  public  EnemyPatrol enemyPatrol;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
        currentState = enemyPatrol;
       
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();
        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }


    }
    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
