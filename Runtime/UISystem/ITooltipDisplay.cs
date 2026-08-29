using UnityEngine;

namespace CrystalFlux.Core
{
    public interface ITooltipDisplay
    {
        void ShowTooltip(string title, string description, Vector2 offset = default);
        void HideTooltip();
    }
}
