using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class SpriteShipPlayer : SpriteShip
    {
        public SpriteShipPlayer() : base(AsteroidsData._screenBounds.Center.ToVector2(), Vector2.Zero, 0f, Color.White)
        {
            _collisionRadius *= 2f / 3f;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            _moving = AsteroidsData._keyboardState.IsKeyDown(Keys.W) || AsteroidsData._keyboardState.IsKeyDown(Keys.Up);

            if (AsteroidsData._keyboardState.IsKeyDown(Keys.A) || AsteroidsData._keyboardState.IsKeyDown(Keys.Left)) _turning = -1;
            else if (AsteroidsData._keyboardState.IsKeyDown(Keys.D) || AsteroidsData._keyboardState.IsKeyDown(Keys.Right)) _turning = 1;
            else _turning = 0;

            if (AsteroidsData._keyboardState.IsKeyDown(Keys.Space) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Space) && !_shooting) _shooting = true;
            else if (!AsteroidsData._keyboardState.IsKeyDown(Keys.Space) && _shooting) _shooting = false;

            AsteroidsData._spriteList.OfType<SpriteRock>().ToList().ForEach(eachRock =>
            {
                if (IsColliding(eachRock))
                {
                    _isDead = true;
                    eachRock.OnHit();
                    for (int i = 0; i < 128; i++) AsteroidsData._newSpriteList.Add(new SpriteParticleDebris(_location));
                }
            });

            base.UpdateSprite(gameTime);
        }
    }
}
