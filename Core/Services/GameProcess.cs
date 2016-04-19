using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.ConsumableObjects;
using Core.Entities.Creatures;
using Core.Entities.Map;
using Core.Services.EventManager.Messages;
using Core.Services.EventManager;

namespace Core.Services
{
	public class GameProcess : IMessageHandler<ConsumableItemFoundMessage>
	{
		private const uint PLAYER_ID = 1;
		private const uint MONSTERS_START_ID = 2;
		private const uint ITEMS_START_ID = 2;

		private GameProcess _instance;
		private Map _map;
		private List<CreatureBase> _monsters;
		private List<ConsumableItemBase> _items;
		private Player _player;

		private GameProcess()
		{
			_map = new Map();
			_monsters = new List<CreatureBase>();
		}

		public GameProcess GetInstance()
		{
			return _instance ?? (_instance = new GameProcess());
		}

		public void CreateDefaulGameWorld()
		{
			_map.GenerateDefaultMap();

			AddMonster<Bear>();
			AddMonster<Wolf>();
			AddMonster<Bat>();

			AddItem<HealthyCherry>();
			AddItem<HealthyCherry>();
			AddItem<HealthyCherry>();
			AddItem<StrawberryOfSpeed>();
			AddItem<StrawberryOfSpeed>();
			AddItem<StrawberryOfSpeed>();

			foreach (var monster in _monsters)
			{
				//TODO: Complete placing logic, repeat place unit on another maptile if failed 
				_map.TryToAddMonster(
					monster.Id,
					(uint) new Random().Next(0, Defines.Map.MAP_HEIGHT),
					(uint) new Random().Next(0, Defines.Map.MAP_WIDTH));
			}

			//TODO: implement logic for placing items on map
			
		}

		public void AddMonster<T>() where T : Monster
		{
			uint constrParam = (uint)_monsters.Count + MONSTERS_START_ID;

			T monster = Activator.CreateInstance(typeof (T), constrParam) as T;

			_monsters.Add(monster);
		}

		public void AddItem<T>() where T : ConsumableItemBase
		{
			uint constrParam = (uint)_items.Count + ITEMS_START_ID;

			T item = Activator.CreateInstance(typeof (T), constrParam) as T;

			_items.Add(item);
		}

		public void AddPlayer(string name)
		{
			if (_player != null)
			{
				_player = new Player(name, PLAYER_ID);
			}
		}

		public void MoveCreature(CreatureBase creature, MoveDirection direction)
		{
			MapTileInfo destinationTileInfo = _map.GetAdjoiningLocationInfo(creature.Id, direction);

			if (creature.MovementLeftForThisTurn > destinationTileInfo.CostToMoveOn &&
				creature.PassableTerrainTypes.HasFlag(destinationTileInfo.TerrainType) && destinationTileInfo.CreatureId == 0)
			{
				EventManager.EventManager.Raise(new MoveCreatureMessage() { CreatureId = creature.Id, Direction = direction });
			}
		}

		public void MovePlayer(MoveDirection direction)
		{
			MoveCreature(_player, direction);
		}

		public void Handle(ConsumableItemFoundMessage message)
		{
			var item = _items.First(t => t.Id == message.ItemId);
			if (_player.TryToConsumeItem(item))
			{
				_items.Remove(item);
				EventManager.EventManager.Raise(new ItemConsumedMessage() {ItemId = item.Id});
			}
		}
	}
}