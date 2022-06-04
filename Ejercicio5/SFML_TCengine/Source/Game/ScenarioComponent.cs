using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using TCEngine;


namespace TCGame
{
    public class ScenarioComponent:BaseComponent
    {
        private float m_TopFrameThickness = 200.0f;
        private float m_FrameThickness = 100.0f;
        private float m_WindowHeight;
        private float m_WindowWidth;
        private FloatRect m_TopFrame, m_BotFrame, m_LeftFrame, m_RightFrame;
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
        public FloatRect TopFrame
        {
            get => m_TopFrame;
            set => m_TopFrame = value;
        }
        public FloatRect BotFrame
        {
            get => m_BotFrame;
            set => m_BotFrame = value;
        }
        public FloatRect LeftFrame
        {
            get => m_LeftFrame;
            set => m_LeftFrame = value;
        }
        public FloatRect RightFrame
        {
            get => m_RightFrame;
            set => m_RightFrame= value;
        }
        public ScenarioComponent()
        {
            m_WindowWidth = TecnoCampusEngine.WINDOW_WIDTH * 2;
            m_WindowHeight = TecnoCampusEngine.WINDOW_HEIGHT * 2;
            CreateFrame();
        }
        
        private void CreateFrame()
        {
            m_TopFrame = new FloatRect(new Vector2f(0,0), new Vector2f(m_WindowWidth, m_TopFrameThickness));
            m_BotFrame = new FloatRect(new Vector2f(m_WindowWidth,m_WindowHeight), new Vector2f( - m_WindowWidth, - m_FrameThickness));
            m_LeftFrame = new FloatRect(new Vector2f(0,0), new Vector2f(m_FrameThickness, m_WindowHeight));
            m_RightFrame = new FloatRect(new Vector2f(m_WindowWidth,m_WindowHeight), new Vector2f(- m_FrameThickness,  - m_WindowHeight));
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
