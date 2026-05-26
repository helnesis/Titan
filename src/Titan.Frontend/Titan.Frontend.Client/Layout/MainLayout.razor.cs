using MudBlazor;
using Titan.Frontend.Client.Layout.Theme;
#nullable enable

namespace Titan.Frontend.Client.Layout
{
    public partial class MainLayout
    {
        private bool _isDarkMode = true;
        private MudTheme? _theme = null;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _theme = new()
            {
                PaletteLight = TitanTheme.LightPalette,
                PaletteDark = TitanTheme.DarkPalette,
                Typography = TitanTheme.Typography,
                LayoutProperties = new LayoutProperties()
            };
        }

        private void DarkModeToggle()
        {
            _isDarkMode = !_isDarkMode;
        } 
        public string DarkLightModeButtonIcon => _isDarkMode switch
        {
            true => Icons.Material.Outlined.LightMode,
            false => Icons.Material.Outlined.DarkMode,
        };
    }
}
