namespace Hero.Shared.Dtos.Editor
{
    public class SceneChoiceDto
    {
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? TargetSceneId { get; set; }
        public int? TargetItemId { get; set; }
    }
}
