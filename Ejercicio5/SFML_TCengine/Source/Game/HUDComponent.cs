using SFML.Graphics;
using SFML.System;
using System;
using TCEngine;


namespace TCGame
{
    public class HUDComponent : RenderComponent
    {
        private int m_Kills = 0;

        private float m_barValue = 0; //de momento

        private Font m_Font;
        private Text m_Text;
        private Text m_BlinkText;

        private string m_Label;

        public HUDComponent(string _label)
        {
            m_RenderLayer = ERenderLayer.HUD;

            m_Label = _label;

            m_Font = TecnoCampusEngine.Get.Resources.GetFont("Fonts/Coffee Extra");
            m_Text = new Text(m_Label, m_Font);
            m_BlinkText = new Text(m_Kills.ToString(), m_Font);

            TextProperties();
            UpdateText();
        }

        public HUDComponent(string _label, Font _font)
        {
            m_RenderLayer = ERenderLayer.HUD;

            m_Label = _label;

            m_Font = _font;
            m_Text = new Text(m_Label, m_Font);

            TextProperties();
            UpdateText();
        }


        public override void Update(float _dt)
        {
            base.Update(_dt);
        }
        private void TextProperties()
        {

            const uint characterSize = 15u;
            const float outlineThickness = 2.0f;
            const float pointsOffset = 25.0f;
            Color outlineColor = Color.Red;

            m_Text.CharacterSize = characterSize;
            m_Text.OutlineThickness = outlineThickness;
            m_Text.OutlineColor = outlineColor;

            m_BlinkText.CharacterSize = characterSize;
            m_BlinkText.OutlineThickness = outlineThickness;
            m_BlinkText.OutlineColor = outlineColor;

            m_BlinkText.Position = new Vector2f(pointsOffset + m_Text.GetLocalBounds().Width, 0.0f);
        }

        //This method updates the number of kills
        private void UpdateText()
        {
            m_Text.DisplayedString = String.Format("{0}:", m_Label);
            m_BlinkText.DisplayedString = String.Format("{0}", m_Kills);
            
        }

        //This method updates the bar weight
        public void UpdateBar()
        {

        }

        //This method add kills to the hud
        public void IncreaseKills()
        {
            m_Kills++;
            UpdateText();
        }

        //This method reduces the player control timer
        public void ReduceControl(float dmg)
        {
            //falta añadir como se reduce la barra           
            UpdateBar();
        }

        //This method resets the player control timer
        public void ResetControl()
        {
            
            UpdateBar();
        }

        //This part draw the Hud object and clone it
        public override void Draw(RenderTarget _target, RenderStates _states)
        {
            base.Draw(_target, _states);

            _states.Transform *= Owner.GetWorldTransform();
            _target.Draw(m_Text, _states);
            _target.Draw(m_BlinkText, _states);
        }

        public override object Clone()
        {
            HUDComponent clonedcomponent = new HUDComponent(m_Label, m_Font);
            return clonedcomponent;
        }
    }
}
