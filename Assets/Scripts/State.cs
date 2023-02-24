using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    public virtual void Enter()
    {
        // DisplayOnUI(UIManager.Alignment.Left);
    }

    public virtual void Play()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
