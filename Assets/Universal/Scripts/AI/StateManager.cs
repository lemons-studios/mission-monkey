using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public EnemyPatrol enemyPatrol;

    private void Start()
    {
        currentState = enemyPatrol;
    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();


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
