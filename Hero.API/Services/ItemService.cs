using Hero.API.Repositories;
using Hero.Shared.Dtos;

namespace Hero.API.Services
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepository;
        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            List<ItemDto> itemsDto = [];

            foreach (var item in items)
            {
                ItemDto itemDto = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Type = item.Type
                };
                if (item.Stats != null)
                {
                    var stats = new StatsDto()
                    {
                        Id = item.Stats.Id,
                        Charisma = item.Stats.Charisma,
                        Defense = item.Stats.Defense,
                        Dexterity = item.Stats.Dexterity,
                        Knowledge = item.Stats.Knowledge,
                        Strength = item.Stats.Strength,
                        Vitality = item.Stats.Vitality,
                    };
                    itemDto.Stats = stats;
                }
                itemsDto.Add(itemDto);
            }
            return itemsDto;
        }
    }
}
