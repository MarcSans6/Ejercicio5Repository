using SFML.Graphics;
using SFML.System;
using TCEngine;

namespace TCGame
{
    class TwistedRelation : Game
    {
        public void Init()
        {
            CreateMainCharacter();
            //CreateAlly();
            CreateEnemySpawner();
            //CreateControlBar();
            CreateScenario();
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
            spawnerComponent.m_MinPosition = new Vector2f(10, 10);
            spawnerComponent.m_MaxPosition = new Vector2f(TecnoCampusEngine.Get.ViewportSize.X - 10, TecnoCampusEngine.Get.ViewportSize.Y - 10);

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

            TransformComponent transformComponent = controlActor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(TecnoCampusEngine.WINDOW_HEIGHT/2, 50.0f);

            TimerComponent timerComp = controlActor.AddComponent<TimerComponent>();
            timerComp.Duration = 100.0f;
            

        }
        private void CreateScenario()
        {
            Actor scenarioController = new Actor("Scenario Actor");

            // Add the ScenarioComponent
            ScenarioComponent scenarioComponent = scenarioController.AddComponent<ScenarioComponent>();

            // Draw the 4 frames
            RectangleShape topRect = new RectangleShape(new Vector2f(scenarioComponent.TopFrame.Width, scenarioComponent.TopFrame.Height));
            RectangleShape botRect = new RectangleShape(new Vector2f(scenarioComponent.BotFrame.Width, scenarioComponent.BotFrame.Height));
            RectangleShape leftRect = new RectangleShape(new Vector2f(scenarioComponent.LeftFrame.Width, scenarioComponent.LeftFrame.Height));
            RectangleShape rightRect = new RectangleShape(new Vector2f(scenarioComponent.RightFrame.Width, scenarioComponent.RightFrame.Height));
            topRect.FillColor = Color.Blue + Color.Red;
            botRect.FillColor = Color.Blue + Color.Red;
            leftRect.FillColor = Color.Blue + Color.Red;
            rightRect.FillColor = Color.Blue + Color.Red;

            float windowX = TecnoCampusEngine.WINDOW_WIDTH;
            float windowY = TecnoCampusEngine.WINDOW_HEIGHT;

            Actor top = new Actor("Top Frame Actor");
            top.AddComponent<ShapeComponent>(topRect);
            TransformComponent topTransform = top.AddComponent<TransformComponent>();
            topTransform.Transform.Position = new Vector2f(0, 0);
            Actor bot = new Actor("Bot Frame Actor");
            bot.AddComponent<ShapeComponent>(botRect);
            TransformComponent botTransform = bot.AddComponent<TransformComponent>();
            botTransform.Transform.Position = new Vector2f(windowX, windowY);
            Actor left = new Actor("Left Frame Actor");
            left.AddComponent<ShapeComponent>(leftRect);
            TransformComponent leftTransform = left.AddComponent<TransformComponent>();
            leftTransform.Transform.Position = new Vector2f(0, 0);
            Actor right = new Actor("Right Frame Actor");
            right.AddComponent<ShapeComponent>(rightRect);
            TransformComponent rightTransform = right.AddComponent<TransformComponent>();
            rightTransform.Transform.Position = new Vector2f(windowX, windowY);

            TecnoCampusEngine.Get.Scene.CreateActor(scenarioController);
            TecnoCampusEngine.Get.Scene.CreateActor(top);
            TecnoCampusEngine.Get.Scene.CreateActor(bot);
            //TecnoCampusEngine.Get.Scene.CreateActor(left);
            //TecnoCampusEngine.Get.Scene.CreateActor(right);
        }
        private void CreateHUD()
        {
            Actor actor = new Actor("HUD Actor");

            // Add the transform component and set its position correctly
            TransformComponent transformComponent = actor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(900.0f, 50.0f);
            actor.AddComponent<HUDComponent>("Puntos");

            // Something is missing here!!!
            TecnoCampusEngine.Get.Scene.CreateActor(actor);
            //////////////////////////////////////
        }

    }
}
