using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteractable : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    private Renderer _myRenderer;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public virtual void OnPointerExit()
    {
        SetMaterial(true);
    }

    public virtual void OnPointerClick()
    {

    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    protected void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
