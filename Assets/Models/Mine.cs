using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A component containing all <see cref="Tunnel"/>s and overseeing an elevator
/// which gathers resources from them.
/// </summary>
public class Mine : Pipeline
{
    #region Properties

    // Disables warning for unassigned variables, as these
    // variables will be set in the Unity editor.
#pragma warning disable 0649

    /// <summary>
    /// A template for a new tunnel.
    /// </summary>
    [SerializeField]
    private Tunnel TunnelTemplate;

    /// <summary>
    /// The base cost to create a new tunnel.
    /// </summary>
    [SerializeField]
    private float BaseExpansionCost;

    /// <summary>
    /// A reference to the text of the button used to add a new tunnel.
    /// </summary>
    [SerializeField]
    private Text NewTunnelText;

#pragma warning restore 0649

    /// <summary>
    /// The current cost to create a new tunnel.
    /// </summary>
    private float ExpansionCost => Sources.Count() * BaseExpansionCost;

    /// <summary>
    /// A reference to the player's <see cref="CashStore"/>.
    /// </summary>
    public CashStore PlayerCash
        => GameObject.FindWithTag("Player").GetComponent<CashStore>();

    #endregion

    #region Overrides

    /// <summary>
    /// Finds <see cref="Source"/>s from child <see cref="Tunnel"/> objects.
    /// </summary>
    /// <returns>A list of sources to draw from.</returns>
    protected override IEnumerable<Source> GetSources()
        => GetComponentsInChildren<Tunnel>()
            .OrderBy(tunnel => tunnel.Depth)
            .Select(tunnel => tunnel.GetComponent<Source>());

    public override void Start()
    {
        base.Start();
        UpdateNewTunnelText();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a new tunnel to the mine.
    /// </summary>
    public void AddTunnel()
    {
        PlayerCash.Extract(ExpansionCost);
        var newTunnel = Instantiate(TunnelTemplate, transform);
        newTunnel.Depth = Sources.Count() - 1;
        UpdateNewTunnelText();
    }

    #endregion

    #region Private Methods

    private void UpdateNewTunnelText()
        => NewTunnelText.text = $"Dig! (Cost: {ExpansionCost.ToString("c2")}";

    #endregion
}