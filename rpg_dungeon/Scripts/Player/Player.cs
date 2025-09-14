using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody3D
{

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D sprite;
    [Export] float speed = 30f;
    public Vector2 direction = new();

    [Export] public StateMachine stateMachineNode;



    public override void _Input(InputEvent @event)
    {

        direction = Input.GetVector
        (

            GameConstants.PlayerMove_LEFT,
            GameConstants.PlayerMove_RIGHT,
            GameConstants.PlayerMove_UP,
            GameConstants.PlayerMove_Down


        );




    }

    public void FlipSprite()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; }


        bool isMovingleft = Velocity.X < 0;
        sprite.FlipH = isMovingleft;
    }
}
