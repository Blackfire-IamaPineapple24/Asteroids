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
    public class SpriteRock : Sprite
    {
        private static float _rockSpeed = 100f;

        protected int _rockSize;

        public SpriteRock(Vector2 location, int size) : base(AsteroidsData._rocksTxr, location, GetSpawnVelocity(), AsteroidsData._rng.NextSingle() * float.Tau)
        {
            _rockSize = size;
        }

        public SpriteRock() : base(AsteroidsData._rocksTxr, GetSpawnLocation(), GetSpawnVelocity(), AsteroidsData._rng.NextSingle() * float.Tau)
        {
            _rockSize = 4;
        }

        private static Vector2 GetSpawnLocation()
        {
            int side = AsteroidsData._rng.Next(4);
            if (side == 0) return new(AsteroidsData._screenBounds.Left - 128, AsteroidsData._rng.Next(AsteroidsData._screenBounds.Top, AsteroidsData._screenBounds.Bottom));
            else if (side == 1) return new(AsteroidsData._screenBounds.Left + 128, AsteroidsData._rng.Next(AsteroidsData._screenBounds.Top, AsteroidsData._screenBounds.Bottom));
            else if (side == 3) return new(AsteroidsData._rng.Next(AsteroidsData._screenBounds.Left, AsteroidsData._screenBounds.Right), AsteroidsData._screenBounds.Top - 128);
            else return new(AsteroidsData._rng.Next(AsteroidsData._screenBounds.Left, AsteroidsData._screenBounds.Right), AsteroidsData._screenBounds.Bottom + 128);
        }

        private static Vector2 GetSpawnVelocity()
        {
            return new(AsteroidsData._rng.NextSingle() * _rockSpeed, AsteroidsData._rng.NextSingle() * _rockSpeed);
        }
    }
}
