using Hero.API.Repositories;
using Hero.Shared.Dtos;
using Hero.Shared.Models;

namespace Hero.API.Services
{
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepository;
        private readonly JobRepository _jobRepository;

        public PlayerService(PlayerRepository playerRepository, JobRepository jobRepository)
        {
            _playerRepository = playerRepository;
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            foreach (var p in players)
            {
                Console.WriteLine($"Player: {p.Id}, Name: {p.Name}, Job: {p.Job?.Name ?? "null"}, StatsId: {p.Stats?.Id ?? 0}");
            }
            return players.Select(p =>

            new PlayerDto
            {
                Id = p.Id,
                Name = p.Name,
                SceneId = p.SceneId,
                Job = p.Job != null
                ? new JobDto { Id = p.Job.Id, Name = p.Job.Name }
                : new JobDto { Id = 0, Name = "Inconnu" },
                Stats = p.Stats != null
                ? new StatsDto
                {
                    Id = p.Stats.Id,
                    Strength = p.Stats.Strength,
                    Vitality = p.Stats.Vitality,
                    Defense = p.Stats.Defense,
                    Knowledge = p.Stats.Knowledge,
                    Charisma = p.Stats.Charisma,
                    Dexterity = p.Stats.Dexterity
                }
                : new StatsDto(),
                Items = [.. p.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    Description = i.Description,
                    Stats = i.Stats != null ? new StatsDto
                    {
                        Id = i.Stats.Id,
                        Strength = i.Stats.Strength,
                        Charisma = i.Stats.Charisma,
                        Defense = i.Stats.Defense,
                        Knowledge = i.Stats.Knowledge,
                        Dexterity = i.Stats.Dexterity,
                        Vitality = i.Stats.Dexterity
                    } : null
                })]
            });


        }


        public async Task DeletePlayerAsync(int id)
        {
            Player? player = await _playerRepository.GetByIdAsync(id) ?? throw new Exception("Player not found");
            await _playerRepository.DeleteAsync(player);
        }

        public async Task<PlayerDto> GetPlayerByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);

            return player == null
                ? throw new Exception("Player not found")
                : new PlayerDto
                {
                    Id = player.Id,
                    Name = player.Name,
                    SceneId = player.SceneId,
                    Job = new JobDto
                    { Id = player.Job.Id, Name = player.Job.Name },
                    Stats = new StatsDto
                    {
                        Id = player.Stats?.Id ?? 0,
                        Strength = player.Stats?.Strength ?? 0,
                        Vitality = player.Stats?.Vitality ?? 0,
                        Defense = player.Stats?.Defense ?? 0,
                        Knowledge = player.Stats?.Knowledge ?? 0,
                        Charisma = player.Stats?.Charisma ?? 0,
                        Dexterity = player.Stats?.Dexterity ?? 0,

                    },
                    Items = [.. player.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    Description = i.Description,
                    Stats = i.Stats != null ? new StatsDto
                    {
                        Id = i.Stats.Id,
                        Strength = i.Stats.Strength,
                        Charisma = i.Stats.Charisma,
                        Defense = i.Stats.Defense,
                        Knowledge = i.Stats.Knowledge,
                        Dexterity = i.Stats.Dexterity,
                        Vitality = i.Stats.Dexterity
                    } : null
                })]
                };
        }

        public async Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto playerInfos)
        {
            var job = await _jobRepository.GetByNameAsync(playerInfos.JobName);

            if (job == null)
            {
                throw new Exception("Job not found");
            }

            var generatedStats = job.Name switch
            {
                "warrior" => new Stats(5, 4, 3, 1, 1, 2),
                "scholar" => new Stats(1, 2, 2, 5, 4, 1),
                "thief" => new Stats(2, 2, 2, 2, 3, 5),
                _ => new Stats()
            };

            var player = new Player(playerInfos.Name, generatedStats, job);


            await _playerRepository.AddAsync(player);

            generatedStats.PlayerId = player.Id;

            await _playerRepository.SaveChangesAsync(player);

            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                SceneId = player.SceneId,
                Job = new JobDto { Id = job.Id, Name = job.Name },
                Stats = new StatsDto
                {
                    Id = player.Stats.Id,
                    Strength = player.Stats.Strength,
                    Vitality = player.Stats.Vitality,
                    Defense = player.Stats.Defense,
                    Knowledge = player.Stats.Knowledge,
                    Charisma = player.Stats.Charisma,
                    Dexterity = player.Stats.Dexterity
                },
                Items = [.. player.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    Description = i.Description,
                    Stats = i.Stats != null ? new StatsDto
                    {
                        Id = i.Stats.Id,
                        Strength = i.Stats.Strength,
                        Charisma = i.Stats.Charisma,
                        Defense = i.Stats.Defense,
                        Knowledge = i.Stats.Knowledge,
                        Dexterity = i.Stats.Dexterity,
                        Vitality = i.Stats.Dexterity
                    } : null
                })]
            };
        }

    }
}
