namespace FitnessTracker.UI;

/// <summary>
/// UI Constants for colors, button styles, and border radius
/// </summary>
public static class UiConstants
{
    #region Colors
    public static class Colors
    {
        public static readonly Color BackgroundDark = Color.FromArgb(19, 19, 19);
        public static readonly Color BackgroundMedium = Color.FromArgb(30, 30, 30);
        public static readonly Color BackgroundLight = Color.FromArgb(40, 40, 40);

        public static readonly Color Primary = Color.FromArgb(248, 113, 113);
        public static readonly Color PrimaryHover = Color.FromArgb(220, 95, 95);

        public static readonly Color Secondary = Color.FromArgb(70, 70, 70);
        public static readonly Color Success = Color.FromArgb(16, 185, 129);
        public static readonly Color Danger = Color.FromArgb(240, 80, 80);

        public static readonly Color TextPrimary = Color.FromArgb(230, 230, 230);
        public static readonly Color TextSecondary = Color.FromArgb(180, 180, 180);
        public static readonly Color TextWhite = Color.White;
    }

    #endregion

    #region Button Styles
    public static class Button
    {
        public const int Height = 35;
        public const int HeightSmall = 30;
        public static readonly Font FontPrimary = new Font("Segue UI", 10F, FontStyle.Bold);
        public static readonly Font FontSecondary = new Font("Segue UI", 9F);
    }

    #endregion

    #region Input Fields
    public static class Input
    {
        public const int Height = 25;
        public static readonly Font Font = new Font("Segue UI", 10F);
    }

    #endregion
    
    #region Labels
    public static class Label
    {
        public static readonly Font Font = new Font("Segue UI", 10F);
    }

    #endregion
}
