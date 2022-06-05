using SFML.Graphics;
using SFML.System;
using TCEngine;

namespace TCGame
{
    class TwistedRelation : Game
    {
        public void Init()
        {
            CreateScenario();
            CreateMainCharacter();
            CreateEnemySpawner();
            //CreateAlly();
            //CreateControlBar();
            //CreateHUD();
        }

        public void DeInit()
        {
        }

        public void Update(float _dt)
        {
        }

        private void CreateMainCharacter()
        {
            Actor actor = new Actor("Following Mouse Actor");

            // Create an arrow shape using a ConvexShape

            ConvexShape shape = new ConvexShape(4);
            shape.SetPoint(0, new Vector2f(20.0f, 0.0f));
            shape.SetPoint(1, new Vector2f(40.0f, 40.0f));
            shape.SetPoint(2, new Vector2f(20.0f, 20.0f));
            shape.SetPoint(3, new Vector2f(0.0f, 40.0f));
            shape.FillColor = Color.Transparent;
            shape.OutlineColor = Color.Green;
            shape.OutlineThickness = 2.0f;
            actor.AddComponent<ShapeComponent>(shape);

            // Add the transform component and set its position correctly
            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(600.0f, 200.0f);

            // Add the aim component and set its position correctly
            AimMouseComponent mainAimMouseComponent = actor.AddComponent<AimMouseComponent>();
            mainAimMouseComponent.AngularSpeed = 360.0f;

            // Add the controller to the main character
            MainCharacterControllerComponent mainCharacterControllerComponent = 
                actor.AddComponent<MainCharacterControllerComponent>();
             
            //////////////////////////////////////////////////

            actor.AddComponent<WeaponComponent>();

            // Add the actor to the scene
            TecnoCampusEngine.Get.Scene.CreateActor(actor);
        }

        private void CreateEnemySpawner()
        {
            // Create the actor Object Spawner and add the ActorSpawnerComponent
            Actor objectSpawner = new Actor("Object Spawner");
            ActorSpawnerComponent<ActorPrefab> spawnerComponent = objectSpawner.AddComponent<ActorSpawnerComponent<ActorPrefab>>();

            // Set the MinTime and MaxTime
            spawnerComponent.m_MinTime = 0.2f;
            spawnerComponent.m_MaxTime = 3.0f;

            //Set the MinPosition and MaxPosition
            ScenarioComponent scenarioComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();

            spawnerComponent.m_MinPosition = new Vector2f(scenarioComponent.LeftFrame.Size.X, scenarioComponent.TopFrame.Size.Y);
            spawnerComponent.m_MaxPosition = new Vector2f(TecnoCampusEngine.Get.ViewportSize.X - scenarioComponent.LeftFrame.Size.X, TecnoCampusEngine.Get.ViewportSize.Y - scenarioComponent.BotFrame.Size.Y - 50);

            spawnerComponent.Reset();

            float objectRadius = 20.0f;

            ActorPrefab objectPrefab = new ActorPrefab("Object");

            // Add components to Object Prefab
            ShapeComponent shapeComponent = objectPrefab.AddComponent<ShapeComponent>();

            // Create de CircleShape
            CircleShape shape = new CircleShape(objectRadius);
            shape.FillColor = Color.Transparent;
            shape.OutlineColor = Color.Yellow;
            shape.OutlineThickness = 2.0f;

            shapeComponent.Shape = shape;
            
            // Add the other components
            TransformComponent transformComponent = objectPrefab.AddComponent<TransformComponent>();
            TargetComponent targetComponent = objectPrefab.AddComponent<TargetComponent>();

            spawnerComponent.AddActorPrefab(objectPrefab);

            // Add objecSpawner to the scene
            TecnoCampusEngine.Get.Scene.CreateActor(objectSpawner);
        }
        private void CreateControlBar()
        {
            Actor controlActor = new Actor("ControlBar Actor");

            SpriteComponent spriteComponent = controlActor.AddComponent<SpriteComponent>("Textures/barra",2u,1u);
            spriteComponent.m_RenderLayer = RenderComponent.ERenderLayer.Front;

            TransformComponent transformComponent = controlActor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(TecnoCampusEngine.WINDOW_HEIGHT/2, 50.0f);

            TimerComponent timerComp = controlActor.AddComponent<TimerComponent>();
            timerComp.Duration = 100.0f;

            controlActor.AddComponent<HUDComponent>("");

        }
        private void CreateScenario()
        {
            Actor scenarioController = new Actor("Scenario Actor");

            // Add the ScenarioComponent
            ScenarioComponent scenarioComponent = scenarioController.AddComponent<ScenarioComponent>();

            // Draw the 4 frames
            Actor top = new Actor("Top Frame Actor");
            top.AddComponent<ShapeComponent>(scenarioComponent.TopFrame);
            TransformComponent topPos = top.AddComponent<TransformComponent>();
            topPos.Transform.Position = scenarioComponent.TopPosition;

            Actor bot = new Actor("Bot Frame Acstor");
            bot.AddComponent<ShapeComponent>(scenarioComponent.BotFrame);
            TransformComponent botPos = bot.AddComponent<TransformComponent>();
            botPos.Transform.Position = scenarioComponent.BotPosition;

            Actor left = new Actor("Left Frame Actor");
            left.AddComponent<ShapeComponent>(scenarioComponent.LeftFrame);
            TransformComponent leftPos = left.AddComponent<TransformComponent>();
            leftPos.Transform.Position = scenarioComponent.LeftPosition;

            Actor right = new Actor("Right Frame Actor");
            right.AddComponent<ShapeComponent>(scenarioComponent.RightFrame);
            TransformComponent rightPos = right.AddComponent<TransformComponent>();
            rightPos.Transform.Position = scenarioComponent.RightPosition;

            Actor screen = new Actor("Screen Actor");
            screen.AddComponent<ShapeComponent>(scenarioComponent.Screen);
            TransformComponent screenPos = screen.AddComponent<TransformComponent>();
            screenPos.Transform.Position = scenarioComponent.ScreenPosition;


            TecnoCampusEngine.Get.Scene.CreateActor(scenarioController);
            TecnoCampusEngine.Get.Scene.CreateActor(screen);
            TecnoCampusEngine.Get.Scene.CreateActor(top);
            TecnoCampusEngine.Get.Scene.CreateActor(bot);
            TecnoCampusEngine.Get.Scene.CreateActor(left);
            TecnoCampusEngine.Get.Scene.CreateActor(right);
        }
        private void CreateHUD()
        {
            Actor actor = new Actor("HUD Actor");

            
            // Adds the transform component and set its position correctly
            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(900.0f, 50.0f);
            actor.AddComponent<HUDComponent>("Kills");

            TecnoCampusEngine.Get.Scene.CreateActor(actor);
        }

    }
}
