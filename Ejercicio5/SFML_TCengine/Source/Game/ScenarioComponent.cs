using SFML.Graphics;
using SFML.System;
using TCEngine;


namespace TCGame
{
    public class ScenarioComponent:BaseComponent
    {
        private float m_TopFrameThickness = 150.0f;
        private float m_FrameThickness = 100.0f;
        private float m_WindowHeight;
        private float m_WindowWidth;
        private RectangleShape m_TopFrame, m_BotFrame, m_LeftFrame, m_RightFrame, m_Screen;
        private Vector2f m_TopPosition, m_BotPosition, m_LeftPosition, m_RightPosition,m_ScreenPosition;
        public FloatRect TopFrameBounds, BotFrameBounds, LeftFrameBounds, RightFrameBounds;
        private Color m_FrameColor = Color.Blue + Color.Red, m_ScreenColor = Color.Transparent;
        private float offSet = 50.0f;
        
        public float WindowWidth
        {
            get => m_WindowWidth;
            set => m_WindowWidth = value;
        }
        public float WindowHeight
        {
            get => m_WindowHeight;
            set => m_WindowHeight = value;
        }
        public Vector2f TopPosition
        {
            get => m_TopPosition;
            set => m_TopPosition = value;
        }
        public Vector2f BotPosition
        {
            get => m_BotPosition;
            set => m_BotPosition = value;
        }
        public Vector2f LeftPosition
        {
            get => m_LeftPosition;
            set => m_LeftPosition = value;
        }
        public Vector2f RightPosition
        {
            get => m_RightPosition;
            set => m_RightPosition = value;
        }
        public Vector2f ScreenPosition
        {
            get => m_ScreenPosition;
            set => m_ScreenPosition = value;
        }
        public RectangleShape TopFrame
        {
            get => m_TopFrame;
            set => m_TopFrame = value;
        }
        public RectangleShape BotFrame
        {
            get => m_BotFrame;
            set => m_BotFrame = value;
        }
        public RectangleShape LeftFrame
        {
            get => m_LeftFrame;
            set => m_LeftFrame = value;
        }
        public RectangleShape RightFrame
        {
            get => m_RightFrame;
            set => m_RightFrame= value;
        }
        public RectangleShape Screen
        {
            get => m_Screen;
            set => m_Screen = value;
        }

        public ScenarioComponent()
        {
            m_WindowWidth = TecnoCampusEngine.WINDOW_WIDTH;
            m_WindowHeight = TecnoCampusEngine.WINDOW_HEIGHT;
            TecnoCampusEngine.Get.ViewportSize = new Vector2f(m_WindowWidth,m_WindowHeight);

            m_TopPosition = new Vector2f(offSet,offSet);
            m_BotPosition = new Vector2f(offSet,m_WindowHeight + offSet);
            m_LeftPosition = new Vector2f(offSet,offSet);
            m_RightPosition = new Vector2f(m_WindowWidth - offSet,offSet);
            m_ScreenPosition = new Vector2f (offSet, offSet);

            CreateFrame();

            TopFrameBounds = new FloatRect(new Vector2f(0,0), m_TopFrame.Size);
            BotFrameBounds = new FloatRect(new Vector2f(0,m_WindowHeight), m_BotFrame.Size);
            LeftFrameBounds = new FloatRect(new Vector2f(0, 0), m_LeftFrame.Size);
            RightFrameBounds = new FloatRect(new Vector2f(m_WindowWidth - offSet * 2,0), m_RightFrame.Size);

            m_TopFrame.FillColor = m_FrameColor;
            m_BotFrame.FillColor = m_FrameColor;
            m_LeftFrame.FillColor = m_FrameColor;
            m_RightFrame.FillColor = m_FrameColor;
            m_Screen.FillColor = m_ScreenColor;

        }
        
        private void CreateFrame()
        {
            m_TopFrame = new RectangleShape(new Vector2f(m_WindowWidth * 2, m_TopFrameThickness));
            m_BotFrame = new RectangleShape(new Vector2f(m_WindowWidth * 2, - m_FrameThickness));
            m_LeftFrame = new RectangleShape(new Vector2f(m_FrameThickness, m_WindowHeight * 2));
            m_RightFrame = new RectangleShape(copy:m_LeftFrame);
            m_Screen = new RectangleShape(new Vector2f(m_WindowWidth * 2, m_WindowHeight*2));
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            TargetComponent clonedComponent = new TargetComponent();
            return clonedComponent;
        }
    
    }

    
}
