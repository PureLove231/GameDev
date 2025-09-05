using Godot;
using System;

public partial class MoveState : Node
{
    public override void _Ready()
    {

    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            Player characternode = GetOwner<Player>();
            characternode.animPlayerNode.Play(GameConstants.Anim_MOVE);

        }
    }
}
