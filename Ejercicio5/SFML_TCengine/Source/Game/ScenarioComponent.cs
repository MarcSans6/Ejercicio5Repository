using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using TCEngine;


namespace TCGame
{
    public class ScenarioComponent:BaseComponent
    {
        private float m_TopFrameThickness = 250.0f;
        private float m_FrameThickness = 100.0f;
        private float m_WindowHeight;
        private float m_WindowWidth;
        private RectangleShape m_TopFrame, m_BotFrame, m_LeftFrame, m_RightFrame, m_Screen;
        private Vector2f m_TopPosition, m_BotPosition, m_LeftPosition, m_RightPosition,m_ScreenPosition;
        private Color m_FrameColor = Color.Yellow, m_ScreenColor = Color.Blue;
        
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
            m_WindowWidth = TecnoCampusEngine.Get.ViewportSize.X;
            m_WindowHeight = TecnoCampusEngine.Get.ViewportSize.Y;

            m_TopPosition = new Vector2f(0,0);
            m_BotPosition = new Vector2f(0,m_WindowHeight + 50);
            m_LeftPosition = new Vector2f(0,0);
            m_RightPosition = new Vector2f(m_WindowWidth, 0);
            m_ScreenPosition = new Vector2f (0, 0);

            CreateFrame();

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
