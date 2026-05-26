using MudBlazor;

namespace Titan.Frontend.Client.Layout.Theme;

public static class TitanTheme
{
    private const string DisplayFont = "JetBrains Mono";

    public static readonly Typography Typography = new()
    {
        Default = new DefaultTypography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.875rem",
            FontWeight = "400",
            LineHeight = "1.5",
            LetterSpacing = "normal",
        },
        H1 = new H1Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "2.5rem",
            FontWeight = "700",
            LineHeight = "1.2",
            LetterSpacing = "0.02em",
        },
        H2 = new H2Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "2rem",
            FontWeight = "700",
            LineHeight = "1.25",
            LetterSpacing = "0.015em",
        },
        H3 = new H3Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "1.625rem",
            FontWeight = "600",
            LineHeight = "1.3",
            LetterSpacing = "0.01em",
        },
        H4 = new H4Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "1.375rem",
            FontWeight = "600",
            LineHeight = "1.35",
            LetterSpacing = "0.005em",
        },
        H5 = new H5Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "1.125rem",
            FontWeight = "600",
            LineHeight = "1.4",
            LetterSpacing = "0",
        },
        H6 = new H6Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "1rem",
            FontWeight = "600",
            LineHeight = "1.4",
            LetterSpacing = "0",
        },
        Subtitle1 = new Subtitle1Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "1rem",
            FontWeight = "500",
            LineHeight = "1.5",
            LetterSpacing = "0",
        },
        Subtitle2 = new Subtitle2Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.875rem",
            FontWeight = "500",
            LineHeight = "1.5",
            LetterSpacing = "0",
        },
        Body1 = new Body1Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.9375rem",
            FontWeight = "400",
            LineHeight = "1.6",
            LetterSpacing = "0",
        },
        Body2 = new Body2Typography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.8125rem",
            FontWeight = "400",
            LineHeight = "1.5",
            LetterSpacing = "0",
        },
        Button = new ButtonTypography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.875rem",
            FontWeight = "500",
            LineHeight = "1.5",
            LetterSpacing = "0",
            TextTransform = "none",
        },
        Caption = new CaptionTypography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.75rem",
            FontWeight = "400",
            LineHeight = "1.4",
            LetterSpacing = "0.01em",
        },
        Overline = new OverlineTypography
        {
            FontFamily = [DisplayFont, "monospace"],
            FontSize = "0.6875rem",
            FontWeight = "600",
            LineHeight = "1.5",
            LetterSpacing = "0.1em",
            TextTransform = "uppercase",
        },
    };

    public static readonly PaletteLight LightPalette = new()
    {
        Black = "#1a1a2e",

        Primary = "#5b6abf",
        PrimaryDarken = "#4a57a5",
        PrimaryLighten = "#7c8ad1",

        Secondary = "#64748b",
        Tertiary = "#8b5cf6",

        AppbarText = "#1e293b",
        AppbarBackground = "#ffffff",

        Background = "#f8fafc",
        Surface = "#ffffff",
        DrawerBackground = "#f1f5f9",
        DrawerText = "#1e293b",
        DrawerIcon = "#5b6abf",

        GrayLight = "#e2e8f0",
        GrayLighter = "#f1f5f9",

        Info = "#3b82f6",
        Success = "#22c55e",
        Warning = "#f59e0b",
        Error = "#ef4444",

        LinesDefault = "#e2e8f0",
        TableLines = "#e2e8f0",
        Divider = "#e5e7eb",

        TextPrimary = "#1e293b",
        TextSecondary = "#64748b",
        TextDisabled = "#94a3b880",

        ActionDefault = "#64748b",
        ActionDisabled = "#94a3b84d",
        ActionDisabledBackground = "#e2e8f04d",

        OverlayLight = "#f8fafc80",
    };

    public static readonly PaletteDark DarkPalette = new()
    {
        Black = "#0b0f18",

        Primary = "#818cf8",
        PrimaryDarken = "#6366f1",
        PrimaryLighten = "#a5b4fc",

        Secondary = "#94a3b8",
        Tertiary = "#a78bfa",

        AppbarText = "#f1f5f9",
        AppbarBackground = "#1e2536",

        Background = "#151c2c",
        Surface = "#1e2536",
        DrawerBackground = "#1a2132",
        DrawerText = "#e2e8f0",
        DrawerIcon = "#818cf8",

        GrayLight = "#2d3a4f",
        GrayLighter = "#374862",

        Info = "#60a5fa",
        Success = "#4ade80",
        Warning = "#fbbf24",
        Error = "#f87171",

        LinesDefault = "#2d3a4f",
        TableLines = "#2d3a4f",
        Divider = "#334155",

        TextPrimary = "#f1f5f9",
        TextSecondary = "#94a3b8",
        TextDisabled = "#64748b80",

        ActionDefault = "#cbd5e1",
        ActionDisabled = "#64748b4d",
        ActionDisabledBackground = "#94a3b81a",

        OverlayLight = "#151c2c80",
    };
}