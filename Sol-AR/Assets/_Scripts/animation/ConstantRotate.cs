using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates a gameobject in a constant fashion
/// </summary>
public class ConstantRotate : MonoBehaviour
{
    #region Variables
    #region Editor
    /// <summary>
    /// Whether to start rotating the gameobject on enable or wait for a call
    /// </summary>
    [SerializeField]
    private bool startOnEnable;
    /// <summary>
    /// The angle to rotate the gameobject in
    /// </summary>
    [SerializeField]
    private Vector3 rotateVector;
    #endregion
    #region Private
    /// <summary>
    /// Whether the object is rotating
    /// </summary>
    private bool rotating;
    #endregion
    #endregion

    #region Methods
    #region Unity
    void Start () {
        if (startOnEnable)
        {
            rotating = true;
        }
	}

    private void Update()
    {
        if (rotating)
        {
            transform.Rotate(rotateVector);
        }
    }
    #endregion
    #region Public
    /// <summary>
    /// Start or stop rotating
    /// </summary>
    /// <param name="rotate"></param>
    public void Rotate(bool rotate)
    {
        rotating = rotate;
    }
    #endregion
    #endregion
}
