namespace Hero.Shared.Dtos
{
    public class ChoiceResultDto
    {
        public int Id { get; set; }
        public int NextSceneId { get; set; }
        public SceneDto? NextSceneDto { get; set; }
    }
}
