# POCs Event-Driven Architecture

## Project Overview

A C# .NET proof-of-concept demonstrating a **Mediator-based event-driven architecture**. Services communicate exclusively through typed events routed by a central mediator — no direct service-to-service dependencies.

## Solution Structure

```
Events-POC.sln
├── Events-POC/          # Console app entry point (.NET Core 3.1)
├── Common/              # Shared base classes & interfaces (.NET Standard 2.0)
├── LocalMediator/       # Mediator implementation (.NET Core 3.1)
├── Asset/               # Asset domain service (.NET Standard 2.0)
├── Book/                # Book domain service (.NET Core 3.1)
└── DataImpor/           # Data import service (.NET Standard 2.0)  ← folder name has typo
```

## Build & Run

```powershell
# Build solution
dotnet build Events-POC.sln

# Run the console app
dotnet run --project Events-POC/Events-POC.csproj
```

The console app prompts each service to type a message (interactive), then triggers an asset creation request flow.

## Architecture

### Core Pattern

```
Service A  --publishes--> Mediator --dispatches--> Service B (ReactTo)
                                   --dispatches--> Service C (ReactTo)
```

- **Mediator** (`LocalMediator/Mediator.cs`): Holds a `Dictionary<Service, Event[]>` registry. On `Interact(event)`, it finds all services subscribed to that event type — excluding the event's originating service — and calls `ReactTo` on each.
- **Service** (`Common/Service/Service.cs`): Abstract base. Each concrete service registers its event subscriptions and an `EventReactionRegistry` in its constructor.
- **EventReactionRegistry**: Maps event instances (by type name) to `Reaction` implementations inside a service.
- **Reaction** (`Common/Reaction/Reaction.cs`): Abstract base with a single `ReactTo(Event)` method.

### Event Flow Example (Asset Creation)

1. `DataImportService.SendAssetCreationRequest(id, type, cost)` creates an `Asset` model and publishes `AssetCreationRequestEvent` via the mediator.
2. `AssetService` is subscribed to `AssetCreationRequestEvent` → its `AssetReactionToCreationRequestEvent` runs.
3. Asset service publishes `AssetCreationResponseEvent`.
4. Both `BookService` and `DataImportService` are subscribed to `AssetCreationResponseEvent` → both react.
5. Asset service also publishes `SaveAssetActionCompleteEvent` → `DataImportService` reacts.

### Event Types (in `Common/Events/EventBox/`)

| Event | Published by | Consumed by |
|---|---|---|
| `SendMessageEvent` | Any service | All other services |
| `AssetCreationRequestEvent` | DataImport | Asset |
| `AssetCreationResponseEvent` | Asset | Book, DataImport |
| `SaveAssetActionCompleteEvent` | Asset | DataImport |

## Adding a New Service

1. Create a new project under the solution.
2. Add a project reference to `Common`.
3. Create a `XyzService : Service` class.
4. In the constructor: call `mediator.Subscribe(...)` with the event types to receive, and populate `EventReactionRegistry` with `EventReaction` entries pairing event instances to `Reaction` subclasses.
5. Create a `Reactions/` folder with one `Reaction` subclass per subscribed event type.
6. Register the new service in `Events-POC/Program.cs`.

## Adding a New Event Type

1. Add a class in `Common/Events/EventBox/` extending `Event`.
2. Pass any payload as constructor parameters and expose via properties.
3. Register the new event in any service's `mediator.Subscribe(...)` call and `EventReactionRegistry`.

## Known Issues / Notes

- `DataImpor/` folder name is a typo (missing 't') — the `.csproj` inside is named `DataImport.csproj` correctly.
- The `Subscribe` update path in `Mediator.cs:27` has a bug: `ToList().AddRange(...)` creates a transient list and discards it — re-subscribing a service won't actually append new events.
- Event routing uses `GetType().Name` string comparison, not a type-safe key — renaming an event class is a silent breaking change.
