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
            CreateHUD();
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

            // TODO:
            // - Add your new component (the one that follows the mouse poisition) to the actor
            AimMouseComponent mainFollowMouseComponent = actor.AddComponent<AimMouseComponent>();
            
            //   with a linear speed of 400 pixels/second and an angular speed of 360 degrees/second
            mainFollowMouseComponent.Speed = 400.0f;
            mainFollowMouseComponent.AngularSpeed = 360.0f;

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

            Sp
            TransformComponent transformComponent = controlActor.AddComponent<TransformComponent>();
            transformComponent.Transform.Position = new Vector2f(TecnoCampusEngine.WINDOW_HEIGHT/2, 50.0f);

            TimerComponent timerComp = controlActor.AddComponent<TimerComponent>();
            timerComp.Duration = 100.0f;
            

        }
        private void CreateScenario()
        {
            Actor actor = new Actor("Scenario Actor");

            // Add the ScenarioComponent

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
