using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Asteroids
{
    public enum GameState
    {
        None,
        TitleScreen,
        Gameplay,
        Paused,
        GameOver
    }

    public static class AsteroidsData
    {
        public static Rectangle _screenBounds = new(0, 0, 1024, 1024);
        public static string _title = "ASTEROIDS";
        public static string _pausedText = "PAUSED";
        public static string _gameOverText = "GAME OVER";
        public static string _startPrompt = "press SPACE to start";
        public static string _quitPrompt = "press Q to quit";
        public static string _resumePrompt = "press ESC to resume";
        public static string _exitPrompt = "press ESC to exit";

        public static SpriteFont _mainFont, _titleFont;
        public static KeyboardState _keyboardState, _keyboardStatePrevious;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public GameState _gameState = GameState.None;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = AsteroidsData._screenBounds.Width;
            _graphics.PreferredBackBufferHeight = AsteroidsData._screenBounds.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AsteroidsData._mainFont = Content.Load<SpriteFont>("MainFont");
            AsteroidsData._titleFont = Content.Load<SpriteFont>("TitleFont");
        }

        protected override void Update(GameTime gameTime)
        {
            AsteroidsData._keyboardStatePrevious = AsteroidsData._keyboardState;
            AsteroidsData._keyboardState = Keyboard.GetState();

            switch (_gameState)
            {
                case GameState.TitleScreen: UpdateTitleScreen(gameTime); break;
                case GameState.Gameplay: UpdateGameplay(gameTime); break;
                case GameState.Paused: UpdatePaused(gameTime); break;
                case GameState.GameOver: UpdateGameOver(gameTime); break;
                default: StartTitleScreen(); break;
            }

            base.Update(gameTime);
        }

        protected void StartTitleScreen()
        {
            _gameState = GameState.TitleScreen;
        }

        protected void StartGameplay()
        {
            _gameState = GameState.Gameplay;
        }

        protected void StartPaused()
        {
            _gameState = GameState.Paused;
        }

        protected void StartGameOver()
        {
            _gameState = GameState.GameOver;
        }

        protected void UpdateTitleScreen(GameTime gameTime)
        {
            if (AsteroidsData._keyboardState.IsKeyDown(Keys.Escape) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            else if (AsteroidsData._keyboardState.IsKeyDown(Keys.Space) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Space))
            {
                StartGameplay();
            }
        }

        protected void UpdateGameplay(GameTime gameTime)
        {
            if (AsteroidsData._keyboardState.IsKeyDown(Keys.Escape) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Escape))
            {
                StartPaused();
            }
            else if (AsteroidsData._keyboardState.IsKeyDown(Keys.K) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.K))
            {
                StartGameplay();
            }
        }

        protected void UpdatePaused(GameTime gameTime)
        {
            if (AsteroidsData._keyboardState.IsKeyDown(Keys.Q) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Q))
            {
                StartTitleScreen();
            }
            else if (AsteroidsData._keyboardState.IsKeyDown(Keys.Escape) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Escape))
            {
                StartGameplay();
            }
        }

        protected void UpdateGameOver(GameTime gameTime)
        {
            if (AsteroidsData._keyboardState.IsKeyDown(Keys.Q) && !AsteroidsData._keyboardStatePrevious.IsKeyDown(Keys.Q))
            {
                StartTitleScreen();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            switch (_gameState)
            {
                case GameState.TitleScreen: DrawTitleScreen(gameTime); break;
                case GameState.Gameplay: DrawGameplay(gameTime); break;
                case GameState.Paused: DrawPaused(gameTime); break;
                case GameState.GameOver: DrawGameOver(gameTime); break;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void DrawTitleScreen(GameTime gameTime)
        {
            Vector2 textSize = AsteroidsData._titleFont.MeasureString(AsteroidsData._title);
            _spriteBatch.DrawString(AsteroidsData._titleFont, AsteroidsData._title, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.HotPink);

            textSize = AsteroidsData._mainFont.MeasureString(AsteroidsData._startPrompt);
            _spriteBatch.DrawString(AsteroidsData._mainFont, AsteroidsData._startPrompt, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.Chartreuse);

            textSize = AsteroidsData._mainFont.MeasureString(AsteroidsData._exitPrompt);
            _spriteBatch.DrawString(AsteroidsData._mainFont, AsteroidsData._exitPrompt, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.Chartreuse);
        }

        protected void DrawGamePlay(GameTime gameTime)
        {

        }

        protected void DrawPaused(GameTime gameTime)
        {
            Vector2 textSize = AsteroidsData._titleFont.MeasureString(AsteroidsData._pausedText);
            _spriteBatch.DrawString(AsteroidsData._titleFont, AsteroidsData._pausedText, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.HotPink);

            textSize = AsteroidsData._mainFont.MeasureString(AsteroidsData._resumePrompt);
            _spriteBatch.DrawString(AsteroidsData._mainFont, AsteroidsData._resumePrompt, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.Chartreuse);

            textSize = AsteroidsData._mainFont.MeasureString(AsteroidsData._quitPrompt);
            _spriteBatch.DrawString(AsteroidsData._mainFont, AsteroidsData._quitPrompt, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.Chartreuse);
        }

        protected void DrawGameOver(GameTime gameTime)
        {
            Vector2 textSize = AsteroidsData._titleFont.MeasureString(AsteroidsData._gameOverText);
            _spriteBatch.DrawString(AsteroidsData._titleFont, AsteroidsData._gameOverText, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.HotPink);

            textSize = AsteroidsData._mainFont.MeasureString(AsteroidsData._quitPrompt);
            _spriteBatch.DrawString(AsteroidsData._mainFont, AsteroidsData._quitPrompt, (AsteroidsData._screenBounds.Center.ToVector2() * new Vector2(1f, 2f / 3f)) - textSize / 2f, Color.Chartreuse);
        }
    }
}