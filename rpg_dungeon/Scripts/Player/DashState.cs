using Godot;
using System;

public partial class DashState : Node
{

    // der Player Node wird hier verknüpft damit ich auf alle Ressourcen vom Player Node zugreifen kann.
    // Er ist die oberste Schnittstelle!
    private Player characterNode;

    // Timer Node verknüpft mit dem DashNode!
    [Export] private Timer dashTimerNode;


    /* Ready MEthode hier wird die Player Node gefetched. ebenso wird hier der DashTimerNode gefetched. 

    */
    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        dashTimerNode.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false);
    }


    /* Das ist das Notification System, wenn es von der StateMachine eine "5001" Signal bekommt, wird
wird die Animation abgespielt und der PhysicsProcess Node wird aktiviert. 
*/
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {

            characterNode.animPlayerNode.Play(GameConstants.Anim_DASH);
            dashTimerNode.Start();
            SetPhysicsProcess(true);

        }

        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }

    // Die Methode sagt, wenn der Timer von Dash abläuft, wechsle zu IdleState!
    private void HandleDashTimeout()
    {
        characterNode.stateMachineNode.SwitchState<IdleState>();
    }




}
