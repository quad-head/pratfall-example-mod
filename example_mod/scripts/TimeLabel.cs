using Godot;
using System;

[GlobalClass]
public partial class TimeLabel : Label
{
    public override void _Process(double delta)
    {
        Text = $"Time: {DateTime.Now:HH:mm:ss}";
    }
}