using UnityEngine;

namespace SampleRPG.Movement
{
    public interface IMovementDirectionSource
    {
        Vector3 MovementDirection { get; }
    }
}
