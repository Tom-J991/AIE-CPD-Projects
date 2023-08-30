using UnityEngine;

[CreateAssetMenu(fileName = "VisualFX", menuName = "VisualFXSystem/VisualFX")]
public class VisualFX : ScriptableObject
{
    public GameObject prefab;

    [SerializeField] bool attach;
    [SerializeField] bool orient;

    public GameObject Spawn(Transform t)
    {
        Transform parent = attach ? t : null;
        Quaternion orientation = orient ? t.rotation : Quaternion.identity;

        return Instantiate(prefab, t.position, orientation, parent);
    }

    public void Spawn(Transform t, float time)
    {
        Transform parent = attach ? t : null;
        Quaternion orientation = orient ? t.rotation : Quaternion.identity;

        GameObject go = Instantiate(prefab, t.position, orientation, parent);

        Destroy(go, time);
    }
}
