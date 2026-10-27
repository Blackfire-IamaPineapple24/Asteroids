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
        public SpriteShipPlayer() : base(AsteroidsData._screenBounds.Center.ToVector2(), Vector2.Zero, 0f, Color.White) { }

        public override void UpdateSprite(GameTime gameTime)
        {
            _moving = AsteroidsData._keyboardState.IsKeyDown(Keys.W);

            if (AsteroidsData._keyboardState.IsKeyDown(Keys.A)) _turning = -1;
            else if (AsteroidsData._keyboardState.IsKeyDown(Keys.D)) _turning = 1;
            else _turning = 0;

            base.UpdateSprite(gameTime);
        }
    }
}
