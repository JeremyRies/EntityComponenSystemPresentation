using UnityEngine;

namespace Systems
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private Sprite _playerGraphic;
        
        private static SpawnSystem _instance;
        private static int _playerNumber;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            var spaceEvent = FindObjectOfType<SpawnPlayerEventComponent>();
            if (spaceEvent != null)
            {
                SpawnPlayer();
                Destroy(spaceEvent.gameObject);
            }
        }

        private void SpawnPlayer()
        {
            var player = new GameObject();
            
            _playerNumber++;
            player.name = "Player_" + _playerNumber;
            player.AddComponent<IdComponent>().ID = _playerNumber;

            var spriteRenderer = player.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _playerGraphic;
            spriteRenderer.color = Random.ColorHSV();
            
            var pos = player.AddComponent<PositionComponent>();
            pos.Position = Random.insideUnitCircle * 5;
            
            player.AddComponent<InputComponent>();
            var movement = player.AddComponent<MovementComponent>();
            movement.Speed = Random.Range(1, 5);
        }
    }
}