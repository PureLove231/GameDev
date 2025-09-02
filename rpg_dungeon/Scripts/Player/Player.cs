using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody3D
{

    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D sprite;
    [Export] float speed = 30f;
    private Vector2 direction = new();

    public override void _Ready()
    {
        animPlayerNode.Play(GameConstants.Anim_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {


        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();

    }

    public override void _Input(InputEvent @event)
    {

        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");

        if (direction == Vector2.Zero)
        {
            animPlayerNode.Play(GameConstants.Anim_IDLE);

        }

        else
        {
            animPlayerNode.Play("Move");
        }

        if (direction.X == -1)
        {
            sprite.FlipH = true;

        }

        else
        {
            sprite.FlipH = false;
        }

    }
}
