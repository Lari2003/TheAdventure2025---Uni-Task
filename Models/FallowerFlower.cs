using System;
using TheAdventure.Models;

namespace TheAdventure
{
    public class FallowerFlower : RenderableGameObject
    {
        private PlayerObject _player;

        public FallowerFlower(PlayerObject player, SpriteSheet spriteSheet)
            : base(spriteSheet, (player.Position.X - 35, player.Position.Y + 15))
        {
            _player = player;
            spriteSheet.ActivateAnimation("IdleDown");
        }

        public void Update()
        {
            var (playerX, playerY) = _player.Position;
            var target = (playerX - 35, playerY + 15);
            var (currentX, currentY) = Position;
            int followSpeed = 2;

            int dx = target.Item1 - currentX;
            int dy = target.Item2 - currentY;

            if (Math.Abs(dx) > 2 || Math.Abs(dy) > 2)
            {
                int newX = currentX + Math.Sign(dx) * followSpeed;
                int newY = currentY + Math.Sign(dy) * followSpeed;
                Position = (newX, newY);
            }
        }
    }
}
