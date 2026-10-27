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
    public class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _location;
        protected Vector2 _origin;
        protected Vector2 _velocity;
        protected float _angle;
        protected float _angularVelocity;
        protected float _collisionRadius;
        protected bool _isDead;
        protected bool _canCollide;
        protected bool _canWrap;
        protected Color _colour;
        protected Rectangle _drawBounds;
        protected Rectangle _sourceBounds;

        public Sprite(Texture2D texture, Vector2 location, Vector2? velocity = null, float? angle = null, Color? colour = null)
        {
            _texture = texture;
            _location = location;
            _velocity = velocity ?? Vector2.Zero;
            _angle = angle ?? 0f;
            _colour = colour ?? Color.White;

            _sourceBounds = _texture.Bounds;
            _origin = _texture.Bounds.Center.ToVector2();
            _collisionRadius = _origin.X; // Half the width of the texture
            _angularVelocity = 0f;
            _isDead = false;
            _canCollide = true;
            _canWrap = true;
        }

        public virtual void UpdateSprite(GameTime gameTime)
        {
            if (_isDead) return;

            _location += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _angle += _angularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_canWrap)
            {
                if (_location.X < AsteroidsData._screenBounds.Left - _origin.X) _location.X = AsteroidsData._screenBounds.Right + _origin.X;
                else if (_location.X > AsteroidsData._screenBounds.Right + _origin.X) _location.X = AsteroidsData._screenBounds.Left - _origin.X;

                if (_location.Y < AsteroidsData._screenBounds.Top - _origin.Y) _location.Y = AsteroidsData._screenBounds.Bottom + _origin.Y;
                else if (_location.Y > AsteroidsData._screenBounds.Bottom + _origin.Y) _location.Y = AsteroidsData._screenBounds.Top - _origin.Y;
            }

            _drawBounds = new(_location.ToPoint(), _sourceBounds.Size);
        }

        public virtual void DrawSprite(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _drawBounds, _sourceBounds, _colour, _angle, _origin, SpriteEffects.None, 0f);
        }

        public Vector2 GetForward()
        {
            return new Vector2(float.Cos(_angle), float.Sin(_angle));
        }
    }
}
