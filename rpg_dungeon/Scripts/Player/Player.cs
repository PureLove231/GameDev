using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody3D
{

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D sprite;
    [Export] float speed = 30f;
    private Vector2 direction = new();



    public override void _PhysicsProcess(double delta)
    {


        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();

        FlipSprite();

    }

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

    private void FlipSprite()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; }


        bool isMovingleft = Velocity.X < 0;
        sprite.FlipH = isMovingleft;
    }
}
