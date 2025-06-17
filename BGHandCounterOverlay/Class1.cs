using Hearthstone_Deck_Tracker.Plugins;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;
using HearthDb.Enums;
using System;
using System.Windows.Controls;

namespace BGHandCounterOverlay
{
    public class BGHandCounterOverlay : IPlugin
    {
        private HandCountOverlay _overlay;

        public string Name => "BG Hand Counter";
        public string Description => "Shows hand count in Battlegrounds";
        public string ButtonText => "Settings";
        public string Author => "YourName";
        public Version Version => new Version(1, 0, 0, 0);
        public MenuItem MenuItem => null;

        public void OnLoad()
        {
            _overlay = new HandCountOverlay();
        }

        public void OnUnload()
        {
            _overlay?.Close();
            _overlay = null;
        }

        public void OnButtonPress() { }

        public void OnUpdate()
        {
            var gameType = Core.Game.CurrentGameType;
            bool isBattlegrounds =
                gameType == GameType.GT_BATTLEGROUNDS ||
                gameType == GameType.GT_BATTLEGROUNDS_FRIENDLY;

            if (isBattlegrounds)
            {
                int handCount = Core.Game.Player.HandCount;
                if (!_overlay.IsVisible) _overlay.Show();
                _overlay.HandCountText.Text = handCount.ToString();
            }
            else
            {
                if (_overlay?.IsVisible == true) _overlay.Hide();
            }
        }
    }
}
