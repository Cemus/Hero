using Hero.Shared.Dtos;

namespace Hero.Blazor.Services
{
    public class PlayerStateService
    {
        public PlayerDto? CurrentPlayer { get; set; }
        public event Action? OnChange;

        public void SetPlayer(PlayerDto player)
        {
            CurrentPlayer = player;
            NotifyStateChanged();
        }

        public void UpdateScene(int sceneId)
        {
            if (CurrentPlayer != null)
            {
                CurrentPlayer.SceneId = sceneId;
                NotifyStateChanged();
            }

        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
