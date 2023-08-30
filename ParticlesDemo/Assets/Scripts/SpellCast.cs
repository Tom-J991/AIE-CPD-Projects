using UnityEngine;

public class SpellCast : MonoBehaviour
{
    [SerializeField] KeyCode key;
    [SerializeField] string animationTrigger;

    [SerializeField] VisualFX castFX;
    [SerializeField] BodyPart castPart;
    [SerializeField] VisualFX spellFX;
    [SerializeField] BodyPart spellPart;

    Animator animator;
    CharacterParticles particles;

    private void Start()
    {
        animator = GetComponent<Animator>();
        particles = GetComponent<CharacterParticles>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            animator.SetTrigger(animationTrigger);
            if (castFX != null)
                castFX.Spawn(particles.GetBodyPart(castPart), 3);
        }
    }

    public void Spell()
    {
        if (spellFX != null)
            spellFX.Spawn(particles.GetBodyPart(spellPart), 3);
    }
}
