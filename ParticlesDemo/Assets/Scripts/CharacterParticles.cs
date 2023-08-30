using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
    Root,
    Head,
    Chest,
    LeftHand,
    RightHand,
    LeftFoot,
    RightFoot
}

public class CharacterParticles : MonoBehaviour
{
    [SerializeField] VisualFX footstepsFX;
    [SerializeField] VisualFX metalFootstepsFX;

    [SerializeField] PhysicMaterial metal;

    [Header("Body Parts")]
    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform head;
    [SerializeField] Transform chest;

    Dictionary<BodyPart, Transform> parts;

    public void Step(int footIndex)
    {
        Transform foot = footIndex == 1 ? leftFoot : rightFoot;

        PhysicMaterial ground = null;
        RaycastHit hit;
        if (Physics.Raycast(new Ray(transform.position + Vector3.up, Vector3.down), out hit))
            ground = hit.collider.sharedMaterial;
        VisualFX fx = ground == metal ? metalFootstepsFX : footstepsFX;

        GameObject go = fx.Spawn(foot);

        Destroy(go, 5);
    }

    public Transform GetBodyPart(BodyPart part)
    {
        if (parts == null)
        {
            parts = new Dictionary<BodyPart, Transform>();
            parts[BodyPart.Root] = transform;
            parts[BodyPart.Head] = head;
            parts[BodyPart.Chest] = chest;
            parts[BodyPart.LeftHand] = leftHand;
            parts[BodyPart.RightHand] = rightHand;
            parts[BodyPart.LeftFoot] = leftFoot;
            parts[BodyPart.RightFoot] = rightFoot;
        }

        if (parts.ContainsKey(part))
            return parts[part];

        return transform;
    }
}
