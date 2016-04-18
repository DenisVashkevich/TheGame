using System;
using System.Collections.Generic;
using Core.Entities.Creatures;
using Core.Entities.Map;
using Core.Services.EventManager.Messages;

namespace Core.Services
{
	public class GameProcess
	{
		private const uint PLAYER_ID = 1;
		private const uint MONSTERS_START_ID = 2;

		private GameProcess _instance;
		private Map _map;
		private List<CreatureBase> _monsters;
		private List<CreatureBase> _items;
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

		public void AddMonster<T>() where T : Monster
		{
			uint constrParam = (uint)_monsters.Count + MONSTERS_START_ID;

			T monster = Activator.CreateInstance(typeof (T), constrParam) as T;

			_monsters.Add(monster);
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

	}
}