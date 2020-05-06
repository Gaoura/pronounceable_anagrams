using System;
using UnityEngine;


/// <summary> Attribute changing a field label in the inspector </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class LabelAttribute : PropertyAttribute
{
    #region FIELDS
    /*
        ######## #### ######## ##       ########   ######
        ##        ##  ##       ##       ##     ## ##    ##
        ##        ##  ##       ##       ##     ## ##
        ######    ##  ######   ##       ##     ##  ######
        ##        ##  ##       ##       ##     ##       ##
        ##        ##  ##       ##       ##     ## ##    ##
        ##       #### ######## ######## ########   ######
    */

    /// <summary> Property to access to the label of the attribute </summary>
    public string Label { get; }

    #endregion FIELDS

    #region CONSTRUCTORS
    /*
            ######  ########  #######  ########   ######
        ##    ##    ##    ##     ## ##     ## ##    ##
        ##          ##    ##     ## ##     ## ##
        ##          ##    ##     ## ########   ######
        ##          ##    ##     ## ##   ##         ##
        ##    ##    ##    ##     ## ##    ##  ##    ##
            ######     ##     #######  ##     ##  ######
    */

    /// <summary>  </summary>
    /// <param name="label"> A label to set for the property </param>
    public LabelAttribute(string label)
    {
        Label = label;
    }

    #endregion CONSTRUCTORS
}