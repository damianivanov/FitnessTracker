// Дамян Николаев Иванов - ФН: F123976
using System.Drawing.Drawing2D;

namespace FitnessTracker.UI;

/// <summary>
/// Simple helper methods for applying UI styles
/// </summary>
public static class UiHelper
{
    /// <summary>
    /// Styles a button as a primary button
    /// </summary>
    public static void StylePrimary(this Button button)
    {
        button.BackColor = UiConstants.Colors.Primary;
        button.ForeColor = UiConstants.Colors.TextWhite;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UiConstants.Button.FontPrimary;
        button.Height = UiConstants.Button.Height;
        button.Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Styles a button as a secondary button
    /// </summary>
    public static void StyleSecondary(this Button button)
    {
        button.BackColor = UiConstants.Colors.Secondary;
        button.ForeColor = UiConstants.Colors.TextPrimary;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UiConstants.Button.FontSecondary;
        button.Height = UiConstants.Button.HeightSmall;
        button.Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Styles a button as a danger button (for delete/logout)
    /// </summary>
    public static void StyleDanger(this Button button)
    {
        button.BackColor = UiConstants.Colors.Danger;
        button.ForeColor = UiConstants.Colors.TextWhite;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UiConstants.Button.FontSecondary;
        button.Height = UiConstants.Button.HeightSmall;
        button.Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Styles a button as a success button (for save/add actions)
    /// </summary>
    public static void StyleSuccess(this Button button)
    {
        button.BackColor = UiConstants.Colors.Success;
        button.ForeColor = UiConstants.Colors.TextWhite;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UiConstants.Button.FontPrimary;
        button.Height = UiConstants.Button.Height;
        button.Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Adds a hover effect to a button
    /// </summary>
    public static void AddHoverEffect(this Button button, Color hoverColor)
    {
        var originalColor = button.BackColor;
        button.MouseEnter += (s, e) => button.BackColor = hoverColor;
        button.MouseLeave += (s, e) => button.BackColor = originalColor;
    }

    /// <summary>
    /// Adds a primary button hover effect (uses PrimaryHover color)
    /// </summary>
    public static void AddPrimaryHover(this Button button)
    {
        button.AddHoverEffect(UiConstants.Colors.PrimaryHover);
    }

    /// <summary>
    /// Styles a textbox with a dark theme
    /// </summary>
    public static void StyleInput(this TextBox textBox)
    {
        textBox.BackColor = UiConstants.Colors.BackgroundLight;
        textBox.ForeColor = UiConstants.Colors.TextPrimary;
        textBox.Font = UiConstants.Input.Font;
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.Height = UiConstants.Input.Height;
    }

    /// <summary>
    /// Styles a label with a dark theme
    /// </summary>
    public static void StyleLabel(this Label label)
    {
        label.Font = UiConstants.Label.Font;
        label.ForeColor = UiConstants.Colors.TextPrimary;
    }
}

